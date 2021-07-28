using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Usuário não informado!")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Senha não informada!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
