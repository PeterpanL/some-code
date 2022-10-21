<%@ Page Title="用户列表" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="WebApplication1.admin.user_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewList" runat="server" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="id" DataSourceID="SqlDataSourceList" ForeColor="#333333" GridLines="None" OnRowCommand="GridViewList_RowCommand1" Width="100%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLinkEdit" runat="server" NavigateUrl='<%# Eval("id", "user_edit.aspx?id={0}") %>'>编辑</asp:HyperLink>
                    <asp:LinkButton ID="LinkButtonDel" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="Del">删除</asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="20%" />
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="ID" ReadOnly="True" SortExpression="id">
            <HeaderStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="username" HeaderText="用户名" SortExpression="username" />
            <asp:BoundField DataField="name" HeaderText="姓名" SortExpression="name">
            <HeaderStyle Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="gender" HeaderText="性别" SortExpression="gender">
            <HeaderStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="rank" HeaderText="级别" SortExpression="rank">
            <HeaderStyle Width="5%" />
            </asp:BoundField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSourceList" runat="server" ConnectionString="<%$ ConnectionStrings:实验二ConnectionString %>" SelectCommand="SELECT [id], [username], [name], [gender], [rank] FROM [user] ORDER BY [username]"></asp:SqlDataSource>
</asp:Content>
