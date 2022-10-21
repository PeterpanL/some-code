using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class article_edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int article_id = Tool.Tool.RequestQstrInt("id");
                if (article_id != 0)
                {
                    using (var ctx = new Models.实验二Entities())
                    {
                        DropDownListmenu.DataSource = ctx.菜单界面表.OrderBy(s => s.sort_id).ToList();
                        DropDownListmenu.DataBind();

                        var article = ctx.文章页面表.Where(s => s.id == article_id).FirstOrDefault();
                        if (article != null)
                        {
                            ViewState["article_id"] = article_id;

                            TextBoxtitle.Text = article.title;
                            DropDownListmenu.SelectedValue = article.menu_id.ToString();
                            TextBoxwriter.Text = article.writer;
                            TextBoxContent.Text = article.text;
                        }
                    }
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            int article_id = Tool.Tool.Obj2Int(ViewState["article_id"]);
            using (var ctx = new Models.实验二Entities())
            {
                var article = ctx.文章页面表.Where(s => s.id == article_id).FirstOrDefault();
                if (article != null)
                {
                    article.title = TextBoxtitle.Text.Trim();
                    article.menu_id = Tool.Tool.Obj2Int(DropDownListmenu.SelectedValue);
                    article.writer = TextBoxwriter.Text.Trim();
                    article.text = TextBoxContent.Text.Trim();

                    ctx.SaveChanges();

                    Response.Redirect("article_list.aspx");
                }
            }
        }
    }
}