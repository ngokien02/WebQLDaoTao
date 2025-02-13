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
        }
    }
}