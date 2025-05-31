CREATE TABLE Bookshelf (
    ShelfId INT IDENTITY(1,1) PRIMARY KEY,                  -- 书架ID，主键
    ShelfCode VARCHAR(20) NOT NULL UNIQUE,                  -- 书架编号，如 A1、B2
    Location NVARCHAR(100)                                  -- 位置描述，例如“二楼右侧”
);


CREATE TABLE UserTable (
    UserId INT IDENTITY(1,1) PRIMARY KEY,                   -- 读者ID，主键
    CardNum VARCHAR(50) NOT NULL UNIQUE,                    -- RFID 卡号，唯一识别读者
    UserName NVARCHAR(50) NOT NULL,                         -- 姓名
    StudentID VARCHAR(20),                                  -- 学号（可选）
    Phone VARCHAR(20),                                      -- 电话号码
    Class NVARCHAR(50),                                     -- 班级/单位
    Photo NVARCHAR(255),                                    -- 照片路径（头像）
    Start_Time DATETIME NOT NULL,                           -- 注册时间
    Ending_Time DATETIME                                    -- 有效截止时间（可用于控制借阅权限）
);

CREATE TABLE Admin (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,                  -- 管理员ID，主键
    Username NVARCHAR(50) NOT NULL UNIQUE,                  -- 登录账号（唯一）
    Pwd NVARCHAR(255) NOT NULL,                             -- 登录密码（建议加密存储）
    Phone VARCHAR(20),                                      -- 联系方式
    Type NVARCHAR(20)                                       -- 角色类型，例如“超级管理员”、“图书管理员”
);

CREATE TABLE Book (
    BookId INT IDENTITY(1,1) PRIMARY KEY,                   -- 图书ID，主键
    BookName NVARCHAR(100) NOT NULL,                        -- 图书名称
    Author NVARCHAR(100),                                   -- 作者
    ISBN VARCHAR(20) UNIQUE,                                -- 国际标准书号
    Price DECIMAL(10,2),                                    -- 单价
    Inventory INT NOT NULL DEFAULT 0,                       -- 当前库存数量
    Picture NVARCHAR(255),                                  -- 图书封面图片路径（相对路径或 URL）
    ShelfId INT,                                            -- 外键，所在书架编号
    CONSTRAINT FK_Book_Shelf FOREIGN KEY (ShelfId)
        REFERENCES Bookshelf(ShelfId)                       -- 外键约束：关联书架表
);


CREATE TABLE Borrow (
    BorrowId INT IDENTITY(1,1) PRIMARY KEY,                 -- 借阅记录ID，主键
    UserId INT NOT NULL,                                    -- 外键：借书人ID
    BookId INT NOT NULL,                                    -- 外键：图书ID
    BorrowAdminId INT,                                      -- 外键：办理借书的管理员ID
    ReturnAdminId INT,                                      -- 外键：办理还书的管理员ID
    BorrowDate DATETIME NOT NULL,                           -- 借出时间
    ReturnDate DATETIME,                                    -- 归还时间（未归还为 NULL）
    FOREIGN KEY (UserId) REFERENCES UserTable(UserId),         -- 与读者表关联
    FOREIGN KEY (BookId) REFERENCES Book(BookId),           -- 与图书表关联
    FOREIGN KEY (BorrowAdminId) REFERENCES Admin(AdminId),  -- 与管理员表关联
    FOREIGN KEY (ReturnAdminId) REFERENCES Admin(AdminId)   -- 与管理员表关联
);