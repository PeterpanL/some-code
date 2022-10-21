using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin
{
    public partial class article_add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var ctx = new Models.实验二Entities())
                {
                    DropDownListmenu.DataSource = ctx.菜单界面表.OrderBy(s => s.sort_id).ToList();
                    DropDownListmenu.DataBind();
                }
            }
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            using (var ctx = new Models.实验二Entities())
            {
                var article = new Models.文章页面表();
                article.id = ctx.文章页面表.Select(s => s.id).DefaultIfEmpty().Max() + 1;
                article.title = TextBoxtitle.Text.Trim();
                article.menu_id = Convert.ToInt32(DropDownListmenu.SelectedValue);
                article.writer = TextBoxwriter.Text.Trim();
                article.add_time = DateTime.Now;
                article.click = 0;
                article.text = TextBoxContent.Text;

                ctx.文章页面表.Add(article);
                if (ctx.SaveChanges() > 0)
                {
                    LabelAlert.Text = "添加成功";
                }
                else
                {
                    LabelAlert.Text = "添加失败";
                }
            }
        }
    }
}