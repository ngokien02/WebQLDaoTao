using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class TaiKhoanDAO
    {
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            return conn;
        }
        public SqlCommand cmd;
        public TaiKhoan checkLogin(string username, string password)
        {
            TaiKhoan check = null;

            var conn = Connect();
            conn.Open();

            cmd = new SqlCommand("select * from TaiKhoan where username = @username and password = @password", conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                check = new TaiKhoan
                {
                    username = dr["username"].ToString(),
                    password = dr["password"].ToString(),
                    role = dr["role"].ToString()
                };
            }

            return check;
        }
    }
}