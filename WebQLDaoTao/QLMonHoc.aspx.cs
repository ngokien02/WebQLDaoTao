using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLMonHoc : Secure
    {
        MonHocDAO mhDAO = new MonHocDAO();

        protected void ShowModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "$('#modalThem').modal('show');", true);
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {
            string script = "$('#modalThem').modal('show');";
            ClientScript.RegisterStartupScript(this.GetType(), "Popup", script, true);
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            lbThongBao.ForeColor = System.Drawing.Color.Red;
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox tbx && string.IsNullOrEmpty(tbx.Text))
                {
                    ShowModal();
                    lbThongBao.Text = "Vui lòng nhập đầy đủ dữ liệu";
                    return;
                }
            }
            try
            {
                //lay thong tin mon hoc can them
                string mamh = txtMaMH.Text;
                string tenmh = txtTenMH.Text;
                int sotiet = int.Parse(txtSoTiet.Text);
                MonHoc mh = new MonHoc { MaMH = mamh, TenMH = tenmh, SoTiet = sotiet };
                if (mhDAO.findById(mamh) != null)
                {
                    ShowModal();
                    lbThongBao.Text = "Mã môn học đã tồn tại. Chọn mã khác nhé";
                    return;
                }
                //goi phuong thuc them mon hoc vao CSDL cua lop MonHocDAO
                mhDAO.Insert(mamh, tenmh, sotiet);//lenh them du lieu
                ShowModal();
                lbThongBao.Text = "Đã thêm 1 môn học";
                lbThongBao.ForeColor = System.Drawing.Color.Green;
                gvMonHoc.DataBind();
            }
            catch (Exception ex)
            {
                ShowModal();
                lbThongBao.Text = "Thao tác thêm môn học không thành công do lỗi dữ liệu";
            }
        }

        protected void odsMonHoc_Deleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            lbError.ForeColor = System.Drawing.Color.Red;
            if (e.ReturnValue != null && int.TryParse(e.ReturnValue.ToString(), out int result))
            {
                if (result == -1)
                {
                    lbError.Text = "Không thể xóa môn học do đã có sinh viên dự thi.";
                }
                else if (result == 0)
                {
                    lbError.Text = "Không tìm thấy môn học cần xóa.";
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