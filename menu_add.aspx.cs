using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class menu_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownListmenu.DataSource = Tool.menu.GetMenuList(null);
                DropDownListmenu.DataBind();

                ListItem item = new ListItem();
                item.Text = "顶级栏目";
                item.Value = "0";
                DropDownListmenu.Items.Insert(0, item);

            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            using (var ctx = new Models.实验二Entities())
            {
                var menu = new Models.菜单界面表();
                menu.id = ctx.菜单界面表.Select(s => s.id).DefaultIfEmpty().Max() + 1;
                menu.title = TextBoxtitle.Text.Trim();
                menu.sort_id = Tool.Tool.Obj2Int(TextBoxsort_id.Text.Trim());
                if (DropDownListmenu.SelectedValue == "0")
                {
                    menu.menu_id = null;
                }
                else
                {
                    menu.menu_id = Tool.Tool.Obj2Int(DropDownListmenu.SelectedValue);
                }
                ctx.菜单界面表.Add(menu);
                if (ctx.SaveChanges() > 0)
                {
                    Response.Redirect("menu_list.aspx");
                }
                else
                {
                    LabelAlert.Text = "添加失败";
                }

            }
        }
    }
}