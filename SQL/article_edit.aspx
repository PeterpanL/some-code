<%@ Page Title="文章编辑" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="article_edit.aspx.cs" Inherits="WebApplication1.admin.article_edit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="width: 100%;">
        <tr>
            <td style="width:100px">标题</td>
            <td>
                <asp:TextBox ID="TextBoxtitle" runat="server" requeired Width="80%"></asp:TextBox>
            </td>  
        </tr>
        <tr>
            <td style="width:100px">菜单</td>
            <td>
                <asp:DropDownList ID="DropDownListmenu" runat="server" DataTextField="title" DataValueField="id"></asp:DropDownList>
            </td>  
        </tr>
        <tr>
            <td style="width:100px">作者</td>
            <td>
                <asp:TextBox ID="TextBoxwriter" runat="server" requeired Width=200px></asp:TextBox>
            </td>  
        </tr>
    </table>
    <asp:TextBox ID="TextBoxContent" runat="server" requeired Width="100%" Height="400px"></asp:TextBox>
    <ajaxToolkit:HtmlEditorExtender ID="TextBoxContent_HtmlEditorExtender" runat="server" BehaviorID="TextBoxContent_HtmlEditorExtender" TargetControlID="TextBoxContent" DisplaySourceTab="True">
    </ajaxToolkit:HtmlEditorExtender>
    <div>
    <asp:Button ID="ButtonSave" runat="server" Text="保存" OnClick="ButtonSave_Click" />
        <asp:Label ID="LabelAlert" runat="server" Text="" ForeColor="RED"></asp:Label>
    </div>
</asp:Content>
