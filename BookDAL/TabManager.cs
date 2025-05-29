using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDAL
{
    public static class TabManager
    {
        public static class UserTable
        {
            public const string tableName = "User";

            public const string UserId = "UserId";
            public const string CardNum = "CardNum";
            public const string UserName = "UserName";
            public const string StudentID = "StudentID";
            public const string Phone = "Phone";
            public const string Class = "Class";
            public const string Photo = "Photo";
            public const string Start_Time = "Start_Time";
            public const string Ending_Time = "Ending_Time";
        }

        public static class AdminTable
        {
            public const string tableName = "Admin";

            public const string AdminId = "AdminId";
            public const string Username = "Username";
            public const string Pwd = "Pwd";
            public const string Phone = "Phone";
            public const string Type = "Type";
        }

        public static class BookTable
        {
            public const string tableName = "Book";

            public const string BookId = "BookId";
            public const string BookName = "BookName";
            public const string Author = "Author";
            public const string Inventory = "Inventory"; // 库存数量
            public const string Picture = "Picture";
            public const string ISBN = "ISBN";
            public const string Price = "Price";
        }

        public static class BorrowTable
        {
            public const string BorrowId = "BorrowId";
            public const string UserId = "UserId";
            public const string BookId = "BookId";
            public const string BorrowAdminId = "BorrowAdminId";
            public const string ReturnAdminId = "ReturnAdminId";
            public const string BorrowDate = "BorrowDate";
            public const string ReturnDate = "ReturnDate";
        }
    }
}
