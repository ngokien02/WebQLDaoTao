<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebQLDaoTao.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <% if (Session["username"] == null)
        { %>
    <div>
        <div class="text-center">
            <h2>Chào mừng đến với web Quản lý đào tạo</h2>
            <h4>Vui lòng đăng nhập để tiếp tục</h4>
        </div>
        <div class="container" style="margin-top: 50px; border: 2px solid blue; padding: 30px; border-radius: 20px; width: 80%; font-size: large; background-color: white;">
            <div class="form-group">
                <label for="username">Tên đăng nhập</label>
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtUsername" placeholder="Tên đăng nhập..." Height="50px"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="password">Mật khẩu</label>
                <asp:TextBox runat="server" type="password" class="form-control" ID="txtPassword" placeholder="Mật khẩu" Height="50px"></asp:TextBox>
            </div>
            <asp:Label runat="server" ID="lbError" ForeColor="Red" Font-Size="Medium"></asp:Label>
            <br />
            <asp:Button runat="server" ID="btnLogin" type="submit" class="btn btn-primary" Text="Login" Font-Size="Large" OnClick="btnLogin_Click" />
        </div>
    </div>
    <% }
        else
        { %>
    <h1>Chào mừng đến với web Quản lý đào tạo</h1>
    <% } %>
</asp:Content>
