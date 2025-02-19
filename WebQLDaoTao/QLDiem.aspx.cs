using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLDiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        KetQuaDAO kqDAO = new KetQuaDAO();
        public int Count()
        {
            int count = gvKetQua.Rows.Count;
            return count;
        }
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Count(); i++)
            {
                int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                float diem = float.Parse(((TextBox)gvKetQua.Rows[i].FindControl("txtDiem")).Text);
                kqDAO.Update(id, diem);
            }
        }

        protected void btnXoa_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < Count(); i++)
            {
                bool check = ((CheckBox)gvKetQua.Rows[i].FindControl("cbxChon")).Checked;
                if (check)
                {
                    int id = int.Parse(gvKetQua.DataKeys[i].Value.ToString());
                    kqDAO.Delete(id);
                    gvKetQua.DataBind();
                    count++;
                }
            }
            lbThongBaoXoa.Text = $"Đã xóa thành công {count} điểm.";
            lbThongBaoXoa.ForeColor = System.Drawing.Color.Green;
        }
    }
}