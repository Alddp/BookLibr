
CREATE TABLE UserTable (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    CardNum VARCHAR(50) NOT NULL UNIQUE,         -- RFID卡号
    UserName NVARCHAR(50) NOT NULL,
    StudentID VARCHAR(20),
    Phone VARCHAR(20),
    Class NVARCHAR(50),
    Photo NVARCHAR(255),                         -- 照片路径
    Start_Time DATETIME NOT NULL,
    Ending_Time DATETIME
);

CREATE TABLE Admin (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,       -- 原名“Char”，已更正
    Pwd NVARCHAR(255) NOT NULL,                  -- 存储加密密码
    Phone VARCHAR(20),
    Type NVARCHAR(20)                            -- 管理员类型
);

CREATE TABLE Book (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    BookName NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100),
    Inventory INT NOT NULL DEFAULT 0,            -- 当前库存
    Picture NVARCHAR(255),                       -- 图片路径
    ISBN VARCHAR(20) UNIQUE,
    Price DECIMAL(10,2)
);

CREATE TABLE Bookshelf (
    ShelfId INT IDENTITY(1,1) PRIMARY KEY,                  -- 书架ID，主键
    ShelfCode VARCHAR(20) NOT NULL UNIQUE,                  -- 书架编号，如 A1、B2
    Location NVARCHAR(100)                                  -- 位置描述，例如“二楼右侧”
);


CREATE TABLE Borrow (
    BorrowId INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    BookId INT NOT NULL,
    BorrowAdminId INT,
    ReturnAdminId INT,
    BorrowDate DATETIME NOT NULL,
    ReturnDate DATETIME,

    FOREIGN KEY (UserId) REFERENCES UserTable(UserId),
    FOREIGN KEY (BookId) REFERENCES Book(BookId),
    FOREIGN KEY (BorrowAdminId) REFERENCES Admin(AdminId),
    FOREIGN KEY (ReturnAdminId) REFERENCES Admin(AdminId)
);
