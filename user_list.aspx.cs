using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class user_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridViewList_RowCommand1(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                int del_id = Tool.Tool.Obj2Int(e.CommandArgument.ToString());
                using (var ctx = new Models.实验二Entities())
                {
                    var user = ctx.user.Where(s => s.id == del_id).FirstOrDefault();
                    if (user != null)
                    {
                        ctx.user.Remove(user);

                        ctx.SaveChanges();

                        GridViewList.DataBind();
                    }

                }
            }
        }
    }
}