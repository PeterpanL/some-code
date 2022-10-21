<%@ Page Title="栏目添加" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="menu_add.aspx.cs" Inherits="WebApplication1.admin.menu_add" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <table style="width: 100%;" border ="1">
        <tr>
            <td width="200">上级</td>
            <td>
                <asp:DropDownList ID="DropDownListmenu" runat="server" DataTextField="title" DataValueField="id"></asp:DropDownList>
            </td>
           
        </tr>
       <tr><td width="200">标题</td>
           <td>
               <asp:TextBox ID="TextBoxtitle" runat="server" Width="80%"></asp:TextBox>

           </td>
          
       </tr>

        <tr><td width="200">排序</td>
           <td>
               <asp:TextBox ID="TextBoxsort_id" runat="server" Width="200px" TextMode="Number"></asp:TextBox>

           </td>
          
       </tr>
    </table>
    <asp:Button ID="ButtonSave" runat="server" Text="保存" OnClick="ButtonSave_Click" />
    <asp:Label ID="LabelAlert" runat="server" Text="" ForeColor="Red"></asp:Label>
</asp:Content>
