## 🧭 系统模块功能总览

**功能模块说明**

1. 用户管理 管理读者的注册、信息维护、RFID 绑定等
2. 图书管理 图书信息增删改查、库存维护、书架定位等
3. 借阅管理 借书、还书、续借、超期管理等
4. RFID 接口 实时识别 RFID 卡或标签，自动完成借还
5. 管理员系统 登录、权限管理
6. 统计报表 借阅排行、超期统计、图书库存分析
7. 系统设置 数据备份、参数设置、导入导出
8. UI 美化 WPF 动效、图形报表、图书封面展示等

## 窗口进度

- [x] 登录窗口
- [x] 注册窗口
- [x] 开卡窗口
- [x] 借书窗口
- [x] 还书窗口
- [x] 书本入库窗口

## 🔍 各模块详细功能进度

### 1️⃣ 用户（读者）管理

- [x] 添加/修改/删除读者信息
- [x] 绑定/更新 RFID 卡号
- [x] 查看借阅记录
- [x] 设置有效期（如毕业时间）
- [x] 照片上传（用于身份确认）

### 2️⃣ 图书管理

- [x] 新增图书信息（书名、作者、ISBN、封面等）
- [ ] 图书图片上传与展示
- [ ] 设置书架位置（与 Bookshelf 表关联）
- [ ] 修改库存数量
- [x] 模糊查询（书名、作者、ISBN）

### 3️⃣ 借阅管理

- [x] 读卡识别 → 自动加载读者信息
- [ ] 扫描图书（RFID 或手动）→ 自动借书
- [x] 还书操作（自动识别图书 → 归还）
- [ ] 续借操作
- [ ] 超期提醒与处理
- [ ] 借阅次数、未还书数量统计

### 4️⃣ RFID 功能支持

- [x] 读卡器串口
- [x] 读者卡识别（借阅人）
- [ ] 图书标签识别（借阅图书）

### 5️⃣ 管理员功能

- [x] 管理员登录
- [x] 不同权限等级（如“图书管理员”、“系统管理员”）
- [ ] 管理员借书/还书记录归档

### 6️⃣ 统计与报表（可视化）

- [ ] 热门借阅图书排行（柱状图）
- [ ] 借阅频次统计（按日/月/年）
- [ ] 超期图书列表
- [ ] 图书库存一览（可按类别、书架分组）

### 7️⃣ 系统设置

- [x] RFID 参数设置（串口、波特率）
- [ ] 界面主题设置（黑/白模式）
- [ ] 图书批量导入（Excel）

### 8️⃣ UI 展示与体验（WPF 特有）

- [ ] 现代化界面（MVVM 结构）
- [ ] 动画按钮 / 滑动面板
- [ ] 书籍封面缩略图展示
- [ ] 实时时钟、欢迎语等交互元素

## 数据库结构

### 📚 `Book` 图书表：记录图书的基本信息及存放位置

```sql
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
```

---

### 🗄️ `Bookshelf` 书架表：记录图书所在物理位置

```sql
CREATE TABLE Bookshelf (
    ShelfId INT IDENTITY(1,1) PRIMARY KEY,                  -- 书架ID，主键
    ShelfCode VARCHAR(20) NOT NULL UNIQUE,                  -- 书架编号，如 A1、B2
    Location NVARCHAR(100)                                  -- 位置描述，例如“二楼右侧”
);
```

---

### 👤 `User` 读者表：记录读者基本信息及 RFID 卡

```sql
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
```

---

### 🛠 `Admin` 管理员表：用于登录管理系统

```sql
CREATE TABLE Admin (
    AdminId INT IDENTITY(1,1) PRIMARY KEY,                  -- 管理员ID，主键
    Username NVARCHAR(50) NOT NULL UNIQUE,                  -- 登录账号（唯一）
    Pwd NVARCHAR(255) NOT NULL,                             -- 登录密码（建议加密存储）
    Phone VARCHAR(20),                                      -- 联系方式
    Type NVARCHAR(20)                                       -- 角色类型，例如“超级管理员”、“图书管理员”
);
```

---

### 📄 `Borrow` 借阅记录表：记录图书借还情况

```sql
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
```

---
