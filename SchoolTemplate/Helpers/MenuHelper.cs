using SchoolBusiness.Interfaces;
using SchoolEntities.Enumerators;
using SchoolTemplate.Models;
using SchoolTemplate.UtilityServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SchoolTemplate.Helpers
{
    public class MenuHelper
    {
        private static List<MenuModelView> UserMenuItems;

        public static void SetUserMenuItems(List<MenuModelView> menuModelViews)
        {
            UserMenuItems = menuModelViews;
        }

        public static string GenerateMenu()
        {
            StringBuilder htmlMenu = new StringBuilder();

            foreach (var menuItem in UserMenuItems)
            {
                htmlMenu.Append(MenuFor(menuItem));
            }

            return htmlMenu.ToString();
        }

        private static string MenuFor(string controller, string action, int? optionalId)
        {
            StringBuilder stringBuilder = new StringBuilder();

            return stringBuilder.ToString();
        }

        private static string MenuFor(MenuModelView menuModelView)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!menuModelView.SubMenus.Any())
            {
                if(menuModelView.OptionalId != null)
                    stringBuilder.Append($"<li><a href=\"/{menuModelView.ControllerName}/{menuModelView.ActionName}/{menuModelView.OptionalId}\">{menuModelView.Text}</a></li>");
                else
                    stringBuilder.Append($"<li><a href=\"/{menuModelView.ControllerName}/{menuModelView.ActionName}\">{menuModelView.Text}</a></li>");
            }
            else
            {
                stringBuilder.Append($"<li><a>{menuModelView.Text}</a><ul>");

                foreach (MenuModelView subMenu in menuModelView.SubMenus)
                {
                    stringBuilder.Append(MenuFor(subMenu));
                }

                stringBuilder.Append("</ul></li>");
            }

            return stringBuilder.ToString();
        }
    }
}
