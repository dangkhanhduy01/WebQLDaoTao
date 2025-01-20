<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="QLSinhvien.aspx.cs" Inherits="WebQLDaoTao.QLSinhvien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>Quản lý danh mục sinh viên</h2>
    <hr />
    <asp:Panel ID="PanelSinhVien" runat="server">
        <asp:GridView ID="gvSinhVien" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">
            <Columns>
                <asp:BoundField DataField="MaSV" HeaderText="Mã SV" />
                <asp:BoundField DataField="HoTen" HeaderText="Họ Tên" />
                <asp:BoundField DataField="GioiTinh" HeaderText="Giới Tính" />
                <asp:BoundField DataField="Lop" HeaderText="Lớp" />
                <asp:ButtonField Text="Sửa" CommandName="Edit" />
                <asp:ButtonField Text="Xóa" CommandName="Delete" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button ID="btnAddSinhVien" runat="server" Text="Thêm Sinh Viên" CssClass="btn btn-primary" OnClick="btnAddSinhVien_Click" />
    </asp:Panel>
</asp:Content>