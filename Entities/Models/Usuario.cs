using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public String Senha { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }


    }
}

