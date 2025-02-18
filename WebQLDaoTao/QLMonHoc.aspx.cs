using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class QLMonHoc : System.Web.UI.Page
    {
        MonHocDAO mhDAO = new MonHocDAO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                KhoiTaoDuLieu();
            }
        }
        protected void ShowModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "$('#modalThem').modal('show');", true);
        }
        private void KhoiTaoDuLieu()
        {
            gvMonHoc.DataSource = mhDAO.GetAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvMonHoc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMonHoc.EditIndex = e.NewEditIndex;
            KhoiTaoDuLieu();
        }

        protected void gvMonHoc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMonHoc.EditIndex = -1;
            KhoiTaoDuLieu();
        }

        protected void gvMonHoc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string mamh = gvMonHoc.DataKeys[e.RowIndex].Value.ToString();
            string tenmh = ((TextBox)gvMonHoc.Rows[e.RowIndex].Cells[1].Controls[0]).Text;
            int sotiet = int.Parse(((TextBox)gvMonHoc.Rows[e.RowIndex].Cells[2].Controls[0]).Text);

            MonHoc mh = new MonHoc { MaMH = mamh, TenMH = tenmh, SoTiet = sotiet };
            mhDAO.Update(mamh, tenmh, sotiet);
            gvMonHoc.EditIndex = -1;
            gvMonHoc.DataSource = mhDAO.GetAll();
            gvMonHoc.DataBind();
        }

        protected void gvMonHoc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                //b1. lấy thông tin mã môn học hiện hành
                string mamh = gvMonHoc.DataKeys[e.RowIndex].Value.ToString();
                //b2. goi phương thức xóa môn học khỏi CSDL của lớp MonHocDAO
                mhDAO.Delete(mamh);
                //b4. lien ket lai du lieu cho gvMonHoc
                gvMonHoc.DataSource = mhDAO.GetAll();
                gvMonHoc.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Không thể xóa môn học này')</script>");
            }
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
                mhDAO.Insert(mh);//lenh them du lieu
                ShowModal();
                lbThongBao.Text = "Đã thêm 1 môn học";
                lbThongBao.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                ShowModal();
                lbThongBao.Text = "Thao tác thêm môn học không thành công do lỗi dữ liệu";
            }
            //liên kết dữ liệu cho gvMonHoc
            KhoiTaoDuLieu();
        }

        protected void gvMonHoc_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvMonHoc.PageIndex = e.NewPageIndex;
            KhoiTaoDuLieu();
        }
    }
}