using System;
using Entities.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text;


namespace PL.Repositorio
{
    public class ProdutoEF : IProdutoDao
    {
        private readonly SecondHandContext _context;

        public ProdutoEF()
        {
            _context = new SecondHandContext();
        }

        public List<Produto> FindCategoriaById(int Id) //itens a venda de uma determinada categoria
        {

            {
                var CategoriaId = Id;

                var itens = (from p in _context.Produtos
                                    .Include(c => c.Categoria)
                             where p.CategoriaId == CategoriaId
                             select p);

                return itens.ToList();
            }
        }
    }
}