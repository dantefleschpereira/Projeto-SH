using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Entities.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        [Display(Name = "Categoria")]
        [Required]
        public string Nome { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}