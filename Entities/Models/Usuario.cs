using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }


        [Display(Name = "Usuário")]
        [Required]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public String Senha { get; set; }



    }
}

