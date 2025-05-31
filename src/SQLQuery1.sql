CREATE TABLE Bookshelf (
    ShelfId INT IDENTITY(1,1) PRIMARY KEY,                  -- ���ID������
    ShelfCode VARCHAR(20) NOT NULL UNIQUE,                  -- ��ܱ�ţ��� A1��B2
    Location NVARCHAR(100)                                  -- λ�����������硰��¥�Ҳࡱ
);


CREATE TABLE UserTable (
    UserId INT IDENTITY(1,1) PRIMARY KEY,                   -- ����ID������
    CardNum VARCHAR(50) NOT NULL UNIQUE,                    -- RFID ���ţ�Ψһʶ�����
    UserName NVARCHAR(50) NOT NULL,                         -- ����
    StudentID VARCHAR(20),                                  -- ѧ�ţ���ѡ��
    Phone VARCHAR(20),                                      -- �绰����
    Class NVARCHAR(50),                                     -- �༶/��λ
    Photo NVARCHAR(255),                                    -- ��Ƭ·����ͷ��
    Start_Time DATETIME NOT NULL,                           -- ע��ʱ��
    Ending_Time DATETIME                                    -- ��Ч��ֹʱ�䣨�����ڿ��ƽ���Ȩ�ޣ�
);

CREATE TABLE Admin (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,                  -- ����ԱID������
    Username NVARCHAR(50) NOT NULL UNIQUE,                  -- ��¼�˺ţ�Ψһ��
    Pwd NVARCHAR(255) NOT NULL,                             -- ��¼���루������ܴ洢��
    Phone VARCHAR(20),                                      -- ��ϵ��ʽ
    Type NVARCHAR(20)                                       -- ��ɫ���ͣ����硰��������Ա������ͼ�����Ա��
);

CREATE TABLE Book (
    BookId INT IDENTITY(1,1) PRIMARY KEY,                   -- ͼ��ID������
    BookName NVARCHAR(100) NOT NULL,                        -- ͼ������
    Author NVARCHAR(100),                                   -- ����
    ISBN VARCHAR(20) UNIQUE,                                -- ���ʱ�׼���
    Price DECIMAL(10,2),                                    -- ����
    Inventory INT NOT NULL DEFAULT 0,                       -- ��ǰ�������
    Picture NVARCHAR(255),                                  -- ͼ�����ͼƬ·�������·���� URL��
    ShelfId INT,                                            -- �����������ܱ��
    CONSTRAINT FK_Book_Shelf FOREIGN KEY (ShelfId)
        REFERENCES Bookshelf(ShelfId)                       -- ���Լ����������ܱ�
);


CREATE TABLE Borrow (
    BorrowId INT IDENTITY(1,1) PRIMARY KEY,                 -- ���ļ�¼ID������
    UserId INT NOT NULL,                                    -- �����������ID
    BookId INT NOT NULL,                                    -- �����ͼ��ID
    BorrowAdminId INT,                                      -- ������������Ĺ���ԱID
    ReturnAdminId INT,                                      -- �����������Ĺ���ԱID
    BorrowDate DATETIME NOT NULL,                           -- ���ʱ��
    ReturnDate DATETIME,                                    -- �黹ʱ�䣨δ�黹Ϊ NULL��
    FOREIGN KEY (UserId) REFERENCES UserTable(UserId),         -- ����߱����
    FOREIGN KEY (BookId) REFERENCES Book(BookId),           -- ��ͼ������
    FOREIGN KEY (BorrowAdminId) REFERENCES Admin(AdminId),  -- �����Ա�����
    FOREIGN KEY (ReturnAdminId) REFERENCES Admin(AdminId)   -- �����Ա�����
);