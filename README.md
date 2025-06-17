# BookLiber 图书管理系统

BookLiber 是一个基于 C# WinForms 开发的图书管理系统，采用三层架构设计，提供完整的图书管理功能。

## 目录

1. [系统架构](#系统架构)
2. [功能模块](#功能模块)
3. [技术实现](#技术实现)
4. [数据库设计](#数据库设计)
5. [开发环境](#开发环境)
6. [使用说明](#使用说明)
7. [开发进度](#开发进度)
8. [注意事项](#注意事项)
9. [许可证](#许可证)

## 系统架构

### 1. 整体架构

- 采用经典三层架构：表现层(UI)、业务逻辑层(BLL)、数据访问层(DAL)
- 使用实体层(Models)进行数据封装和业务规则定义
- 采用 SQL Server 数据库存储数据
- 使用 ADO.NET 进行数据访问

### 2. 项目结构

```
BookLiber/
├── BookLiber/              # 主项目
│   ├── MainForm.cs        # 主窗体
│   ├── LoginForm.cs       # 登录窗体
│   ├── RegisterForm.cs    # 注册窗体
│   └── SubForm/           # 子窗体目录
├── BookModels/            # 领域模型层
│   ├── Entities/          # 实体类
│   ├── Constants/         # 常量定义
│   └── Errors/           # 错误处理
├── BookBLL/              # 业务逻辑层
│   ├── CardManager.cs    # 卡管理
│   ├── ReaderManager.cs  # 读者管理
│   └── BookManager.cs    # 图书管理
├── BookDAL/              # 数据访问层
└── BookHardWare/         # 硬件接口层
```

## 功能模块

### 1. 用户管理

- [x] 添加/修改/删除读者信息
- [x] 绑定/更新 RFID 卡号
- [x] 查看借阅记录
- [x] 设置有效期（如毕业时间）
- [x] 照片上传（用于身份确认）

### 2. 图书管理

- [x] 新增图书信息（书名、作者、ISBN、封面等）
- [x] 图书图片上传与展示
- [ ] 设置书架位置（与 Bookshelf 表关联）
- [ ] 修改库存数量
- [x] 模糊查询（书名、作者、ISBN）

### 3. 借阅管理

- [x] 读卡识别 → 自动加载读者信息
- [ ] 扫描图书（RFID 或手动）→ 自动借书
- [x] 还书操作（自动识别图书 → 归还）
- [ ] 续借操作
- [ ] 超期提醒与处理
- [ ] 借阅次数、未还书数量统计

### 4. RFID 功能

- [x] 读卡器串口通信
- [x] 读者卡识别（借阅人）
- [ ] 图书标签识别（借阅图书）

### 5. 管理员功能

- [x] 管理员登录
- [x] 不同权限等级（如"图书管理员"、"系统管理员"）
- [x] 管理员借书/还书记录归档

### 6. 统计报表

- [x] 热门借阅图书排行
- [ ] 借阅频次统计（按日/月/年）
- [ ] 超期图书列表
- [ ] 图书库存一览（可按类别、书架分组）

### 7. 系统设置

- [x] RFID 参数设置（串口、波特率）
- [ ] 界面主题设置（黑/白模式）
- [x] 图书批量导入（Excel）

## 技术实现

### 1. 分层架构

系统采用五层架构设计，在传统三层架构的基础上增加了模型层和硬件接口层：

#### 1.1 表现层 (BookLiber)

- 基于 WinForms 开发
- 使用 MaterialSkin 实现现代化 UI
- 实现用户界面交互
- 提供数据展示和操作界面
- 实现用户输入验证

#### 1.2 业务逻辑层 (BookBLL)

- 实现核心业务逻辑
- 提供业务规则验证
- 处理业务异常
- 管理事务处理
- 调用硬件接口层进行 RFID 操作

#### 1.3 数据访问层 (BookDAL)

- 使用 ADO.NET 实现数据访问
- 采用存储过程进行数据操作
- 实现数据访问接口隔离
- 提供统一的数据访问接口

#### 1.4 模型层 (BookModels)

- 定义业务实体类
- 提供数据验证规则
- 定义业务常量
- 实现错误处理机制
- 提供统一的返回结构

#### 1.5 硬件接口层 (BookHardWare)

- 封装 RFID 读卡器操作
- 提供串口通信接口
- 实现硬件设备管理
- 处理硬件异常

### 2. 设计模式应用

#### 2.1 单例模式

```csharp
// MaterialSkinManager 单例
materialSkinManager = MaterialSkinManager.Instance;

// Reader 单例
Reader.Instance = sutInfoRes.Data;
```

#### 2.2 工厂模式

```csharp
// 窗体创建工厂
private void InitializeForms() {
    forms = new Dictionary<string, Form> {
        { "readCard", new ReadCardForm() },
        { "borrow", new BorrowForm() },
        { "return", new ReturnForm() },
        { "card", new CardForm() },
        { "addBook", new AddBookForm() }
    };
}
```

#### 2.3 观察者模式

```csharp
// 窗体切换观察者
private void materialTabControl1_SelectedIndexChanged(object sender, EventArgs e) {
    HideAllForms();
    switch (materialTabControl1.SelectedIndex) {
        case 0:  // 卡管理标签页
            ShowForm("readCard");
            break;
        case 1:  // 借阅管理标签页
            ShowForm("borrow");
            break;
        case 2:  // 图书管理标签页
            ShowForm("addBook");
            break;
    }
}
```

#### 2.4 依赖注入

```csharp
public class ReadCardForm : MaterialForm {
    private readonly MaterialSkinManager materialSkinManager;

    public ReadCardForm() {
        InitializeComponent();
        materialSkinManager = MaterialSkinManager.Instance;
    }
}
```

### 3. 统一返回结构

系统使用统一的返回结构 `OperationResult<T>` 处理所有操作结果：

```csharp
public class OperationResult<T> {
    public bool Success { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }
    public int ErrorCode { get; set; }
}
```

使用示例：

```csharp
// 成功返回
return new OperationResult<Reader> {
    Success = true,
    Message = "获取读者信息成功",
    Data = reader
};

// 错误返回
return new OperationResult<Reader> {
    Success = false,
    Message = "未找到读者信息",
    ErrorCode = ErrorCodes.READER_NOT_FOUND
};
```

### 4. 包装器模式

系统使用包装器模式封装底层操作：

#### 4.1 数据库操作包装器

```csharp
public class DbWrapper {
    public static OperationResult<T> ExecuteQuery<T>(string sql, params SqlParameter[] parameters) {
        // 执行数据库查询
    }

    public static OperationResult<int> ExecuteNonQuery(string sql, params SqlParameter[] parameters) {
        // 执行数据库更新
    }
}
```

#### 4.2 RFID 操作包装器

```csharp
public class RfidWrapper {
    public static OperationResult<string> ReadCard() {
        // 读取 RFID 卡
    }

    public static OperationResult<bool> WriteCard(string data) {
        // 写入 RFID 卡
    }
}
```

### 5. 工具类 (Utils)

系统提供了多个工具类来简化开发：

#### 5.1 结果包装器 (ResultWrapper)

```csharp
public static class ResultWrapper {
    // 封装带返回值的操作（如查询、登录等）
    public static OperationResult<TData> Wrap<TData>(Func<TData> func) {
        try {
            TData result = func();
            return OperationResult<TData>.Ok(result);
        }
        catch (SqlException ex) {
            if (IsConflictError(ex))
                return OperationResult<TData>.Fail(
                    ErrorCode.DuplicateKey,
                    GetMessage(ErrorCode.DuplicateKey, ex.Message));
            return OperationResult<TData>.Fail(
                ErrorCode.DatabaseError,
                GetMessage(ErrorCode.DatabaseError, ex.Message));
        }
        catch (Exception ex) {
            return OperationResult<TData>.Fail(
                ErrorCode.UnknownError,
                GetMessage(ErrorCode.UnknownError, ex.Message));
        }
    }
}
```

#### 5.2 SQL 错误映射器 (SqlErrorMapper)

```csharp
public static class SqlErrorMapper {
    public static ErrorCode Map(SqlException ex) {
        switch (ex.Number) {
            case 2627:
                return ErrorCode.DuplicateKey; // 主键/唯一键冲突
            case 2601:
                return ErrorCode.DuplicateKey; // 唯一索引冲突
            case 547:
                return ErrorCode.ForeignKeyViolation; //外键冲突
        }
        return ErrorCode.DatabaseError; // 数据库错误
    }
}
```

### 6. 错误处理机制

系统实现了统一的错误处理机制：

```csharp
public enum ErrorCode {
    // 通用
    None = 0,                    // 操作成功，无错误
    UnknownError,                // 系统发生未知错误
    InvalidParameter,            // 参数格式无效
    DatabaseError,               // 数据库操作异常
    DuplicateKey,                // 数据重复违反唯一约束
    NotFound,                    // 未找到相关数据
    Unauthorized,                // 用户未授权
    Forbidden,                   // 禁止访问此资源
    Timeout,                     // 操作超时，请重试
    OperationFailed,             // 操作执行失败
    ForeignKeyViolation,         // 外键约束违反
    ...
}


private static readonly Dictionary<ErrorCode, string> _messages = new Dictionary<ErrorCode, string>(){
    // 通用错误
    { ErrorCode.None, "操作成功" },
    { ErrorCode.UnknownError, "系统发生未知错误" },
    { ErrorCode.InvalidParameter, "参数格式无效" },
    { ErrorCode.DatabaseError, "数据库操作异常" },
    { ErrorCode.DuplicateKey, "数据重复违反唯一约束" },
    { ErrorCode.NotFound, "未找到相关数据" },
    { ErrorCode.Unauthorized, "用户未授权" },
    { ErrorCode.Forbidden, "禁止访问此资源" },
    { ErrorCode.Timeout, "操作超时，请重试" },
    { ErrorCode.OperationFailed, "操作执行失败" },
    ...
}


 public static string GetMessage(ErrorCode code, string errorMessage = default) {
            // 判断errorMessage是否为null
            var res = _messages.TryGetValue(code, out var msg);

            msg = errorMessage != default
                ? msg + ":\n" + errorMessage
                : msg;

            return res
                ? msg
                : "未定义的错误";
 }
```
