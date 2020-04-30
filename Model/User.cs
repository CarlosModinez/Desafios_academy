using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafios_academy.Model
{
    public class User
    {
        public User()
        {
            Guid guid = Guid.NewGuid();
            this.Id = guid.ToString();
        }
        public string Id { get; set; }

        [Required(ErrorMessage = "Username is required")]
        public string Username {get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password {get; set;  }

        public string Name {get; set; }
       
    }
}
