using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class SinhVienDAO
    {
        public SqlConnection Connect()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["QLDaoTao_ConStr"].ConnectionString);
            return conn;
        }
        public SqlCommand cmd;
        public int Insert(string masv, string hosv, string tensv, Boolean gioitinh, DateTime ngaysinh,
            string noisinh, string diachi, string makh)
        {
            var conn = Connect();
            conn.Open();

            cmd = new SqlCommand("insert into sinhvien (masv, hosv, tensv, gioitinh, ngaysinh, noisinh, " +
                "diachi, makh) values(@masv, @hosv, @tensv, @gioitinh, @ngaysinh, @noisinh, @diachi, " +
                "@makh)", conn);
            cmd.Parameters.AddWithValue("@masv", masv);
            cmd.Parameters.AddWithValue("@hosv", hosv);
            cmd.Parameters.AddWithValue("@tensv", tensv);
            cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
            cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cmd.Parameters.AddWithValue("@noisinh", noisinh);
            cmd.Parameters.AddWithValue("@diachi", diachi);
            cmd.Parameters.AddWithValue("@makh", makh);

            return cmd.ExecuteNonQuery();
        }
        //phuong thuc doc tat ca sinh vien
        public List<SinhVien> getAll()
        {
            List<SinhVien> dsSinhVien = new List<SinhVien>();
            var conn = Connect();
            conn.Open(); 
            cmd = new SqlCommand("select * from SinhVien", conn);
            //3.thuc thi ket qua;
            SqlDataReader dr = cmd.ExecuteReader();
            //4.xu ly ket qua tra ve
            while (dr.Read())
            {
                //tao doi tuong sinhvien
                SinhVien sv = new SinhVien
                {
                    MaSV = dr["MaSV"].ToString(),
                    HoSV = dr["Hosv"].ToString(),
                    TenSV = dr["Tensv"].ToString(),
                    GioiTinh = Boolean.Parse(dr["gioitinh"].ToString()),
                    NgaySinh = DateTime.Parse(dr["ngaysinh"].ToString()),
                    NoiSinh = dr["noisinh"].ToString(),
                    DiaChi = dr["diachi"].ToString(),
                    MaKH = dr["Makh"].ToString()
                };

                //add vao dsSinhVien
                dsSinhVien.Add(sv);
            }
            return dsSinhVien;
        }
        //phuong thuc cập nhật thông tin sinh vien vao CSDL
        public int Update(string masv, string hosv, string tensv, Boolean gioitinh, DateTime ngaysinh, 
            string noisinh, string diachi, string makh)
        {
            var conn = Connect();
            conn.Open(); 

            cmd = new SqlCommand("update sinhvien set hosv=@hosv, tensv=@tensv, gioitinh=@gioitinh, " +
                "ngaysinh = @ngaysinh, noisinh = @noisinh, diachi = @diachi, makh = @makh where masv = @masv", conn);
            cmd.Parameters.AddWithValue("@masv", masv);
            cmd.Parameters.AddWithValue("@hosv", hosv);
            cmd.Parameters.AddWithValue("@tensv", tensv);
            cmd.Parameters.AddWithValue("@gioitinh", gioitinh);
            cmd.Parameters.AddWithValue("@ngaysinh", ngaysinh);
            cmd.Parameters.AddWithValue("@noisinh", noisinh);
            cmd.Parameters.AddWithValue("@diachi", diachi);
            cmd.Parameters.AddWithValue("@makh", makh);

            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
        //phuong thuc cập nhật thông tin sinh vien vao CSDL
        public int Delete(string masv)
        {
            var conn = Connect();
            conn.Open();
            cmd = new SqlCommand("delete from sinhvien where masv=@masv", conn);
            cmd.Parameters.AddWithValue("@masv", masv);
            //3.thuc thi ket qua;
            return cmd.ExecuteNonQuery();
        }
    }
}