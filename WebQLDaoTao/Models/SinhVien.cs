using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebQLDaoTao.Models
{
    public class SinhVien
    {
        public string MaSV { set; get; }
        public string HoSV { set; get; }
        public string TenSV { set; get; }
        public Boolean GioiTinh { set; get; }
        public DateTime NgaySinh { set; get; }
        public string NoiSinh { set; get; }
        public string DiaChi { set; get; }
        public string MaKH { set; get; }
    }
}