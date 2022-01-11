using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.Models
{
    public class UserViewModel
    {
        public int ID{ get; set; }

        public string UserName { get; set; }

        [Required(ErrorMessage = "Login não informado!")]
        public string UserLogin { get; set; }

        [Required(ErrorMessage = "Senha não informada!")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }

        public string Role { get; }

        public UserViewModel()
        {
        }

        public UserViewModel(string role)
        {
            Role = role;
        }
    }
}
