using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolEntities
{
    [Table("TbNivelAcesso")]
    public class NivelAcesso
    {
        [Key]
        [Column("IdNivel")]
        public int IdNivel { get; set; }

        [Column("Descricao")]
        public string Descricao { get; set; }

        [Column("Sigla")]
        public string Sigla { get; set; }
    }
}
