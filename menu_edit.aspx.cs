using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class menu_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int menu_id = Tool.Tool.RequestQstrInt("id");
                if (menu_id != 0)
                {
                    using (var ctx = new Models.实验二Entities())
                    {
                        DropDownListmenu.DataSource = Tool.menu.GetMenuList(null);
                        DropDownListmenu.DataBind();

                        ListItem item = new ListItem();
                        item.Text = "顶级栏目";
                        item.Value = "0";
                        DropDownListmenu.Items.Insert(0, item);

                        var menu = ctx.菜单界面表.Where(s => s.id == menu_id).FirstOrDefault();
                        if (menu != null)
                        {
                            ViewState["menu_id"] = menu_id;

                            if (menu.menu_id != null)
                            {
                                DropDownListmenu.SelectedValue = menu.menu_id.ToString();

                            }
                            TextBoxtitle.Text = menu.title;
                            TextBoxsort_id.Text = menu.sort_id.ToString();

                        }
                    }
                }
                else
                {
                    Response.Redirect("menu_list.aspx");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            int menu_id = Tool.Tool.Obj2Int(ViewState["menu_id"]);
            using (var ctx = new Models.实验二Entities())
            {
                var menu = ctx.菜单界面表.Where(s => s.id == menu_id).FirstOrDefault();
                if (menu != null)
                {
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
                    ctx.SaveChanges();
                    Response.Redirect("menu_list.aspx");
                }
            }
        }
    }
}