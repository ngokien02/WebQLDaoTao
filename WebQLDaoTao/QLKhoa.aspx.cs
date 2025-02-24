using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLKhoa : Secure
    {
        protected void ShowModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "$('#modalThem').modal('show');", true);
        }
        protected void btnModal_Click(object sender, EventArgs e)
        {
            string script = "$('#modalThem').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }
        KhoaDAO khoaDAO = new KhoaDAO();
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaKH.Text) || string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                ShowModal();
                lbThongBao.Text = "Vui lòng nhập đầy đủ dữ liệu.";
                return;
            }
            try
            {
                if (khoaDAO.findByMaKh(txtMaKH.Text) != null)
                {
                    ShowModal();
                    lbThongBao.Text = "Mã khoa không được trùng, vui lòng đổi lại.";
                    return;
                }
                odsKhoa.InsertParameters["makh"].DefaultValue = txtMaKH.Text;
                odsKhoa.InsertParameters["tenkh"].DefaultValue = txtTenKH.Text;

                odsKhoa.Insert();
            }
            catch (Exception ex)
            {
                ShowModal();
                lbThongBao.Text = "Thêm không thành công. Hãy thử nhập lại dữ liệu.";
            }
        }

        protected void odsKhoa_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            lbError.ForeColor = System.Drawing.Color.Red;
            if (e.ReturnValue != null && int.TryParse(e.ReturnValue.ToString(), out int result))
            {
                if (result == -1)
                {
                    lbError.Text = "Không thể xóa khoa do có sinh viên đăng ký.";
                }
                else if (result == 0)
                {
                    lbError.Text = "Không tìm thấy khoa cần xóa.";
                }
                else
                {
                    lbError.Text = "Xóa thành công.";
                    lbError.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                lbError.Text = "Đã xảy ra lỗi không xác định.";
            }
        }
    }
}