using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolEntities
{
    [Table("TbPerfilFuncionario")]
    public class PerfilFuncionario
    {
        [Column("IdPerfilFuncionario")]
        public int IdPerfil { get; set; }

        [Column("Funcionario")]
        public int IdFuncionario { get; set; }

        [Column("Imagem")]
        public string Imagem { get; set; }

        [Column("Titulo")]
        public string Titulo { get; set; }

        [Column("Informacoes")]
        public string Informacoes { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
