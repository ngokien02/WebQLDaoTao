using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLSinhVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void gvSinhVien_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Lấy mã sinh viên (Primary Key)
            string masv = gvSinhVien.DataKeys[e.RowIndex].Value.ToString();

            // Lấy giá trị từ các TextBox và CheckBox trong GridView
            GridViewRow row = gvSinhVien.Rows[e.RowIndex];

            string hosv = ((TextBox)row.Cells[1].Controls[0]).Text;
            string tensv = ((TextBox)row.Cells[2].Controls[0]).Text;
            CheckBox chkGioiTinh = (CheckBox)row.FindControl("cbGioiTinh");
            bool gioitinh = chkGioiTinh.Checked;

            DateTime ngaysinh = Convert.ToDateTime(((TextBox)row.Cells[4].Controls[0]).Text);
            string noisinh = ((TextBox)row.Cells[5].Controls[0]).Text;
            string diachi = ((TextBox)row.Cells[6].Controls[0]).Text;
            string makh = ((TextBox)row.Cells[7].Controls[0]).Text;

            // Gọi phương thức cập nhật từ class sinhviendao
            SinhVienDAO dao = new SinhVienDAO();
            dao.Update(masv, hosv, tensv, gioitinh, ngaysinh, noisinh, diachi, makh);

            // Thoát khỏi chế độ chỉnh sửa
            gvSinhVien.EditIndex = -1;
            odsSinhVien.DataBind();
            gvSinhVien.DataBind(); // Load lại dữ liệu
        }
    }
}