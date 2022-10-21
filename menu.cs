using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Tool
{
    public static class menu
    {
        public static List<Models.菜单界面表> GetMenuList(int? menu_id)
        {
            using (var ctx = new Models.实验二Entities())
            {
                var listmenu = ctx.菜单界面表.OrderBy(s => s.sort_id).ToList();
                var listresult = new List<Models.菜单界面表>();
                var list = listmenu.Where(s => s.menu_id == menu_id).ToList();
                if (list != null)
                {
                    foreach (Models.菜单界面表 menu in list)
                    {
                        listresult.Add(menu);

                        if (listmenu.Count(s => s.menu_id == menu.id) > 0)
                        {
                            GetMenu(listmenu, listresult, menu.id, 1);
                        }
                    }
                }
                return listresult;
            }

        }

        private static void GetMenu(List<Models.菜单界面表> listmenu, List<Models.菜单界面表> listresult, int? menu_id, int depth)
        {
            var list = listmenu.Where(s => s.menu_id == menu_id).ToList();
            if (list != null)
            {
                foreach (Models.菜单界面表 menu in list)
                {
                    menu.title = "┗" + Tool.ReStr("━", depth) + menu.title;

                    listresult.Add(menu);

                    if (listmenu.Count(s => s.menu_id == menu.id) > 0)
                    {
                        GetMenu(listmenu, listresult, menu.id, depth + 1);
                    }
                }
            }
        }
    }
}