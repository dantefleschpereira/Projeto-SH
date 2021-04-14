using System;
using System.Text;


namespace Entities.Models
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string Cep { get; set; }
        public string Rua { get; set; }
        public int Número { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int CidadeId { get; set; }
        public virtual Cidade Cidade { get; set; }
    }
}