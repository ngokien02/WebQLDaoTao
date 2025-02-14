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
        SinhVienDAO sinhVienDAO = new SinhVienDAO();
        protected void ShowModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "$('#modalThem').modal('show');", true);
        }
        protected void gvSinhVien_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //CheckBox cbGioiTinh = (CheckBox)gvSinhVien.Rows[e.RowIndex].FindControl("cbGioiTinh");
            //bool gioiTinh = cbGioiTinh.Checked;
            //e.NewValues["gioitinh"] = gioiTinh;

            //DropDownList ddlKhoa = (DropDownList)gvSinhVien.Rows[e.RowIndex].FindControl("ddlKhoa");
            //string makh = ddlKhoa.SelectedValue as string;
            //e.NewValues["makh"] = makh;
        }

        protected void gvSinhVien_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if ((e.Row.RowState & DataControlRowState.Edit) > 0)
            //    {
            //        //tim dieu khien DropDownList ddlKhoa tren dòng hiện hành
            //        DropDownList ddlKhoa = (DropDownList)e.Row.FindControl("ddlKhoa");

            //        //gan giá trị mặc định được chọn = giá trị mã khoa của sinh viên
            //        ddlKhoa.SelectedValue = ((SinhVien)e.Row.DataItem).MaKH;
            //    }
            //}
        }

        protected void btnModal_Click(object sender, EventArgs e)
        {
            string script = "$('#modalThem').modal('show');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", script, true);
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            foreach (Control ctr in this.Controls)
            {
                if (ctr is TextBox tbx && string.IsNullOrEmpty(tbx.Text)
                    || string.IsNullOrWhiteSpace(txtNgaysinh.Text))
                {
                     ShowModal();
                     lbThongBao.Text = "Vui lòng nhập đầy đủ dữ liệu";
                    return;
                }
            }
            try
            {
                if (sinhVienDAO.findByMasv(txtMaSV.Text) != null)
                {
                    ShowModal();
                    lbThongBao.Text = "Mã sinh viên không được trùng.";
                    return;
                }
                odsSinhVien.Insert();
                ShowModal();
                lbThongBao.Text = "Thêm sinh viên thành công";
                lbThongBao.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                ShowModal();
                lbThongBao.Text = "Có lỗi xảy ra, xin hãy thử lại.";
                return;
            }
        }
    }
}