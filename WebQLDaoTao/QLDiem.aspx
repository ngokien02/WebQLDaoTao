<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLDiem.aspx.cs" Inherits="WebQLDaoTao.QLDiem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>QUẢN LÝ ĐIỂM THI</h2>
    <hr />

    <asp:ObjectDataSource runat="server" ID="odsDiem" DataObjectTypeName="WebQLDaoTao.Models.KetQua" DeleteMethod="Delete"
        SelectMethod="GetByMaMH" TypeName="WebQLDaoTao.Models.KetQuaDAO" UpdateMethod="Update">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlMonHoc" DefaultValue="mamh" Name="mamh" PropertyName="SelectedValue"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource runat="server" ID="odsMonHoc" SelectMethod="GetAll" TypeName="WebQLDaoTao.Models.MonHocDAO"></asp:ObjectDataSource>

    <div class="form-horizontal">
        <div class="form-group">
            <label class="control-label col-sm-2">Chọn môn học</label>
            <div class="col-md-2">
                <asp:DropDownList ID="ddlMonHoc" AutoPostBack="True" runat="server" CssClass="form-control"
                    DataSourceID="odsMonHoc" DataTextField="TenMH" DataValueField="MaMH" Width="300px">
                </asp:DropDownList>
            </div>
        </div>
    </div>
    <hr />
    <asp:GridView ID="gvKetQua" runat="server"
        AutoGenerateColumns="False" CssClass="table table-bordered" Width="50%" DataSourceID="odsDiem" DataKeyNames="Id"
        AllowPaging="true" PageSize="6">
        <Columns>
            <asp:BoundField DataField="MaSV" HeaderText="Mã SV" SortExpression="MaSV" ItemStyle-Width="150px" >
<ItemStyle Width="150px"></ItemStyle>
            </asp:BoundField>
            <asp:BoundField DataField="HoTenSV" HeaderText="Họ tên" SortExpression="HoTenSV" ItemStyle-Width="200px" >
<ItemStyle Width="200px"></ItemStyle>
            </asp:BoundField>
            <asp:TemplateField HeaderText="Điểm">
                <ItemTemplate>
                    <asp:TextBox runat="server" ID="txtDiem" Text='<%# Eval("Diem") %>' Width="100px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Chọn" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:CheckBox runat="server" ID="cbxChon" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
        <PagerStyle BorderColor="#3366CC" BorderStyle="Solid" BorderWidth="1px" Font-Size="Large" HorizontalAlign="Center" 
            VerticalAlign="Middle" CssClass="paging" />
    </asp:GridView>
    <asp:Button ID="btnLuu" runat="server" CssClass="btn btn-success" Text="Lưu điểm" OnClick="btnLuu_Click" />
    <asp:Button ID="btnXoa" runat="server" CssClass="btn btn-danger" Text="Xóa điểm" 
        OnClientClick="return confirm('Bạn có chắc muốn xóa hết điểm đã chọn?')" OnClick="btnXoa_Click" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="QLSV" runat="server">
</asp:Content>
