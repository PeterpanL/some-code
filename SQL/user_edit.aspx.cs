using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class user_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int user_id = Tool.Tool.RequestQstrInt("id");
                if (user_id != 0)
                {
                    using (var ctx = new Models.实验二Entities())
                    {
                        var user = ctx.user.Where(s => s.id == user_id).FirstOrDefault();
                        if (user != null)
                        {
                            ViewState["user_id"] = user_id;

                            Labelusername.Text = user.username;
                            TextBoxname.Text = user.name;
                            RadioButtonListgender.SelectedValue = user.gender;
                            DropDownListrank.SelectedValue = user.rank.ToString();
                        }
                    }
                }
                else
                {
                    Response.Redirect("user_list.aspx");
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            int user_id = Tool.Tool.Obj2Int(ViewState["user_id"]);
            using (var ctx = new Models.实验二Entities())
            {
                var user = ctx.user.Where(s => s.id == user_id).FirstOrDefault();
                if (user != null)
                {
                    if (TextBoxpassword.Text.Trim() != "")
                    {
                        user.password = Tool.Tool.MD5(TextBoxpassword.Text.Trim());
                    }
                    user.name = TextBoxname.Text.Trim();
                    user.gender = RadioButtonListgender.SelectedValue;
                    user.rank = Tool.Tool.Obj2Int(DropDownListrank.SelectedValue);

                    ctx.SaveChanges();
                    Response.Redirect("user_list.aspx");
                }
            }
        }
    }
}