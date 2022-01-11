using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolEntities
{
    [Table("TbMenu")]
    public class MenuItem
    {
        [Column("IdMenu")]
        public int IdMenu { get; set; }

        [Column("IdMenuPai")]
        public int IdMenuPai { get; set; }

        [Column("Texto")]
        public string Texto { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("ControllerName")]
        public string ControllerName { get; set; }

        [Column("ActionName")]
        public string ActionName { get; set; }

        [Column("OptionalId")]
        public int? OptionalId { get; set; }

        [Column("Icone")]
        public string Icone { get; set; }

        [Column("Ordem")]
        public int Ordem { get; set; }

        public List<MenuItem> SubMenus { get; set; }

        public MenuItem()
        {
            SubMenus = new List<MenuItem>();
        }
    }
}
