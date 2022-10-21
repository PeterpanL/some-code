using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class user_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            using (var ctx = new Models.实验二Entities())
            {
                if (ctx.user.Count(s => s.username == TextBoxusername.Text.Trim()) > 0)
                {
                    LabelAlert.Text = "已存在此用户名，请换一个";
                }
                else
                {
                    var user = new Models.user();
                    user.id = ctx.user.Select(s => s.id).DefaultIfEmpty().Max() + 1;
                    user.username = TextBoxusername.Text.Trim();
                    user.password = Tool.Tool.MD5(TextBoxpassword.Text.Trim());
                    user.name = TextBoxname.Text.Trim();
                    user.gender = RadioButtonListgender.SelectedValue;
                    user.rank = Tool.Tool.Obj2Int(DropDownListrank.SelectedValue);

                    ctx.user.Add(user);
                    if (ctx.SaveChanges() > 0)
                    {
                        Response.Redirect("user_list.aspx");
                    }
                    else
                    {
                        LabelAlert.Text = "添加失败！";
                    }
                }
            }
        }
    }
}