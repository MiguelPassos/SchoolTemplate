using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SchoolEntities
{
    [Table("TbFuncionario")]
    public class Funcionario
    {
        [Column("IdFuncionario")]
        public int IdFuncionario { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Sobrenome")]
        public string Sobrenome { get; set; }

        [Column("Nascimento")]
        public DateTime Nascimento { get; set; }

        [Column("Naturalidade")]
        public string Naturalidade { get; set; }

        [Column("NaturalidadeUF")]
        public string NaturalidadeUF { get; set; }

        [Column("Nacionalidade")]
        public string Nacionalidade { get; set; }

        [Column("Endereco")]
        public string Endereco { get; set; }

        [Column("Bairro")]
        public string Bairro { get; set; }

        [Column("Cidade")]
        public string Cidade { get; set; }

        [Column("UF")]
        public string UF { get; set; }

        [Column("CEP")]
        public string CEP { get; set; }

        [Column("RG")]
        public string RG { get; set; }

        [Column("CTPS")]
        public string CTPS { get; set; }

        [Column("SerieCTPS")]
        public string SerieCTPS { get; set; }

        [Column("Cargo")]
        public int IdCargo { get; set; }

        [Column("Departamento")]
        public int IdDepartamento { get; set; }

        [Column("Usuario")]
        public int? IdUsuario { get; set; }
    }
}
