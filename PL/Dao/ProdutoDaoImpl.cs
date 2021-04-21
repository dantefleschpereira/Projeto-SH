using System;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text;


namespace PL.Dao
{
    public class ProdutoDaoImpl : IProdutoDao
    {
        SecondHandContext _context = new SecondHandContext();
        
        public ICollection<Produto> FindAll(int Id) //itens a venda de uma determinada categoria
        {

            {
                var CategoriaId = Id;

                var itens = (from p in _context.Produtos
                                    .Include(c => c.Categoria)
                             where p.CategoriaId == CategoriaId
                             select p);

                ICollection<Produto> produtos = new List<Produto>();
                foreach (var item in itens)
                {
                    produtos.Add(item);
                }

                return produtos;
            }
        }
    }
}