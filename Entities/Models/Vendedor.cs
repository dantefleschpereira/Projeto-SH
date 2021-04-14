using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Senha { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}