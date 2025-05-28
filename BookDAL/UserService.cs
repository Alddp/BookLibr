using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDAL
{
    public class UserService
    {
        //用于验证登录
        public static int CountByNamePwd(string name, string pwd)
        {

            string sql = "select count(*) from Users where username ='" + name + "' and password = '" + pwd + "'";
            return DBHelper.ExScalar(sql);

            //SqlCommand c = new SqlCommand();
            //c.CommandText="select count(*) from Users where username ='"+name+"' and password = '"+pwd+"'";
            //c.Connection = DBHelper.Connection;
            //int i =(int)c.ExecuteScalar();
            //return i;

        }

        //用于统计用于表数量
        public static int CountUserNum()
        {

            string sql = "select count(*) from Users";
            return DBHelper.ExScalar(sql);

            //SqlCommand c = new SqlCommand();
            //c.CommandText = "select count(*) from Users ";
            //c.Connection = DBHelper.Connection;
            //int num= (int)c.ExecuteScalar(); // ExecuteScalar返回第一行第一列的值
            //return num;
        }

        //用于注册用户
        public static int UsersInsert(string name, string pwd, string usertype, string phone)
        {
            SqlCommand c = new SqlCommand();
            c.CommandText = @"
                        INSERT INTO Users (userName, password, userType, telephone)
                        VALUES (@Name, @Password, @UserType, @Phone)";

            // 添加参数
            c.Parameters.AddWithValue("@Name", name);
            c.Parameters.AddWithValue("@Password", pwd);
            c.Parameters.AddWithValue("@UserType", usertype);
            c.Parameters.AddWithValue("@Phone", phone);

            c.Connection = DBHelper.Connection;
            int i = (int)c.ExecuteNonQuery();
            return i;
        }

        public static int UsersInsert1(string name, string pwd, string usertype, string phone)
        {
            SqlParameter[] para = new SqlParameter[4]
            {
                new SqlParameter("@name",name),
                new SqlParameter("@pwd",pwd),
                new SqlParameter("@usertype",usertype),
                new SqlParameter("@phone",phone)
             };
            string sql = @"INSERT INTO Users (userName, password, userType,telephone)
                          VALUES (@name, @pwd, @usertype, @phone)";
            return DBHelper.ExNonQuery(sql, para);

        }
    }
}
