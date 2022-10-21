using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            using (var ctx = new Models.实验二Entities())
            {
                var result = ctx.user.Where(s => s.username == TextBoxusername.Text.Trim()).FirstOrDefault();
                if (result != null)
                {
                    if (result.password == Tool.Tool.MD5(TextBoxpassword.Text))
                    {
                        Session["currentuser"] = result;
                        Response.Redirect("~/admin/default.aspx");
                    }
                    else
                    {
                        LabelAlert.Text = "密码错误";
                    }

                }
                else
                {
                    LabelAlert.Text = "不存在此用户";
                }
            }
        }
    }
}