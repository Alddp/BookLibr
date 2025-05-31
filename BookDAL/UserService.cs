using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

using static BookDAL.TabManager;

namespace BookDAL
{
    public class UserService
    {
        //用于验证登录
        public static int CountByNamePwd(string name, string pwd)
        {
            string tableName = AdminTable.tableName;
            string usernameColumn = AdminTable.Username;
            string passwordColumn = AdminTable.Pwd;

            string sql = $"SELECT COUNT(*) FROM {tableName} WHERE {usernameColumn} = @name AND {passwordColumn} = @pwd";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", name),
                new SqlParameter("@pwd", pwd)
            };
            return DBHelper.ExScalar(sql, parameters);
        }

        //用于统计用于表数量
        public static int CountUserNum()
        {
            string tableName = UserTable.tableName;
            // 建议添加表名合法性校验
            string sql = $"SELECT COUNT(*) FROM {tableName}";
            return DBHelper.ExScalar(sql);
        }

        //用于注册管理员用户
        public static int UsersInsert(string name, string pwd, string usertype, string phone)
        {
            string tableName = AdminTable.tableName;
            string usernameColumn = AdminTable.Username;
            string passwordColumn = AdminTable.Pwd;
            string usertypeColumn = AdminTable.Type;
            string teleColumn = AdminTable.Phone;

            string sql = $"INSERT INTO {tableName} ({usernameColumn}, {passwordColumn}, {usertypeColumn}, {teleColumn}) VALUES (@name, @pwd, @usertype, @phone)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", name),
                new SqlParameter("@pwd", pwd),
                new SqlParameter("@usertype", usertype),
                new SqlParameter("@phone", phone)
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }


        /// <summary>
        /// 注册普通用户
        /// </summary>
        /// <param name="icdev">卡号</param>
        /// <param name="name">姓名</param>
        /// <param name="stuid">学号</param>
        /// <param name="class">班级</param>
        /// <param name="photo">照片路径</param>
        /// <param name="phone">手机号</param>
        /// <returns></returns>        
        public static int UsersInsert(string icdev, string name, string stuid, string Class, string photo, string phone)
        {
            string tableName = UserTable.tableName;
            string cardNumColumn = UserTable.CardNum;
            string usernameColumn = UserTable.UserName;
            string stuidColumn = UserTable.StudentID;
            string photoColumn = UserTable.Photo;
            string classColumn = UserTable.Class;
            string teleColumn = UserTable.Phone;

            string sql = $"INSERT INTO {tableName} ({cardNumColumn}, {usernameColumn}, {stuidColumn}, {classColumn}, {teleColumn}, {photoColumn}) VALUES (@icdev, @name, @stuid, @class, @phone, @photo)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@icdev", icdev),
                 new SqlParameter("@name", name),
                 new SqlParameter("@stuid", stuid),
                 new SqlParameter("@class", Class),
                 new SqlParameter("@phone", phone),
                 new SqlParameter("@photo", photo)
            };

            return DBHelper.ExNonQuery(sql, parameters);
        }

    }
}
