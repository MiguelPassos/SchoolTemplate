using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace SchoolEntities.Enumerators
{
    public enum ENivelAcesso
    {
        [Description("Default")]
        Default = 0,

        [Description("Desenvolvedor")]
        Desenvolvedor = 1,

        [Description("Administrador")]
        Administrador = 2,

        [Description("Pedagógico")]
        Pedagogico = 3,

        [Description("Professor")]
        Professor = 4,

        [Description("Familiar")]
        Familiar = 5
    }
}