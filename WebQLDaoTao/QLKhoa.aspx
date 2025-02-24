<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="QLKhoa.aspx.cs" Inherits="WebQLDaoTao.QLKhoa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">

    <h2 style="margin: 0;">TRANG QUẢN TRỊ KHOA </h2>
    <hr />
    <div class="modal fade" id="modalThem" tabindex="-1" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Thêm khoa mới</h1>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-sm-2">Mã khoa:</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtMaKH" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2">Tên khoa</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtTenKH" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lbThongBao" ForeColor="#cc3300" runat="server" Text=""></asp:Label>
                    <div class="modal-footer">
                        <asp:Button ID="btnDong" runat="server" class="btn btn-secondary" Text="Đóng" />
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary"
                            UseSubmitBehavior="false" OnClick="btnThem_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnModal" runat="server" Text="Thêm khoa mới" CssClass="btn btn-success"
        OnClick="btnModal_Click" />
    <%-- su dung objectdatasource de lien ket du lieu --%>

    <asp:ObjectDataSource ID="odsKhoa" runat="server"
        DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="GetAll" TypeName="WebQLDaoTao.Models.KhoaDAO"
        UpdateMethod="Update" OnDeleted="odsKhoa_Deleted">
        <InsertParameters>
            <asp:Parameter Name="makh" Type="String" />
            <asp:Parameter Name="tenkh" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:ScriptManager runat="server" ID="sm"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>
            <asp:GridView runat="server" ID="gvKhoa" AllowPaging="True" DataSourceID="odsKhoa" DataKeyNames="MAKH"
                CssClass="table" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px"
                CellPadding="4" AutoGenerateColumns="False" Width="700px">
                <Columns>
                    <asp:BoundField HeaderText="Mã khoa" DataField="MAKH" ReadOnly="True" />
                    <asp:BoundField HeaderText="Tên khoa" DataField="TENKH" />
                    <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="250px">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-success">
                            <i class="bi bi-pencil-square"></i>Sửa
                            </asp:LinkButton>
                            <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('Bạn có chắc muốn xóa khoa này?')"
                                runat="server" Text="Xóa" CommandName="Delete" CssClass="btn btn-danger">
                            <i class="bi bi-trash"></i>Xóa
                            </asp:LinkButton>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CommandName="Update" CssClass="btn btn-primary" />
                            <asp:Button ID="btnCancel" runat="server" Text="Hủy" CommandName="Cancel" CssClass="btn btn-warning" />
                        </EditItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BorderColor="#3366CC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Large"
                    HorizontalAlign="Center" VerticalAlign="Middle" CssClass="paging" />
            </asp:GridView>
            <asp:Label ID="lbError" runat="server" ForeColor="Red" Font-Size="Medium"></asp:Label>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            document.getElementById("<%= btnThem.ClientID %>").addEventListener("click", function (event) {
                event.preventDefault(); // Ngăn submit form
                __doPostBack('<%= btnThem.UniqueID %>', '');
            });
        });
    </script>
</asp:Content>
