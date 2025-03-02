using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQLDaoTao.Models;

namespace WebQLDaoTao
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        TaiKhoanDAO tkDAO = new TaiKhoanDAO();

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            TaiKhoan check = tkDAO.checkLogin(username, password);
            if (check != null)
            {
                Session["username"] = username;
                Session["role"] = check.role;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lbError.Text = "Sai tên tài khoản hoặc mật khẩu, vui lòng đăng nhập lại.";
                return;
            }
        }
    }
}