using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["currentuser"] != null)
                {
                    var user = Session["currentuser"] as Models.user;
                    if (user != null)
                    {
                        Labeluser.Text = user.username + " " + user.name;
                        if (user.rank != 1)
                        {
                            user_list.Visible = false;
                            user_add.Visible = false;
                        }
                    }
                }
                else
                {
                    Session["currentuser"] = "";
                    Response.Redirect("~/login.aspx");
                }

            }
        }

        protected void LinkButtonlogout_Click(object sender, EventArgs e)
        {
            Session["currentuser"] = "";
            Response.Redirect("~/login.aspx");
        }
    }
}