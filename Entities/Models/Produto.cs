using System;
using System.Text;


namespace Entities.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public String Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public StatusVenda StatusVenda { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CidadeId { get; set; }
        public Cidade Cidade { get; set; }
        public int CompradorId { get; set; }
        public int VendedorId { get; set; }
        public virtual Usuario Usuario { get; set; }
   
        


    }
}