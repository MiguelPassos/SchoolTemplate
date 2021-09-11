using SchoolTemplate.Models;
using System.Text;

namespace SchoolTemplate.Helpers
{
    public class MenuHelper
    {
        public static string MenuFor(MenuModelView menuModelView)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (!string.IsNullOrWhiteSpace(menuModelView.ActionName))
            {
                if(menuModelView.OptionalId != null)
                    stringBuilder.Append($"<li><a href=\"/{menuModelView.ControllerName}/{menuModelView.ActionName}/{menuModelView.OptionalId}\">{menuModelView.Text}</a></li>");
                else
                    stringBuilder.Append($"<li><a href=\"/{menuModelView.ControllerName}/{menuModelView.ActionName}\">{menuModelView.Text}</a></li>");
            }
            else
            {
                stringBuilder.Append($"<li><a href=\"#\">{menuModelView.Text}</a><ul>");
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
