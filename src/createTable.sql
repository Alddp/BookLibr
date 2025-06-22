CREATE TABLE Reader (
    UserId INT IDENTITY(1,1) PRIMARY KEY,                   -- ����ID������
    CardNum VARCHAR(50) NOT NULL UNIQUE,                    -- RFID ���ţ�Ψһʶ�����
    UserName NVARCHAR(50) NOT NULL,                         -- ����
    StudentID VARCHAR(20),                                  -- ѧ�ţ���ѡ��
    Phone VARCHAR(20),                                      -- �绰����
    Class NVARCHAR(50),                                     -- �༶/��λ
    Photo NVARCHAR(255),                                    -- ��Ƭ·����ͷ��
    Start_Time DATETIME NOT NULL,                           -- ע��ʱ��
    Ending_Time DATETIME,                                   -- ��Ч��ֹʱ��
    IsActive BIT NOT NULL DEFAULT 1                         -- �����Ƿ���Ч
);

CREATE TABLE Admin (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,                  -- ����ԱID������
    Username NVARCHAR(50) NOT NULL UNIQUE,                  -- ��¼�˺ţ�Ψһ��
    Pwd NVARCHAR(255) NOT NULL,                             -- ��¼���루������ܴ洢��
    Phone VARCHAR(20),                                      -- ��ϵ��ʽ
    Type NVARCHAR(20)                                       -- ��ɫ���ͣ�����"��������Ա"��"ͼ�����Ա"
);

CREATE TABLE BookShelfSlot (
    SlotId INT IDENTITY(1,1) PRIMARY KEY,                   -- ��λID������
    Floor INT NOT NULL,                                     -- ¥�㣨1~3��
    RowNumber INT NOT NULL,                                 -- ��
    ColumnNumber INT NOT NULL,                              -- ��
    Face CHAR(1) NOT NULL CHECK (Face IN ('A','B')),        -- A���B��
    Level INT NOT NULL CHECK (Level BETWEEN 1 AND 9),       -- �ڼ������
    SlotCode VARCHAR(30) UNIQUE NOT NULL,                   -- ��ܸ��ӱ�ţ��� F01-R2-C3-A-05
    Location NVARCHAR(100)                                  -- �ɶ�λ������
);

CREATE TABLE Book (
    BookId INT IDENTITY(1,1) PRIMARY KEY,                   -- ͼ��ID������
    BookName NVARCHAR(100) NOT NULL,                        -- ͼ������
    Author NVARCHAR(100),                                   -- ����
    ISBN VARCHAR(20) UNIQUE,                                -- ���ʱ�׼���
    Price DECIMAL(10,2),                                    -- ����
    Inventory INT NOT NULL DEFAULT 0,                       -- ��ǰ�������
    Picture NVARCHAR(255),                                  -- ͼ�����ͼƬ·��
    SlotId INT,                                             -- ��������ھ����λ
    CONSTRAINT FK_Book_Slot FOREIGN KEY (SlotId) REFERENCES BookShelfSlot(SlotId)
);

CREATE TABLE Borrow (
    BorrowId INT IDENTITY(1,1) PRIMARY KEY,                 -- ���ļ�¼ID������
    UserId INT NOT NULL,                                    -- �����������ID
    BookId INT NOT NULL,                                    -- �����ͼ��ID
    BorrowAdminId INT,                                      -- ������������Ĺ���ԱID
    ReturnAdminId INT,                                      -- �����������Ĺ���ԱID
    BorrowDate DATETIME NOT NULL,                           -- ���ʱ��
    ReturnDate DATETIME,                                    -- �黹ʱ�䣨δ�黹Ϊ NULL��
    CONSTRAINT FK_Borrow_Reader FOREIGN KEY (UserId) REFERENCES Reader(UserId),
    CONSTRAINT FK_Borrow_Book FOREIGN KEY (BookId) REFERENCES Book(BookId),
    CONSTRAINT FK_Borrow_Admin_Borrow FOREIGN KEY (BorrowAdminId) REFERENCES Admin(AdminId),
    CONSTRAINT FK_Borrow_Admin_Return FOREIGN KEY (ReturnAdminId) REFERENCES Admin(AdminId)
);