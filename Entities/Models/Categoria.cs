﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}