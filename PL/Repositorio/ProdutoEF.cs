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

        // 1. Usuários do sistema devem poder anunciar itens para venda.
        public void InserirProduto(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();

            if (produto != null)
            {
                Console.WriteLine("Produto anunciado com sucesso! Id do produto: {0}", produto.ProdutoId);
            }
        }


        // 2. Itens a venda de uma determinada categoria.
        public List<Produto> FindProdutoByCategoriaId(int Id)
        {
            {
                var categoriaId = Id;

                var itens = (from p in _context.Produtos
                                    .Include(c => c.Categoria).Include(u => u.Usuario)
                             where p.CategoriaId == categoriaId
                             && p.StatusVenda == StatusVenda.DISPONIVEL
                             select p);

                return itens.ToList();
            }
        }

        // 2. Itens a venda dada uma palavra chave e uma categoria.
        public List<Produto> FindProductByKeywordAndCategoriaId(string palavra, int categoriaId)
        {
            var itens = (from p in _context.Produtos.Include(c => c.Categoria).Include(u => u.Usuario)
                         where p.Descricao.Contains(palavra) || p.Nome.Contains(palavra)
                         where p.CategoriaId == categoriaId
                         && p.StatusVenda == StatusVenda.DISPONIVEL
                         select p);

            return itens.ToList();
        }




        // 2. Itens a venda dentro de uma faixa de valores.
        public List<Produto> FindProdutoByFaixa(decimal valorInicial, decimal valorFinal)
        {
            var itens = (from p in _context.Produtos.Include(u => u.Usuario)
                         where p.StatusVenda == StatusVenda.DISPONIVEL
                         where p.Preco >= valorInicial && p.Preco <= valorFinal
                         select p);

            return itens.ToList();
        }



        // 3. Itens anunciados por um determinado vendedor, agrupados pelo status da venda.
        public List<Produto> FindProdutoVendedorPorStatus(int usuarioId)
        {
            var id = usuarioId;

            var itens = (from p in _context.Produtos.Include(u => u.Usuario)
                         where p.UsuarioId == id
                         select p).OrderByDescending(s => s.StatusVenda);

            return itens.ToList();

        }


        // 3. Número total de itens vendidos num período e o valor total destas vendas.
        public void RelatorioVendasPeriodo(DateTime inicial, DateTime final)
        {

            var itens = (from p in _context.Produtos.Include(u => u.Usuario)
                         where p.StatusVenda == StatusVenda.VENDIDO
                         where p.DataVenda >= inicial && p.DataVenda <= final
                         select p);

            var qtTotal = itens.Count();
            decimal valorTotal = 0;
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Período de análise de vendas {0} até {1}\n", inicial, final);
            foreach (Produto p in itens)
            {
                Console.WriteLine("Produto: {0}\nDescrição: {1}\nPreço: R${2}\nVendedor: {3}\n", p.Nome, p.Descricao, p.Preco.ToString("N2"), p.Usuario.Nome);
                valorTotal += p.Preco;
            }
            Console.WriteLine("\nQuantidade total de produtos vendidos: {0}\t Valor total arrecadado: R${1}"
                , qtTotal, valorTotal.ToString("N2"));
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------------------------");

        }
    }
}