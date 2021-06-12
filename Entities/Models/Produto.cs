﻿using System;
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

        [Required]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Display(Name = "Data da Venda")]
        public DateTime? DataVenda { get; set; }

        public virtual ICollection<Imagem> Imagens { get; set; }





    }
}