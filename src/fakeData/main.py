import pandas as pd
from faker import Faker
import random
from datetime import datetime, timedelta
import pyodbc

import random

fake = Faker("zh_CN")


def generate_bookshelves(n=10):
    shelves = []
    used_codes = set()
    while len(shelves) < n:
        shelf_code = f"{random.choice(['A', 'B', 'C', 'D'])}{random.randint(1,20)}"
        if shelf_code in used_codes:
            continue  # 已存在，跳过，重新生成
        used_codes.add(shelf_code)
        location = fake.address()
        shelves.append({"ShelfCode": shelf_code, "Location": location})
    return shelves


def generate_books(shelves, n=50):
    books = []
    shelf_ids = list(range(1, len(shelves) + 1))
    for _ in range(n):
        book_name = fake.sentence(nb_words=4).rstrip(".")
        author = fake.name()
        isbn = fake.isbn13(separator="")
        price = round(random.uniform(10, 200), 2)
        inventory = random.randint(0, 20)
        picture = f"/images/{book_name+author}.jpg"
        shelf_id = random.choice(shelf_ids)
        books.append(
            {
                "BookName": book_name,
                "Author": author,
                "ISBN": isbn,
                "Price": price,
                "Inventory": inventory,
                "Picture": picture,
                "ShelfId": shelf_id,
            }
        )
    return books


def generate_users(n=10):
    base_time_str = datetime.now().strftime("%Y%m%d%H%M%S%f")[:16]
    users = []
    for i in range(n):
        card_num = f"{base_time_str}{i:03d}"  # 保证唯一
        user_name = fake.name()
        student_id = fake.bothify(text="???#####")  # 例如：ABC12345
        phone = fake.phone_number()
        user_class = fake.word().capitalize() + "班"
        photo = f"photos/{card_num.replace(' ', '_')}.jpg"
        start_time = datetime.now() - timedelta(days=fake.random_int(0, 365))
        ending_time = start_time + timedelta(days=365)
        users.append(
            {
                "CardNum": card_num,
                "UserName": user_name,
                "StudentID": student_id,
                "Phone": phone,
                "Class": user_class,
                "Photo": photo,
                "Start_Time": start_time.strftime("%Y-%m-%d %H:%M:%S"),
                "Ending_Time": ending_time.strftime("%Y-%m-%d %H:%M:%S"),
            }
        )
    return users


def generate_admins(n=5):
    admins = []
    roles = ["超级管理员", "图书管理员"]
    for _ in range(n):
        username = fake.user_name()
        pwd = fake.password(length=10)  # 实际项目中密码需加密存储
        phone = fake.phone_number()
        role = random.choice(roles)
        admins.append({"Username": username, "Pwd": pwd, "Phone": phone, "Type": role})
    return admins


def generate_borrows(users, books, admins, n=100):
    borrows = []
    user_ids = list(range(1, len(users) + 1))
    book_ids = list(range(1, len(books) + 1))
    admin_ids = list(range(1, len(admins) + 1))
    for _ in range(n):
        user_id = random.choice(user_ids)
        book_id = random.choice(book_ids)
        borrow_admin_id = random.choice(admin_ids)
        return_admin_id = random.choice(admin_ids)
        borrow_date = fake.date_time_between(start_date="-1y", end_date="now")
        if random.random() < 0.7:
            return_date = borrow_date + timedelta(days=random.randint(1, 60))
            if return_date > datetime.now():
                return_date = None
        else:
            return_date = None
        borrows.append(
            {
                "UserId": user_id,
                "BookId": book_id,
                "BorrowAdminId": borrow_admin_id,
                "ReturnAdminId": return_admin_id,
                "BorrowDate": borrow_date,
                "ReturnDate": return_date,
            }
        )
    return borrows


def save_to_excel(data_dict, filename="library_data.xlsx"):
    # data_dict = {"Bookshelf": [...], "Book": [...], "UserTable": [...], ...}
    with pd.ExcelWriter(filename) as writer:
        for sheet_name, data in data_dict.items():
            df = pd.DataFrame(data)
            df.to_excel(writer, sheet_name=sheet_name, index=False)
    print(f"数据已保存到 Excel 文件: {filename}")


def insert_into_sqlserver(data_dict, conn_str):
    conn = pyodbc.connect(conn_str)
    cursor = conn.cursor()

    # 先插入Bookshelf，获取生成的ShelfId（identity自增）
    cursor.fast_executemany = True

    # Bookshelf
    bookshelf_data = data_dict["Bookshelf"]
    cursor.executemany(
        "INSERT INTO Bookshelf (ShelfCode, Location) VALUES (?, ?)",
        [(x["ShelfCode"], x["Location"]) for x in bookshelf_data],
    )
    conn.commit()

    # 取出ShelfId和对应的ShelfCode，方便后续Book关联
    cursor.execute("SELECT ShelfId, ShelfCode FROM Bookshelf")
    shelf_map = {row.ShelfCode: row.ShelfId for row in cursor.fetchall()}

    # Book
    book_data = data_dict["Book"]
    # 替换ShelfId为数据库实际ID
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

    # 这里假设UserId, BookId, AdminId就是插入时自增的顺序（先后顺序）
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

    cursor.close()
    conn.close()
    print("数据已成功插入 SQL Server 数据库。")


if __name__ == "__main__":
    shelves = generate_bookshelves()
    books = generate_books(shelves)
    users = generate_users()
    admins = generate_admins()
    borrows = generate_borrows(users, books, admins)

    data = {
        "Bookshelf": shelves,
        "Book": books,
        "UserTable": users,
        "Admin": admins,
        "Borrow": borrows,
    }

    # save_to_excel(data, "library_data.xlsx")

    # 请改成你自己的SQL Server连接字符串
    conn_str = (
        "Driver={ODBC Driver 17 for SQL Server};"
        "Server=.\SQLEXPRESS;"
        "Database=LibrBook;"
        "Trusted_Connection=yes;"
    )

    insert_into_sqlserver(data, conn_str)
