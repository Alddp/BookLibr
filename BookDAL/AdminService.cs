﻿using BookModels;
using BookModels.Constants;
using System.Data.SqlClient;

namespace BookDAL {

    public class AdminService {

        //用于验证登录
        public static int CountByNamePwd(string name, string pwd) {
            string tableName = AdminTableFields.TableName;
            string usernameColumn = AdminTableFields.Username;
            string passwordColumn = AdminTableFields.Pwd;

            string sql = $"SELECT COUNT(*) FROM {tableName} WHERE {usernameColumn} = @name AND {passwordColumn} = @pwd";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", name),
                new SqlParameter("@pwd", pwd)
            };
            return DBHelper.ExScalar(sql, parameters);
        }

        // 获取登录用户的信息
        public static SqlDataReader GetLoginUser(string name, string pwd) {
            string tableName = AdminTableFields.TableName;
            string usernameColumn = AdminTableFields.Username;
            string passwordColumn = AdminTableFields.Pwd;

            string sql = $"SELECT * FROM {tableName} WHERE {usernameColumn} = @name AND {passwordColumn} = @pwd";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", name),
                new SqlParameter("@pwd", pwd)
            };
            return DBHelper.ExecuteReader(sql, parameters);
        }

        /// <summary>
        /// 用于统计用于Reader数量
        /// </summary>
        /// <returns></returns>
        public static int CountUserNum() {
            string tableName = ReaderTableFields.TableName;
            // 建议添加表名合法性校验
            string sql = $"SELECT COUNT(*) FROM {tableName}";
            return DBHelper.ExScalar(sql);
        }

        /// <summary>
        /// 用于注册管理员用户
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public static int UsersInsert(Admin admin) {
            string tableName = AdminTableFields.TableName;
            string usernameColumn = AdminTableFields.Username;
            string passwordColumn = AdminTableFields.Pwd;
            string usertypeColumn = AdminTableFields.Type;
            string teleColumn = AdminTableFields.Phone;

            string sql = $"INSERT INTO " +
                $"{tableName} ({usernameColumn}, {passwordColumn}, {usertypeColumn}, {teleColumn}) " +
                $"VALUES (@name, @pwd, @usertype, @phone)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name", admin.UserName),
                new SqlParameter("@pwd", admin.Pwd),
                new SqlParameter("@usertype", admin.Type),
                new SqlParameter("@phone", admin.Phone)
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }

        /// <summary>
        /// 注册普通用户
        /// </summary>
        /// <param name="icdev">卡号</param>
        /// <param name="user">用户信息</param>
        /// <returns></returns>
        public static int UsersInsert(string icdev, Reader user) {
            string tableName = ReaderTableFields.TableName;
            string cardNumColumn = ReaderTableFields.CardNum;
            string usernameColumn = ReaderTableFields.UserName;
            string stuidColumn = ReaderTableFields.StudentID;
            string photoColumn = ReaderTableFields.Photo;
            string classColumn = ReaderTableFields.Class;
            string teleColumn = ReaderTableFields.Phone;

            string sql = $"INSERT INTO " +
                $"{tableName} ({cardNumColumn}, {usernameColumn}, {stuidColumn}, {classColumn}, {teleColumn}, {photoColumn}) " +
                $"VALUES (@icdev, @name, @stuid, @class, @phone, @photo)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@icdev", icdev),
                 new SqlParameter("@name", user.UserName),
                 new SqlParameter("@stuid", user.StudentId),
                 new SqlParameter("@class", user.ClassName),
                 new SqlParameter("@phone", user.Phone),
                 new SqlParameter("@photo", user.Photo)
            };

            return DBHelper.ExNonQuery(sql, parameters);
        }

        public static SqlDataReader GetAllAdmins() {
            string tableName = AdminTableFields.TableName;
            string sql = $"SELECT * FROM {tableName}";
            return DBHelper.ExecuteReader(sql, null);
        }

        public static int DeleteAdminById(string adminId) {
            string tableName = AdminTableFields.TableName;
            string adminIdColumn = AdminTableFields.AdminId;
            string sql = $"DELETE FROM {tableName} WHERE {adminIdColumn} = @adminId";
            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@adminId", adminId)
            };
            return DBHelper.ExNonQuery(sql, parameters);
        }
    }
}