
CREATE TABLE UserTable (
    UserId INT IDENTITY(1,1) PRIMARY KEY,
    CardNum VARCHAR(50) NOT NULL UNIQUE,         -- RFID����
    UserName NVARCHAR(50) NOT NULL,
    StudentID VARCHAR(20),
    Phone VARCHAR(20),
    Class NVARCHAR(50),
    Photo NVARCHAR(255),                         -- ��Ƭ·��
    Start_Time DATETIME NOT NULL,
    Ending_Time DATETIME
);

CREATE TABLE Admin (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,
    Username NVARCHAR(50) NOT NULL UNIQUE,       -- ԭ����Char�����Ѹ���
    Pwd NVARCHAR(255) NOT NULL,                  -- �洢��������
    Phone VARCHAR(20),
    Type NVARCHAR(20)                            -- ����Ա����
);

CREATE TABLE Book (
    BookId INT IDENTITY(1,1) PRIMARY KEY,
    BookName NVARCHAR(100) NOT NULL,
    Author NVARCHAR(100),
    Inventory INT NOT NULL DEFAULT 0,            -- ��ǰ���
    Picture NVARCHAR(255),                       -- ͼƬ·��
    ISBN VARCHAR(20) UNIQUE,
    Price DECIMAL(10,2)
);

CREATE TABLE Bookshelf (
    ShelfId INT IDENTITY(1,1) PRIMARY KEY,                  -- ���ID������
    ShelfCode VARCHAR(20) NOT NULL UNIQUE,                  -- ��ܱ�ţ��� A1��B2
    Location NVARCHAR(100)                                  -- λ�����������硰��¥�Ҳࡱ
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
