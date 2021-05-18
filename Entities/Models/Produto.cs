using System;
using System.Collections.Generic;
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
        public string Cidade { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime? DataVenda { get; set; }
   
        


    }
}