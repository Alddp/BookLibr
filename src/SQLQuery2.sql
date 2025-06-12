SELECT 
    Book.BookName,              -- 获取书籍名称
    COUNT(Borrow.BookId) AS BorrowCount  -- 统计借阅次数
FROM Borrow
INNER JOIN 
    Book ON Borrow.BookId = Book.BookId  -- 通过BookId关联两表
GROUP BY Book.BookName               -- 按书名分组
ORDER BY BorrowCount DESC;            -- 按借阅次数降序排序


SELECT 
    Book.BookId,
    Book.BookName,
    COUNT(Borrow.BookId) AS BorrowCount,
    -- 计算借阅比例（占所有借阅次数的百分比）
    COUNT(Borrow.BookId) * 1.0 / (SELECT COUNT(*) FROM Borrow) AS BorrowRatio
FROM Book
LEFT JOIN Borrow ON Book.BookId = Borrow.BookId
GROUP BY Book.BookId, Book.BookName
ORDER BY BorrowCount DESC;

-- 查询书籍热度
SELECT 
    Book.BookId,
    Book.BookName,
    COUNT(Borrow.BookId) AS BorrowCount,
    -- 格式化为百分比
    FORMAT(
        COUNT(Borrow.BookId) * 1.0 / (SELECT COUNT(*) FROM Borrow), 
        'P2'  -- 保留2位百分比的百分比格式
    ) AS BorrowPercentage
FROM Book
LEFT JOIN Borrow ON Book.BookId = Borrow.BookId
GROUP BY Book.BookId, Book.BookName
ORDER BY BorrowCount DESC;
