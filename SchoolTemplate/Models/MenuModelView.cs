using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.Models
{
    public class MenuModelView
    {
        public int IdMenu { get; set; }

        public int IdParent { get; set; }

        public string Text { get; set; }

        public string ActionName { get; set; }

        public string ControllerName { get; set; }

        public int? OptionalId { get; set; }

        public List<MenuModelView> SubMenus { get; set; }

        public MenuModelView()
        {
            SubMenus = new List<MenuModelView>();
        }
    }
}
