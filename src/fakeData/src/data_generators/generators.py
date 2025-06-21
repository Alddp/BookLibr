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
ROLES = ["管理员", "操作员"]


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


def generate_bookslots(shelves, n_per_shelf=18):
    """
    生成书架格子数据（BookSlot）
    每个书架 2 面（A/B），每面 9 层
    SlotCode: F01-R2-C3-A-05
    """
    slots = []
    slot_id = 1
    for idx, shelf in enumerate(shelves):
        shelf_id = idx + 1  # 假设插入顺序与生成顺序一致
        shelf_code = shelf["ShelfCode"]
        for face in ["A", "B"]:
            for level in range(1, 7):
                slot_code = f"{shelf_code}-{face}-{level:02d}"
                slots.append(
                    {
                        "ShelfId": shelf_id,
                        "Face": face,
                        "Level": level,
                        "SlotCode": slot_code,
                        "RFIDTag": None,
                    }
                )
                slot_id += 1
    return slots


def generate_bookshelfslots(n=10):
    """
    生成书架格子数据（BookShelfSlot）
    每个楼层、排、列、面、层组合生成一个格子
    SlotCode: F01-R2-C3-A-05
    """
    slots = []
    slot_id = 1
    # 假设 n 为总格子数，平均分配到楼层/排/列
    floors = [1, 2, 3]
    rows = range(1, 4)  # 可根据实际需求调整
    cols = range(1, 4)
    for floor in floors:
        for row in rows:
            for col in cols:
                for face in ["A", "B"]:
                    for level in range(1, 7):
                        slot_code = f"F{floor:02d}-R{row}-C{col}-{face}-{level:02d}"
                        slots.append(
                            {
                                "Floor": floor,
                                "RowNumber": row,
                                "ColumnNumber": col,
                                "Face": face,
                                "Level": level,
                                "SlotCode": slot_code,
                                "Location": f"{floor}楼{row}排{col}列{face}面第{level}层",
                            }
                        )
                        slot_id += 1
                        if len(slots) >= n:
                            return slots
    return slots


def generate_books(bookshelfslots, n=50):
    """
    生成图书数据
    BookId: 自增主键，不需要生成
    BookName: NVARCHAR(100) NOT NULL
    Author: NVARCHAR(100)
    ISBN: VARCHAR(20) UNIQUE
    Price: DECIMAL(10,2)
    Inventory: INT NOT NULL DEFAULT 0
    Picture: NVARCHAR(255)
    SlotId: INT (外键)
    """
    books = []
    slot_ids = list(range(1, len(bookshelfslots) + 1))
    book_names = [fake.sentence(nb_words=4).rstrip(".")[:100] for _ in range(n)]
    authors = [fake.name()[:100] for _ in range(n)]
    for i in range(n):
        books.append(
            {
                "BookName": book_names[i],
                "Author": authors[i],
                "ISBN": fake.isbn13(separator=""),
                "Price": round(random.uniform(10, 200), 2),
                "Inventory": random.randint(0, 20),
                "Picture": f"/images/{book_names[i]}{authors[i]}.jpg"[:255],
                "SlotId": random.choice(slot_ids),
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
    usernames = set()  # 使用集合来存储已生成的用户名
    while len(usernames) < n:
        username = fake.user_name()[:50]  # 限制长度在50以内
        if username not in usernames:  # 确保用户名唯一
            usernames.add(username)

    usernames = list(usernames)  # 转换回列表
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

    MIN_SQLSERVER_DATETIME = datetime(1753, 1, 1)
    # 预生成借阅日期
    borrow_dates = [
        fake.date_time_between(start_date="-1y", end_date="now") for _ in range(n)
    ]

    for i in range(n):
        borrow_date = borrow_dates[i]
        if borrow_date < MIN_SQLSERVER_DATETIME:
            borrow_date = MIN_SQLSERVER_DATETIME
        if random.random() < 0.7:
            return_date = borrow_date + timedelta(days=random.randint(1, 60))
            if return_date > datetime.now():
                return_date = None
            if return_date and return_date < MIN_SQLSERVER_DATETIME:
                return_date = MIN_SQLSERVER_DATETIME
        else:
            return_date = None
        borrows.append(
            {
                "UserId": random.choice(user_ids) if user_ids else None,
                "BookId": random.choice(book_ids) if book_ids else None,
                "BorrowAdminId": random.choice(admin_ids) if admin_ids else None,
                "ReturnAdminId": (
                    random.choice(admin_ids)
                    if admin_ids and random.random() < 0.5
                    else None
                ),
                "BorrowDate": borrow_date.strftime("%Y-%m-%d %H:%M:%S"),
                "ReturnDate": (
                    return_date.strftime("%Y-%m-%d %H:%M:%S") if return_date else None
                ),
            }
        )
    return borrows
