<%@ Page Title="栏目列表" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="menu_list.aspx.cs" Inherits="WebApplication1.admin.menu_list" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridViewList" runat="server" Width="100%" AutoGenerateColumns="False" OnRowCommand="GridViewList_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="操作">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLinkEdit" runat="server" NavigateUrl='<%# Eval("id","menu_edit.aspx?id={0}") %>'>编辑</asp:HyperLink>
                    <asp:LinkButton ID="LinkButtonDel" runat="server" CommandArgument='<%# Eval("id") %>' CommandName="del">删除</asp:LinkButton>
                </ItemTemplate>
                <HeaderStyle Width="10%" />
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="标识">
                <HeaderStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="title" HeaderText="标题" />
            <asp:BoundField DataField="sort_id" HeaderText="排序">
                <HeaderStyle Width="10%" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
    <asp:Label ID="LabelAlert" runat="server" Text="" ForeColor="Red"></asp:Label>
</asp:Content>
