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
            CheckBox cbGioiTinh = (CheckBox)gvSinhVien.Rows[e.RowIndex].FindControl("cbGioiTinh");
            bool gioiTinh = cbGioiTinh.Checked;
            e.NewValues["gioitinh"] = gioiTinh;

            DropDownList ddlKhoa = (DropDownList)gvSinhVien.Rows[e.RowIndex].FindControl("ddlKhoa");
            string makh = ddlKhoa.SelectedValue as string;
            e.NewValues["makh"] = makh;
        }

        protected void gvSinhVien_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if ((e.Row.RowState & DataControlRowState.Edit) > 0)
                {
                    //tim dieu khien DropDownList ddlKhoa tren dòng hiện hành
                    DropDownList ddlKhoa = (DropDownList)e.Row.FindControl("ddlKhoa");

                    //gan giá trị mặc định được chọn = giá trị mã khoa của sinh viên
                    ddlKhoa.SelectedValue = ((SinhVien)e.Row.DataItem).MaKH;
                }
            }
        }
    }
}