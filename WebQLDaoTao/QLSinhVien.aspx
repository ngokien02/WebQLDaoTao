<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLSinhVien.aspx.cs" Inherits="WebQLDaoTao.QLSinhVien" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main" runat="server">
    <%-- dung ham eval("tencot") va toan tu 3 ngoi de xu ly binding gioi tinh
        format lai ngay sinh 
        dung scrollbars de format lai gridview --%>
    <style>
        .lbThongBao {
            margin-left: 30px;
        }
    </style>

    <h2>TRANG QUẢN LÝ SINH VIÊN</h2>
    <hr />

    <div class="modal fade" id="modalThem" tabindex="-1" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Thêm sinh viên mới</h1>
                </div>
                <div class="modal-body" style="padding: 10px 30px 0 0;">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-3">Mã sinh viên</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtMaSV" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Họ sinh viên</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtHoSv" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <label class="control-label col-md-3">Tên sinh viên</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtTenSV" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Giới tính</label>
                            <div class="col-md-4">
                                <asp:RadioButton ID="rdNam" runat="server" Text="Nam" CssClass="radio-inline" Checked="true"
                                    GroupName="GT" />
                                <asp:RadioButton ID="rdNu" runat="server" Text="Nữ" CssClass="radio-inline" GroupName="GT" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Ngày sinh</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtNgaysinh" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                            <label class="control-label col-md-3">Nơi sinh</label>
                            <div class="col-md-3">
                                <asp:TextBox ID="txtNoiSinh" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Địa chỉ</label>
                            <div class="col-md-9">
                                <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-3">Chọn khoa</label>
                            <div class="col-md-4">
                                <asp:DropDownList ID="ddlMaKhoa" runat="server" CssClass="form-control" DataSourceID="odsKhoa"
                                    DataTextField="tenkh" DataValueField="makh">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <asp:Label ID="lbThongBao" runat="server" Text="" CssClass="lbThongBao"></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnDong" runat="server" class="btn btn-secondary" Text="Đóng" />
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary"
                            UseSubmitBehavior="false" OnClick="btnThem_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:Button ID="btnModal" runat="server" Text="Thêm sinh viên mới" CssClass="btn btn-success"
        OnClick="btnModal_Click" />

    <asp:ScriptManager runat="server" ID="sm"></asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="up">
        <ContentTemplate>

            <div class="table-responsive" style="margin-top: 10px;">

                <asp:ObjectDataSource ID="odsSinhVien" runat="server" DeleteMethod="Delete" InsertMethod="Insert"
                    SelectMethod="getAll" TypeName="WebQLDaoTao.Models.SinhVienDAO" UpdateMethod="Update">
                    <DeleteParameters>
                        <asp:Parameter Name="masv" Type="String" />
                    </DeleteParameters>
                    <InsertParameters>
                        <asp:ControlParameter ControlID="txtMaSV" Name="masv" PropertyName="text" Type="String" />
                        <asp:ControlParameter ControlID="txtHoSv" Name="hosv" PropertyName="text" Type="String" />
                        <asp:ControlParameter ControlID="txtTenSV" Name="tensv" PropertyName="text" Type="String" />
                        <asp:ControlParameter ControlID="rdNam" Name="gioitinh" PropertyName="Checked" Type="Boolean" />
                        <asp:ControlParameter ControlID="txtNgaysinh" Name="ngaysinh" PropertyName="text" Type="DateTime" />
                        <asp:ControlParameter ControlID="txtNoiSinh" Name="noisinh" PropertyName="text" Type="String" />
                        <asp:ControlParameter ControlID="txtDiaChi" Name="diachi" PropertyName="text" Type="String" />
                        <asp:ControlParameter ControlID="ddlMaKhoa" Name="makh" PropertyName="SelectedValue" Type="String" />
                    </InsertParameters>
                    <UpdateParameters>
                        <asp:Parameter Name="masv" Type="String" />
                        <asp:Parameter Name="hosv" Type="String" />
                        <asp:Parameter Name="tensv" Type="String" />
                        <asp:Parameter Name="gioitinh" Type="Boolean" />
                        <asp:Parameter Name="ngaysinh" Type="DateTime" />
                        <asp:Parameter Name="noisinh" Type="String" />
                        <asp:Parameter Name="diachi" Type="String" />
                        <asp:Parameter Name="makh" Type="String" />
                    </UpdateParameters>
                </asp:ObjectDataSource>


                <asp:GridView ID="gvSinhVien" runat="server" AllowPaging="True" CssClass="table"
                    BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4"
                    Width="1000px" RowStyle-Wrap="false" AutoGenerateColumns="False" DataKeyNames="Masv"
                    DataSourceID="odsSinhVien" OnRowUpdating="gvSinhVien_RowUpdating" OnRowDataBound="gvSinhVien_RowDataBound">

                    <Columns>
                        <asp:BoundField DataField="masv" HeaderText="Mã SV" ReadOnly="True" ItemStyle-Width="70px" />
                        <asp:BoundField DataField="hosv" HeaderText="Họ SV" ControlStyle-Width="150px" />
                        <asp:BoundField DataField="tensv" HeaderText="Tên SV" ItemStyle-Width="80px" ControlStyle-Width="80px" />
                        <asp:TemplateField HeaderText="Giới tính" ItemStyle-Width="90px">
                            <ItemTemplate>
                                <asp:Label ID="lbGioiTinh" runat="server" Text='<%# Convert.ToBoolean(Eval("gioitinh")) ? "Nam" : "Nữ" %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="cbGioiTinh" runat="server" Checked='<%# Bind("gioitinh") %>' />
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ngaysinh" HeaderText="Ngày sinh" DataFormatString="{0: dd/MM/yyyy}" />
                        <asp:BoundField DataField="noisinh" HeaderText="Nơi sinh" ControlStyle-Width="100px" />
                        <asp:BoundField DataField="diachi" HeaderText="Địa chỉ" />
                        <asp:TemplateField HeaderText="Khoa">
                            <ItemTemplate>
                                <asp:Label ID="lbMaKh" runat="server" Text='<%# Eval("makh") %>'></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:DropDownList ID="ddlKhoa" runat="server" DataSourceID="odsKhoa"
                                    DataTextField="TenKh" DataValueField="MaKh" SelectedValue='<%# Bind("makh") %>'>
                                </asp:DropDownList>
                            </EditItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Thao tác" ItemStyle-Width="250px">
                            <ItemTemplate>
                                <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-success">
    <i class="bi bi-pencil-square"></i> Sửa
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('Bạn có chắc muốn xóa sinh viên này?')"
                                    runat="server" Text="Xóa" CommandName="Delete" CssClass="btn btn-danger">
    <i class="bi bi-trash"></i> Xóa
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" CommandName="Update" CssClass="btn btn-primary" />
                                <asp:Button ID="btnCancel" runat="server" Text="Hủy" CommandName="Cancel" CssClass="btn btn-warning" />
                            </EditItemTemplate>
                            <ItemStyle Width="250px"></ItemStyle>
                        </asp:TemplateField>
                    </Columns>

                    <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                    <PagerStyle BorderColor="#3366CC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Large"
                        HorizontalAlign="Center" VerticalAlign="Middle" CssClass="paging" />
                    <RowStyle Wrap="False"></RowStyle>
                </asp:GridView>

            </div>
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

    <asp:ObjectDataSource ID="odsKhoa" runat="server" SelectMethod="GetAll" TypeName="WebQLDaoTao.Models.KhoaDAO"></asp:ObjectDataSource>
</asp:Content>
