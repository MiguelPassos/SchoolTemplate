using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolTemplate.Models
{
    public class UserViewModel
    {
        private int id;
        private string userName;
        private string userLogin;
        private string password;
        private string document;
        private bool rememberMe;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public string UserName { get => userName; set => userName = value; }

        [Required(ErrorMessage = "Login não informado!")]
        public string UserLogin { get => userLogin; set => userLogin = value; }

        [Required(ErrorMessage = "Senha não informada!")]
        public string Password { get => password; set => password = value; }

        public string Document { get => document; set => document = value.Replace("-","").Replace(".","");   }

        public bool RememberMe { get => rememberMe; set => rememberMe = value; }

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
