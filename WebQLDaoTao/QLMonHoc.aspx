<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLMonHoc.aspx.cs" Inherits="WebQLDaoTao.QLMonHoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Main" runat="server">

    <h2 style="margin: 0">QUẢN LÝ MÔN HỌC</h2>
    <hr />
    <div class="modal fade" id="modalThem" tabindex="-1" data-backdrop="static">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h1 class="modal-title fs-5" id="exampleModalLabel">Thêm môn học mới</h1>
                </div>
                <div class="modal-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-sm-2">Mã môn:</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtMaMH" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="control-label col-sm-2">Tên môn</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtTenMH" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-sm-2">Số tiết</label>
                            <div class="col-sm-10">
                                <asp:TextBox ID="txtSoTiet" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Label ID="lbThongBao" ForeColor="#cc3300" runat="server" Text=""></asp:Label>
                    <div class="modal-footer">
                        <asp:Button ID="btnDong" runat="server" class="btn btn-secondary" Text="Đóng" />
                        <asp:Button ID="btnThem" runat="server" Text="Thêm" CssClass="btn btn-primary" UseSubmitBehavior="false" 
                            OnClick="btnThem_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div>
        <asp:Button ID="btnModal" runat="server" Text="Thêm môn học mới" CssClass="btn btn-success" OnClick="btnModal_Click" />
        <asp:GridView DataKeyNames="MaMH" ID="gvMonHoc" runat="server" AutoGenerateColumns="False" OnRowEditing="gvMonHoc_RowEditing"
            OnSelectedIndexChanged="gvMonHoc_SelectedIndexChanged" OnRowCancelingEdit="gvMonHoc_RowCancelingEdit"
            OnRowUpdating="gvMonHoc_RowUpdating" CssClass="table" OnRowDeleting="gvMonHoc_RowDeleting" BackColor="White"
            BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" AllowPaging="True"
            OnPageIndexChanging="gvMonHoc_PageIndexChanging"
            PageSize="5">
            <Columns>
                <asp:BoundField HeaderText="Mã môn học" DataField="MaMH" ReadOnly="True" />
                <asp:BoundField HeaderText="Tên môn học" DataField="TenMH" />
                <asp:BoundField HeaderText="Số tiết" DataField="SoTiet" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="btnEdit" runat="server" CommandName="Edit" CssClass="btn btn-success">
                            <i class="bi bi-pencil-square"></i>Sửa
                        </asp:LinkButton>
                        <asp:LinkButton ID="btnDelete" OnClientClick="return confirm('Bạn có chắc muốn xóa môn học này?')" runat="server"
                            Text="Xóa" CommandName="Delete" CssClass="btn btn-danger">
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
            <PagerStyle BorderColor="#3366CC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Large" HorizontalAlign="Center" VerticalAlign="Middle"
                CssClass="paging" />
        </asp:GridView>
    </div>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            document.getElementById("<%= btnThem.ClientID %>").addEventListener("click", function (event) {
                event.preventDefault(); // Ngăn submit form
                __doPostBack('<%= btnThem.UniqueID %>', '');
            });
        });
    </script>
</asp:Content>
