using Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWeb.Models
{
    public class ProdutoCategoriaVM
    {
        public List<Produto> Produtos { get; set; }
        public SelectList Categorias { get; set; }
        public string Categoria { get; set; }
        public string SearchString { get; set; }
    }
}
