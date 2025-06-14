from faker import Faker
import random
from datetime import datetime, timedelta

fake = Faker("zh_CN")

# 预生成一些常用数据
SHELF_CODES = [
    f"{letter}{num:02d}"
    for letter in ["A", "B", "C", "D", "E", "F", "G", "H"]
    for num in range(1, 26)
]
ROLES = ["超级管理员", "图书管理员"]


def generate_bookshelves(n=10):
    """生成书架数据
    ShelfId: 自增主键，不需要生成
    ShelfCode: VARCHAR(20) NOT NULL UNIQUE
    Location: NVARCHAR(100)
    """
    shelves = []
    # 如果请求的书架数量超过预生成的编号数量，就动态生成
    if n > len(SHELF_CODES):
        # 生成额外的书架编号
        extra_codes = []
        letters = [
            "I",
            "J",
            "K",
            "L",
            "M",
            "N",
            "O",
            "P",
            "Q",
            "R",
            "S",
            "T",
            "U",
            "V",
            "W",
            "X",
            "Y",
            "Z",
        ]
        for letter in letters:
            for num in range(1, 26):
                extra_codes.append(f"{letter}{num:02d}")
        all_codes = SHELF_CODES + extra_codes
        selected_codes = random.sample(all_codes, n)
    else:
        selected_codes = random.sample(SHELF_CODES, n)

    for shelf_code in selected_codes:
        location = fake.address()[:100]  # 限制长度在100以内
        shelves.append({"ShelfCode": shelf_code, "Location": location})
    return shelves


def generate_books(shelves, n=50):
    """生成图书数据
    BookId: 自增主键，不需要生成
    BookName: NVARCHAR(100) NOT NULL
    Author: NVARCHAR(100)
    ISBN: VARCHAR(20) UNIQUE
    Price: DECIMAL(10,2)
    Inventory: INT NOT NULL DEFAULT 0
    Picture: NVARCHAR(255)
    ShelfId: INT (外键)
    """
    books = []
    shelf_ids = list(range(1, len(shelves) + 1))
    # 预生成一些书名和作者
    book_names = [
        fake.sentence(nb_words=4).rstrip(".")[:100] for _ in range(n)
    ]  # 限制长度在100以内
    authors = [fake.name()[:100] for _ in range(n)]  # 限制长度在100以内

    for i in range(n):
        books.append(
            {
                "BookName": book_names[i],
                "Author": authors[i],
                "ISBN": fake.isbn13(separator=""),  # 确保是唯一的ISBN
                "Price": round(random.uniform(10, 200), 2),  # 保留两位小数
                "Inventory": random.randint(0, 20),
                "Picture": f"/images/{book_names[i]}{authors[i]}.jpg"[
                    :255
                ],  # 限制长度在255以内
                "ShelfId": random.choice(shelf_ids),
            }
        )
    return books


def generate_users(n=10):
    """生成用户数据
    UserId: 自增主键，不需要生成
    CardNum: VARCHAR(50) NOT NULL UNIQUE
    UserName: NVARCHAR(50) NOT NULL
    StudentID: VARCHAR(20)
    Phone: VARCHAR(20)
    Class: NVARCHAR(50)
    Photo: NVARCHAR(255)
    Start_Time: DATETIME NOT NULL
    Ending_Time: DATETIME
    """
    base_time_str = datetime.now().strftime("%Y%m%d%H%M%S%f")[:16]
    users = []
    # 预生成一些用户数据
    names = [fake.name()[:50] for _ in range(n)]  # 限制长度在50以内
    student_ids = [
        fake.bothify(text="???#####")[:20] for _ in range(n)
    ]  # 限制长度在20以内
    phones = [fake.phone_number()[:20] for _ in range(n)]  # 限制长度在20以内
    classes = [
        (fake.word().capitalize() + "班")[:50] for _ in range(n)
    ]  # 限制长度在50以内

    for i in range(n):
        card_num = f"{base_time_str}{i:03d}"[:50]  # 限制长度在50以内
        start_time = datetime.now() - timedelta(days=fake.random_int(0, 365))
        ending_time = start_time + timedelta(days=365)
        users.append(
            {
                "CardNum": card_num,
                "UserName": names[i],
                "StudentID": student_ids[i],
                "Phone": phones[i],
                "Class": classes[i],
                "Photo": f"photos/{card_num.replace(' ', '_')}.jpg"[
                    :255
                ],  # 限制长度在255以内
                "Start_Time": start_time.strftime("%Y-%m-%d %H:%M:%S"),
                "Ending_Time": ending_time.strftime("%Y-%m-%d %H:%M:%S"),
            }
        )
    return users


def generate_admins(n=5):
    """生成管理员数据
    AdminId: 自增主键，不需要生成
    Username: NVARCHAR(50) NOT NULL UNIQUE
    Pwd: NVARCHAR(255) NOT NULL
    Phone: VARCHAR(20)
    Type: NVARCHAR(20)
    """
    admins = []
    # 预生成管理员数据
    usernames = [fake.user_name()[:50] for _ in range(n)]  # 限制长度在50以内
    passwords = [fake.password(length=10)[:255] for _ in range(n)]  # 限制长度在255以内
    phones = [fake.phone_number()[:20] for _ in range(n)]  # 限制长度在20以内

    for i in range(n):
        admins.append(
            {
                "Username": usernames[i],
                "Pwd": passwords[i],
                "Phone": phones[i],
                "Type": random.choice(ROLES)[:20],  # 限制长度在20以内
            }
        )
    return admins


def generate_borrows(users, books, admins, n=100):
    """生成借阅记录数据
    BorrowId: 自增主键，不需要生成
    UserId: INT NOT NULL (外键)
    BookId: INT NOT NULL (外键)
    BorrowAdminId: INT (外键)
    ReturnAdminId: INT (外键)
    BorrowDate: DATETIME NOT NULL
    ReturnDate: DATETIME
    """
    borrows = []
    user_ids = list(range(1, len(users) + 1))
    book_ids = list(range(1, len(books) + 1))
    admin_ids = list(range(1, len(admins) + 1))

    # 预生成借阅日期
    borrow_dates = [
        fake.date_time_between(start_date="-1y", end_date="now") for _ in range(n)
    ]

    for i in range(n):
        borrow_date = borrow_dates[i]
        if random.random() < 0.7:
            return_date = borrow_date + timedelta(days=random.randint(1, 60))
            if return_date > datetime.now():
                return_date = None
        else:
            return_date = None

        borrows.append(
            {
                "UserId": random.choice(user_ids),
                "BookId": random.choice(book_ids),
                "BorrowAdminId": random.choice(admin_ids),
                "ReturnAdminId": random.choice(admin_ids),
                "BorrowDate": borrow_date,
                "ReturnDate": return_date,
            }
        )
    return borrows
