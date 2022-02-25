using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolEntities
{
    public class Evento
    {
        public int IdEvento { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Imagem { get; set; }

        public string Autor { get; set; }

        public DateTime DataInicio { get; set; }

        public DateTime DataTermino { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
