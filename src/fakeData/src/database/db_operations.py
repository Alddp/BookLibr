import pyodbc
import pandas as pd
from datetime import datetime, timedelta
import random


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
            "BookShelfSlot": 0,
            "Book": 0,
            "Reader": 0,
            "Admin": 0,
            "Borrow": 0,
        }

        # 插入书架格子数据
        if "BookShelfSlot" in data_dict:
            slots = data_dict["BookShelfSlot"]

            # 如果是DataFrame，转换为字典列表
            if isinstance(slots, pd.DataFrame):
                slots = slots.to_dict("records")

            print(f"Debug: BookShelfSlot data type: {type(slots)}")
            print(f"Debug: Number of slots: {len(slots) if slots else 0}")
            if slots:
                print(f"Debug: First slot type: {type(slots[0])}")
                print(f"Debug: First slot: {slots[0]}")

            for slot in slots:
                try:
                    print(f"Debug: Processing slot: {slot}")
                    print(f"Debug: Slot type: {type(slot)}")
                    if isinstance(slot, str):
                        print(f"Debug: Slot is a string: {slot}")
                        continue

                    cursor.execute(
                        """
                        INSERT INTO BookShelfSlot (Floor, RowNumber, ColumnNumber, Face, Level, SlotCode, Location)
                        VALUES (?, ?, ?, ?, ?, ?, ?)
                        """,
                        slot["Floor"],
                        slot["RowNumber"],
                        slot["ColumnNumber"],
                        slot["Face"],
                        slot["Level"],
                        slot["SlotCode"],
                        slot["Location"],
                    )
                    inserted_counts["BookShelfSlot"] += 1
                except pyodbc.IntegrityError:
                    print(f"警告: 格子编码 {slot['SlotCode']} 已存在，跳过插入")
                    continue
                except Exception as e:
                    print(f"插入书架格子时发生错误: {str(e)}")
                    print(f"Slot data: {slot}")
                    raise

        # 获取所有格子ID映射
        cursor.execute("SELECT SlotId, SlotCode FROM BookShelfSlot")
        slot_map = {row.SlotCode: row.SlotId for row in cursor.fetchall()}
        valid_slot_ids = set(slot_map.values())

        # 插入图书数据
        if "Book" in data_dict:
            books = data_dict["Book"]

            # 如果是DataFrame，转换为字典列表
            if isinstance(books, pd.DataFrame):
                books = books.to_dict("records")

            for book in books:
                try:
                    # 检查 SlotId 是否存在
                    slot_id = book["SlotId"]
                    if not isinstance(slot_id, int):
                        slot_id = slot_map.get(slot_id)
                    if slot_id not in valid_slot_ids:
                        print(
                            f"警告: 图书 {book['BookName']} 的格子ID {slot_id} 不存在，设置为NULL"
                        )
                        slot_id = None
                    cursor.execute(
                        """
                        INSERT INTO Book (BookName, Author, ISBN, Price, Inventory, Picture, SlotId)
                        VALUES (?, ?, ?, ?, ?, ?, ?)
                        """,
                        book["BookName"],
                        book["Author"],
                        book["ISBN"],
                        book["Price"],
                        book["Inventory"],
                        book["Picture"],
                        slot_id,
                    )
                    inserted_counts["Book"] += 1
                except pyodbc.IntegrityError:
                    print(f"警告: ISBN {book['ISBN']} 已存在，跳过插入")
                    continue

        # 插入用户数据
        if "Reader" in data_dict:
            users = data_dict["Reader"]

            # 如果是DataFrame，转换为字典列表
            if isinstance(users, pd.DataFrame):
                users = users.to_dict("records")

            for user in users:
                try:
                    cursor.execute(
                        """
                        INSERT INTO Reader (CardNum, UserName, StudentID, Phone, Class, Photo, Start_Time, Ending_Time)
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
                    inserted_counts["Reader"] += 1
                except Exception as e:
                    print(f"警告: 卡号 {user['CardNum']} 已存在，跳过插入")

        # 插入管理员数据
        if "Admin" in data_dict:
            admins = data_dict["Admin"]

            # 如果是DataFrame，转换为字典列表
            if isinstance(admins, pd.DataFrame):
                admins = admins.to_dict("records")

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
        cursor.execute("SELECT UserId FROM Reader")
        valid_user_ids = {row.UserId for row in cursor.fetchall()}

        cursor.execute("SELECT BookId FROM Book")
        valid_book_ids = {row.BookId for row in cursor.fetchall()}

        cursor.execute("SELECT AdminId FROM Admin")
        valid_admin_ids = {row.AdminId for row in cursor.fetchall()}

        # 插入借阅记录数据
        if "Borrow" in data_dict:
            borrows = data_dict["Borrow"]

            # 如果是DataFrame，转换为字典列表
            if isinstance(borrows, pd.DataFrame):
                borrows = borrows.to_dict("records")

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
