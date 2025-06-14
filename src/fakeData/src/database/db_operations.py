import pyodbc


def insert_into_sqlserver(data_dict, conn_str):
    """
    将数据插入到SQL Server数据库中
    """
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()
    cursor.fast_executemany = True

    try:
        # Bookshelf
        bookshelf_data = data_dict["Bookshelf"]
        cursor.executemany(
            "INSERT INTO Bookshelf (ShelfCode, Location) VALUES (?, ?)",
            [(x["ShelfCode"], x["Location"]) for x in bookshelf_data],
        )
        conn.commit()

        # 获取ShelfId映射
        cursor.execute("SELECT ShelfId, ShelfCode FROM Bookshelf")
        shelf_map = {row.ShelfCode: row.ShelfId for row in cursor.fetchall()}

        # Book
        book_data = data_dict["Book"]
        books_to_insert = []
        for book in book_data:
            shelf_id = book["ShelfId"]
            if isinstance(shelf_id, int):
                real_shelf_id = shelf_id
            else:
                real_shelf_id = shelf_map.get(shelf_id, None)
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
        cursor.executemany(
            """INSERT INTO Book (BookName, Author, ISBN, Price, Inventory, Picture, ShelfId)
               VALUES (?, ?, ?, ?, ?, ?, ?)""",
            books_to_insert,
        )
        conn.commit()

        # UserTable
        user_data = data_dict["UserTable"]
        cursor.executemany(
            """INSERT INTO UserTable 
            (CardNum, UserName, StudentID, Phone, Class, Photo, Start_Time, Ending_Time)
            VALUES (?, ?, ?, ?, ?, ?, ?, ?)""",
            [
                (
                    u["CardNum"],
                    u["UserName"],
                    u["StudentID"],
                    u["Phone"],
                    u["Class"],
                    u["Photo"],
                    u["Start_Time"],
                    u["Ending_Time"],
                )
                for u in user_data
            ],
        )
        conn.commit()

        # Admin
        admin_data = data_dict["Admin"]
        cursor.executemany(
            "INSERT INTO Admin (Username, Pwd, Phone, Type) VALUES (?, ?, ?, ?)",
            [(a["Username"], a["Pwd"], a["Phone"], a["Type"]) for a in admin_data],
        )
        conn.commit()

        # Borrow
        borrow_data = data_dict["Borrow"]
        cursor.executemany(
            """INSERT INTO Borrow
            (UserId, BookId, BorrowAdminId, ReturnAdminId, BorrowDate, ReturnDate)
            VALUES (?, ?, ?, ?, ?, ?)""",
            [
                (
                    b["UserId"],
                    b["BookId"],
                    b["BorrowAdminId"],
                    b["ReturnAdminId"],
                    b["BorrowDate"],
                    b["ReturnDate"],
                )
                for b in borrow_data
            ],
        )
        conn.commit()

        print("数据已成功插入 SQL Server 数据库。")

    except Exception as e:
        print(f"插入数据时发生错误: {str(e)}")
        conn.rollback()
        raise

    finally:
        cursor.close()
        conn.close()
