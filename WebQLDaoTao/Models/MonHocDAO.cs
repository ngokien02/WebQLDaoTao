using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Sockets;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class MonHocDAO
    {
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            return conn;
        }
        public SqlCommand cmd;
        public List<MonHoc> GetAll()
        {

            List<MonHoc> ds = new List<MonHoc>();
            var conn = Connect();
            conn.Open();
            cmd = new SqlCommand("select * from MonHoc", conn);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                MonHoc mh = new MonHoc
                {
                    MaMH = rd["mamh"].ToString(),
                    TenMH = rd["tenmh"].ToString(),
                    SoTiet = int.Parse(rd["sotiet"].ToString())
                };
                ds.Add(mh);
            }
            return ds;
        }
        public int Update(string mamh, string tenmh, int sotiet)
        {
            var conn = Connect();
            conn.Open();
            cmd = new SqlCommand("update MonHoc set tenmh = @tenmh, sotiet = @sotiet " +
                                 "where mamh = @mamh", conn);
            cmd.Parameters.AddWithValue("@tenmh", tenmh);
            cmd.Parameters.AddWithValue("@sotiet", sotiet);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        public int Delete(string mamh)
        {
            //1.Mo ket noi CSDL
            var conn = Connect();
            conn.Open();
            //2.tao truy van
            cmd = new SqlCommand("delete from MonHoc where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        public int Insert(MonHoc mh)
        {
            //1.Mo ket noi CSDL
            var conn = Connect();
            conn.Open();
            //2.tao truy van
            cmd = new SqlCommand("insert into MonHoc (mamh, tenmh,sotiet) values (@mamh,@tenmh, @sotiet)", conn);
            cmd.Parameters.AddWithValue("@mamh", mh.MaMH);
            cmd.Parameters.AddWithValue("@tenmh", mh.TenMH);
            cmd.Parameters.AddWithValue("@sotiet", mh.SoTiet);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        public MonHoc findById(string mamh)
        {
            MonHoc kq = null;
            //1.Mo ket noi CSDL
            var conn = Connect();
            conn.Open();
            //2.tao truy van
            cmd = new SqlCommand("select * from MonHoc where mamh=@mamh", conn);
            cmd.Parameters.AddWithValue("@mamh", mamh);
            //3.thuc thi ket qua;
            SqlDataReader rd = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            if (rd.Read())
            {
                //tao doi tuong mon hoc
                kq = new MonHoc
                {
                    MaMH = rd["MaMH"].ToString(),
                    TenMH = rd["TenMH"].ToString(),
                    SoTiet = int.Parse(rd["SoTiet"].ToString())
                };
            }
            return kq;
        }
    }
}