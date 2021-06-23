using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Entities.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Display(Name = "Produto")]
        public String Nome { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Display(Name = "Status da Venda")]
        public Status Status { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public string Cidade { get; set; }

        
        
        public virtual ApplicationUser Usuario { get; set; }

   
        [Display(Name = "Data da Venda")]
        public DateTime? DataVenda { get; set; }


        [Display(Name = "Comprador")]
        public string NomeComprador { get; set; }
        public string IdComprador { get; set; }


        [Display(Name = "Vendedor")]
        public string NomeVendedor { get; set; }
        public string IdVendedor { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }





    }
}