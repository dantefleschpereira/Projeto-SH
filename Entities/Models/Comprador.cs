using System;
using System.Text;


namespace Entities.Models
{
    public class Comprador 
    {
        public int CompradorId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Senha { get; set; }
        public int EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
    }
}