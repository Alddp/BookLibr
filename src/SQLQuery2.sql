SELECT 
    Book.BookName,              -- ��ȡ�鼮����
    COUNT(Borrow.BookId) AS BorrowCount  -- ͳ�ƽ��Ĵ���
FROM Borrow
INNER JOIN 
    Book ON Borrow.BookId = Book.BookId  -- ͨ��BookId��������
GROUP BY Book.BookName               -- ����������
ORDER BY BorrowCount DESC;            -- �����Ĵ�����������


SELECT 
    Book.BookId,
    Book.BookName,
    COUNT(Borrow.BookId) AS BorrowCount,
    -- ������ı�����ռ���н��Ĵ����İٷֱȣ�
    COUNT(Borrow.BookId) * 1.0 / (SELECT COUNT(*) FROM Borrow) AS BorrowRatio
FROM Book
LEFT JOIN Borrow ON Book.BookId = Borrow.BookId
GROUP BY Book.BookId, Book.BookName
ORDER BY BorrowCount DESC;

-- ��ѯ�鼮�ȶ�
SELECT 
    Book.BookId,
    Book.BookName,
    COUNT(Borrow.BookId) AS BorrowCount,
    -- ��ʽ��Ϊ�ٷֱ�
    FORMAT(
        COUNT(Borrow.BookId) * 1.0 / (SELECT COUNT(*) FROM Borrow), 
        'P2'  -- ����2λ�ٷֱȵİٷֱȸ�ʽ
    ) AS BorrowPercentage
FROM Book
LEFT JOIN Borrow ON Book.BookId = Borrow.BookId
GROUP BY Book.BookId, Book.BookName
ORDER BY BorrowCount DESC;
