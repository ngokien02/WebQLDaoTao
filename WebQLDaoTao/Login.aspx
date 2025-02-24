<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebQLDaoTao.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Đăng nhập</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.11.3/font/bootstrap-icons.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.7.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Contents/Style.css" />
</head>
<body style="background-color: darkcyan;">
    <div class="text-center" style="margin-top:30px;color:white;">
        <h1>Chào mừng đến với web Quản lý đào tạo</h1>
        <h3>Vui lòng đăng nhập để tiếp tục</h3>
    </div>
    <form id="form1" runat="server">
        <div class="container" style="margin-top: 50px; border: solid blue; padding: 30px; border-radius: 20px; width: 50%; font-size: large; background-color: white;">
            <div class="form-group">
                <label for="username">Tên đăng nhập</label>
                <asp:TextBox runat="server" type="text" class="form-control" ID="txtUsername" placeholder="Tên đăng nhập..." Height="50px"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="password">Mật khẩu</label>
                <asp:TextBox runat="server" type="password" class="form-control" ID="txtPassword" placeholder="Mật khẩu" Height="50px"></asp:TextBox>
            </div>
            <asp:Label runat="server" ID="lbError" ForeColor="Red" Font-Size="Medium"></asp:Label> <br />
            <asp:Button runat="server" ID="btnLogin" type="submit" class="btn btn-primary" Text="Login" Font-Size="Large" OnClick="btnLogin_Click" />
        </div>
    </form>
</body>
</html>
