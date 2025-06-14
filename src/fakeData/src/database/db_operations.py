import pyodbc


def insert_into_sqlserver(data_dict, conn_str):
    """
    将数据插入到SQL Server数据库中，包含约束检查
    """
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()
    cursor.fast_executemany = True

    try:
        # Bookshelf
        if "Bookshelf" in data_dict:
            bookshelf_data = data_dict["Bookshelf"]

            # 检查 ShelfCode 是否已存在
            existing_codes = set()
            cursor.execute("SELECT ShelfCode FROM Bookshelf")
            for row in cursor.fetchall():
                existing_codes.add(row.ShelfCode)

            # 过滤掉已存在的 ShelfCode
            new_shelves = []
            for shelf in bookshelf_data:
                if shelf["ShelfCode"] not in existing_codes:
                    new_shelves.append(shelf)
                else:
                    print(f"警告: 书架编号 {shelf['ShelfCode']} 已存在，跳过插入")

            if new_shelves:
                cursor.executemany(
                    "INSERT INTO Bookshelf (ShelfCode, Location) VALUES (?, ?)",
                    [(x["ShelfCode"], x["Location"]) for x in new_shelves],
                )
                conn.commit()
                print(f"成功插入 {len(new_shelves)} 个新书架")

            # 获取所有书架ID映射（包括已存在的）
            cursor.execute("SELECT ShelfId, ShelfCode FROM Bookshelf")
            shelf_map = {row.ShelfCode: row.ShelfId for row in cursor.fetchall()}
        else:
            shelf_map = {}

        # Book
        if "Book" in data_dict:
            book_data = data_dict["Book"]

            # 检查 ISBN 是否已存在
            existing_isbns = set()
            cursor.execute("SELECT ISBN FROM Book")
            for row in cursor.fetchall():
                if row.ISBN:  # 跳过 NULL 值
                    existing_isbns.add(row.ISBN)

            # 检查 ShelfId 是否存在
            books_to_insert = []
            skipped_books = []
            for book in book_data:
                # 检查 ISBN 唯一性
                if book["ISBN"] in existing_isbns:
                    print(f"警告: ISBN {book['ISBN']} 已存在，跳过插入")
                    skipped_books.append(book)
                    continue

                # 检查库存
                if book["Inventory"] < 0:
                    print(f"警告: 图书 {book['BookName']} 的库存不能为负数，设置为0")
                    book["Inventory"] = 0

                # 处理 ShelfId
                shelf_id = book["ShelfId"]
                if isinstance(shelf_id, int):
                    real_shelf_id = shelf_id
                else:
                    real_shelf_id = shelf_map.get(shelf_id)
                    if real_shelf_id is None:
                        print(
                            f"警告: 图书 {book['BookName']} 的书架ID {shelf_id} 不存在，设置为NULL"
                        )
                        real_shelf_id = None

                books_to_insert.append(
                    (
                        book["BookName"],
                        book["Author"],
                        book["ISBN"],
                        book["Price"],
                        book["Inventory"],
                        book["Picture"],
                        real_shelf_id,
                    )
                )

            if books_to_insert:
                cursor.executemany(
                    """INSERT INTO Book (BookName, Author, ISBN, Price, Inventory, Picture, ShelfId)
                       VALUES (?, ?, ?, ?, ?, ?, ?)""",
                    books_to_insert,
                )
                conn.commit()
                print(f"成功插入 {len(books_to_insert)} 本新书")
                if skipped_books:
                    print(f"跳过 {len(skipped_books)} 本已存在的书")

        # UserTable
        if "UserTable" in data_dict:
            user_data = data_dict["UserTable"]

            # 检查 CardNum 是否已存在
            existing_cards = set()
            cursor.execute("SELECT CardNum FROM UserTable")
            for row in cursor.fetchall():
                existing_cards.add(row.CardNum)

            # 过滤并验证用户数据
            users_to_insert = []
            skipped_users = []
            for user in user_data:
                if user["CardNum"] in existing_cards:
                    print(f"警告: 卡号 {user['CardNum']} 已存在，跳过插入")
                    skipped_users.append(user)
                    continue

                # 确保 Start_Time 不为空
                if not user.get("Start_Time"):
                    from datetime import datetime

                    user["Start_Time"] = datetime.now()

                users_to_insert.append(
                    (
                        user["CardNum"],
                        user["UserName"],
                        user["StudentID"],
                        user["Phone"],
                        user["Class"],
                        user["Photo"],
                        user["Start_Time"],
                        user["Ending_Time"],
                    )
                )

            if users_to_insert:
                cursor.executemany(
                    """INSERT INTO UserTable 
                    (CardNum, UserName, StudentID, Phone, Class, Photo, Start_Time, Ending_Time)
                    VALUES (?, ?, ?, ?, ?, ?, ?, ?)""",
                    users_to_insert,
                )
                conn.commit()
                print(f"成功插入 {len(users_to_insert)} 个新用户")
                if skipped_users:
                    print(f"跳过 {len(skipped_users)} 个已存在的用户")

        # Admin
        if "Admin" in data_dict:
            admin_data = data_dict["Admin"]

            # 检查 Username 是否已存在
            existing_usernames = set()
            cursor.execute("SELECT Username FROM Admin")
            for row in cursor.fetchall():
                existing_usernames.add(row.Username)

            # 过滤管理员数据
            admins_to_insert = []
            skipped_admins = []
            for admin in admin_data:
                if admin["Username"] in existing_usernames:
                    print(f"警告: 管理员账号 {admin['Username']} 已存在，跳过插入")
                    skipped_admins.append(admin)
                    continue

                admins_to_insert.append(
                    (
                        admin["Username"],
                        admin["Pwd"],
                        admin["Phone"],
                        admin["Type"],
                    )
                )

            if admins_to_insert:
                cursor.executemany(
                    "INSERT INTO Admin (Username, Pwd, Phone, Type) VALUES (?, ?, ?, ?)",
                    admins_to_insert,
                )
                conn.commit()
                print(f"成功插入 {len(admins_to_insert)} 个新管理员")
                if skipped_admins:
                    print(f"跳过 {len(skipped_admins)} 个已存在的管理员")

        # Borrow
        if "Borrow" in data_dict:
            borrow_data = data_dict["Borrow"]

            # 获取所有有效的 ID
            cursor.execute("SELECT UserId FROM UserTable")
            valid_user_ids = {row.UserId for row in cursor.fetchall()}

            cursor.execute("SELECT BookId FROM Book")
            valid_book_ids = {row.BookId for row in cursor.fetchall()}

            cursor.execute("SELECT AdminId FROM Admin")
            valid_admin_ids = {row.AdminId for row in cursor.fetchall()}

            # 过滤借阅记录
            borrows_to_insert = []
            skipped_borrows = []
            for borrow in borrow_data:
                # 检查外键约束
                if borrow["UserId"] not in valid_user_ids:
                    print(f"警告: 用户ID {borrow['UserId']} 不存在，跳过该借阅记录")
                    skipped_borrows.append(borrow)
                    continue

                if borrow["BookId"] not in valid_book_ids:
                    print(f"警告: 图书ID {borrow['BookId']} 不存在，跳过该借阅记录")
                    skipped_borrows.append(borrow)
                    continue

                if (
                    borrow["BorrowAdminId"]
                    and borrow["BorrowAdminId"] not in valid_admin_ids
                ):
                    print(
                        f"警告: 借书管理员ID {borrow['BorrowAdminId']} 不存在，设置为NULL"
                    )
                    borrow["BorrowAdminId"] = None

                if (
                    borrow["ReturnAdminId"]
                    and borrow["ReturnAdminId"] not in valid_admin_ids
                ):
                    print(
                        f"警告: 还书管理员ID {borrow['ReturnAdminId']} 不存在，设置为NULL"
                    )
                    borrow["ReturnAdminId"] = None

                borrows_to_insert.append(
                    (
                        borrow["UserId"],
                        borrow["BookId"],
                        borrow["BorrowAdminId"],
                        borrow["ReturnAdminId"],
                        borrow["BorrowDate"],
                        borrow["ReturnDate"],
                    )
                )

            if borrows_to_insert:
                cursor.executemany(
                    """INSERT INTO Borrow
                    (UserId, BookId, BorrowAdminId, ReturnAdminId, BorrowDate, ReturnDate)
                    VALUES (?, ?, ?, ?, ?, ?)""",
                    borrows_to_insert,
                )
                conn.commit()
                print(f"成功插入 {len(borrows_to_insert)} 条借阅记录")
                if skipped_borrows:
                    print(f"跳过 {len(skipped_borrows)} 条无效的借阅记录")

        print("数据已成功插入 SQL Server 数据库。")

    except Exception as e:
        print(f"插入数据时发生错误: {str(e)}")
        conn.rollback()
        raise

    finally:
        cursor.close()
        conn.close()
