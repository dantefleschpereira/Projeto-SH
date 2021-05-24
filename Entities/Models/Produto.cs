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
        [Required]
        public String Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        [Required]
        public decimal Preco { get; set; }

        [Display(Name = "Status da Venda")]
        public StatusVenda StatusVenda { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Display(Name = "Data da Venda")]
        public DateTime? DataVenda { get; set; }
   
        


    }
}