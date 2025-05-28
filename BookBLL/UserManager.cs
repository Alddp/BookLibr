using BookDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookBLL
{
    public class UserManager
    {
        public static int CountByNamePwd(string name, string pwd)
        {
            return UserService.CountByNamePwd(name, pwd);
        }

        public static int CountUserNum()
        {
            return UserService.CountUserNum();
        }

        public static int UsersInsert(string name, string pwd, string usertype, string phone)
        {
            return UserService.UsersInsert(name, pwd, usertype, phone);
        }

        public static int UsersInsert1(string name, string pwd, string usertype, string phone)
        {
            return UserService.UsersInsert1(name, pwd, usertype, phone);
        }
    }
}
