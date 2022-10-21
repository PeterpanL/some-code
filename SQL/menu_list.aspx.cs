using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class menu_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewList.DataSource = Tool.menu.GetMenuList(null);
                GridViewList.DataBind();

            }
        }

        protected void GridViewList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                int del_id = Tool.Tool.Obj2Int(e.CommandArgument.ToString());
                using (var ctx = new Models.实验二Entities())
                {
                    if (ctx.菜单界面表.Count(s => s.menu_id == del_id) > 0)
                    {
                        LabelAlert.Text = "此栏目有下级，不可删除";
                    }
                    else
                    {
                        if (ctx.文章页面表.Count(s => s.menu_id == del_id) > 0)
                        {
                            LabelAlert.Text = "此栏目有文章，不可删除";
                        }
                        else
                        {
                            var menu = ctx.菜单界面表.Where(s => s.id == del_id).FirstOrDefault();
                            if (menu != null)
                            {
                                ctx.菜单界面表.Remove(menu);
                                if (ctx.SaveChanges() > 0)
                                {
                                    GridViewList.DataSource = Tool.menu.GetMenuList(null);
                                    GridViewList.DataBind();
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}