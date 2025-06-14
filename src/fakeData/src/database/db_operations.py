import pyodbc


def insert_into_sqlserver(data_dict, conn_str):
    """
    将数据插入到SQL Server数据库
    """
    conn = None
    try:
        conn = pyodbc.connect(conn_str)
        cursor = conn.cursor()

        # 开始事务
        conn.autocommit = False

        # 用于统计实际插入的数量
        inserted_counts = {
            "Bookshelf": 0,
            "Book": 0,
            "UserTable": 0,
            "Admin": 0,
            "Borrow": 0,
        }

        # 插入书架数据
        if "Bookshelf" in data_dict:
            shelves = data_dict["Bookshelf"]
            for shelf in shelves:
                try:
                    cursor.execute(
                        """
                        INSERT INTO Bookshelf (ShelfCode, Location)
                        VALUES (?, ?)
                        """,
                        shelf["ShelfCode"],
                        shelf["Location"],
                    )
                    inserted_counts["Bookshelf"] += 1
                except pyodbc.IntegrityError:
                    print(f"警告: 书架代码 {shelf['ShelfCode']} 已存在，跳过插入")
                    continue

        # 获取所有书架ID映射
        cursor.execute("SELECT ShelfId, ShelfCode FROM Bookshelf")
        shelf_map = {row.ShelfCode: row.ShelfId for row in cursor.fetchall()}

        # 插入图书数据
        if "Book" in data_dict:
            books = data_dict["Book"]
            for book in books:
                try:
                    # 检查 ShelfId 是否存在
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

                    cursor.execute(
                        """
                        INSERT INTO Book (BookName, Author, ISBN, Price, Inventory, Picture, ShelfId)
                        VALUES (?, ?, ?, ?, ?, ?, ?)
                        """,
                        book["BookName"],
                        book["Author"],
                        book["ISBN"],
                        book["Price"],
                        book["Inventory"],
                        book["Picture"],
                        real_shelf_id,
                    )
                    inserted_counts["Book"] += 1
                except pyodbc.IntegrityError:
                    print(f"警告: ISBN {book['ISBN']} 已存在，跳过插入")
                    continue

        # 插入用户数据
        if "UserTable" in data_dict:
            users = data_dict["UserTable"]
            for user in users:
                try:
                    cursor.execute(
                        """
                        INSERT INTO UserTable (CardNum, UserName, StudentID, Phone, Class, Photo, Start_Time, Ending_Time)
                        VALUES (?, ?, ?, ?, ?, ?, ?, ?)
                        """,
                        user["CardNum"],
                        user["UserName"],
                        user["StudentID"],
                        user["Phone"],
                        user["Class"],
                        user["Photo"],
                        user["Start_Time"],
                        user["Ending_Time"],
                    )
                    inserted_counts["UserTable"] += 1
                except pyodbc.IntegrityError:
                    print(f"警告: 卡号 {user['CardNum']} 已存在，跳过插入")
                    continue

        # 插入管理员数据
        if "Admin" in data_dict:
            admins = data_dict["Admin"]
            for admin in admins:
                try:
                    cursor.execute(
                        """
                        INSERT INTO Admin (Username, Pwd, Phone, Type)
                        VALUES (?, ?, ?, ?)
                        """,
                        admin["Username"],
                        admin["Pwd"],
                        admin["Phone"],
                        admin["Type"],
                    )
                    inserted_counts["Admin"] += 1
                except pyodbc.IntegrityError:
                    print(f"警告: 用户名 {admin['Username']} 已存在，跳过插入")
                    continue

        # 获取所有有效的ID
        cursor.execute("SELECT UserId FROM UserTable")
        valid_user_ids = {row.UserId for row in cursor.fetchall()}

        cursor.execute("SELECT BookId FROM Book")
        valid_book_ids = {row.BookId for row in cursor.fetchall()}

        cursor.execute("SELECT AdminId FROM Admin")
        valid_admin_ids = {row.AdminId for row in cursor.fetchall()}

        # 插入借阅记录数据
        if "Borrow" in data_dict:
            borrows = data_dict["Borrow"]
            for borrow in borrows:
                try:
                    # 检查外键约束
                    if borrow["UserId"] not in valid_user_ids:
                        print(f"警告: 用户ID {borrow['UserId']} 不存在，跳过该借阅记录")
                        continue

                    if borrow["BookId"] not in valid_book_ids:
                        print(f"警告: 图书ID {borrow['BookId']} 不存在，跳过该借阅记录")
                        continue

                    # 处理管理员ID
                    borrow_admin_id = borrow["BorrowAdminId"]
                    if borrow_admin_id and borrow_admin_id not in valid_admin_ids:
                        print(
                            f"警告: 借书管理员ID {borrow_admin_id} 不存在，设置为NULL"
                        )
                        borrow_admin_id = None

                    return_admin_id = borrow["ReturnAdminId"]
                    if return_admin_id and return_admin_id not in valid_admin_ids:
                        print(
                            f"警告: 还书管理员ID {return_admin_id} 不存在，设置为NULL"
                        )
                        return_admin_id = None

                    cursor.execute(
                        """
                        INSERT INTO Borrow (UserId, BookId, BorrowAdminId, ReturnAdminId, BorrowDate, ReturnDate)
                        VALUES (?, ?, ?, ?, ?, ?)
                        """,
                        borrow["UserId"],
                        borrow["BookId"],
                        borrow_admin_id,
                        return_admin_id,
                        borrow["BorrowDate"],
                        borrow["ReturnDate"],
                    )
                    inserted_counts["Borrow"] += 1
                except pyodbc.IntegrityError:
                    print(f"警告: 借阅记录已存在，跳过插入")
                    continue

        # 提交事务
        conn.commit()

        # 打印实际插入的数量
        for table, count in inserted_counts.items():
            if count > 0:
                print(f"成功插入 {count} 条{table}数据")

        print("数据已成功插入 SQL Server 数据库。")

    except Exception as e:
        if conn:
            conn.rollback()
        print(f"插入数据时发生错误: {str(e)}")
        raise
    finally:
        if conn:
            conn.close()
