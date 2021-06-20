using Entities.Interfaces;
using Entities.Models;
using Entities.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL
{
    public class ProdutoDao : IProduto
    {
        private readonly SecondHandContext _context;

        public ProdutoDao(SecondHandContext context)
        {
            _context = context;
        }

        public SecondHandContext GetContext()
        {
            return _context;
        }

        public async Task<List<Produto>> ListAll()
        {
            var produtos = (from p in _context.Produtos
                         .Include(u => u.Usuario)
                         .Include(c => c.Categoria)
                         .Include(i => i.Imagens)
                            where p.Status == Status.DISPONIVEL
                            select p);
            return await produtos.ToListAsync();
        }


        public async Task<Produto> DetailsById(int? id)
        {

            var produto = await _context.Produtos.Include("Imagens")
                .Include(p => p.Categoria)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);

            return produto;
        }

        public async Task Create(Produto produto)
        {
            _context.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task<Produto> EditById(int? id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task<Produto> EditByIdAndObject(int id, Produto produto)
        {
            _context.Update(produto);
            await _context.SaveChangesAsync();

            return produto;
        }

        public async Task<Produto> GetToDeleteById(int? id)
        {
            var item = await _context.Produtos.FirstOrDefaultAsync(m => m.ProdutoId == id);

            return item;
        }

        public async Task DeleteById(int? id)
        {
            var item = await _context.Produtos.FirstOrDefaultAsync(m => m.ProdutoId == id);
            _context.Produtos.Remove(item);
            await _context.SaveChangesAsync();
        }

        public bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
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
                                    .Include(c => c.Categoria)
                             where p.CategoriaId == categoriaId
                             && p.Status == Status.DISPONIVEL
                             select p);

                return itens.ToList();
            }
        }

        // 2. Itens a venda dada uma palavra chave e uma categoria.
        public List<Produto> FindProductByKeywordAndCategoriaId(string palavra, int categoriaId)
        {
            var itens = (from p in _context.Produtos.Include(c => c.Categoria)
                         where p.Descricao.Contains(palavra) || p.Nome.Contains(palavra)
                         where p.CategoriaId == categoriaId
                         && p.Status == Status.DISPONIVEL
                         select p);

            return itens.ToList();
        }




        // 2. Itens a venda dentro de uma faixa de valores.
        public List<Produto> FindProdutoByFaixa(decimal valorInicial, decimal valorFinal)
        {
            var itens = (from p in _context.Produtos
                         where p.Status == Status.DISPONIVEL
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
                         select p).OrderByDescending(s => s.Status);

            return itens.ToList();

        }


        // 3. Número total de itens vendidos num período e o valor total destas vendas.
        public List<Entities.ViewModels.RelProdutosVendidos> RelatorioVendasPeriodo(DateTime inicial, DateTime final)
        {

            var itens = from p in _context.Produtos.Include(u => u.Usuario)
                        where p.Status == Status.VENDIDO
                        where p.DataVenda >= inicial && p.DataVenda <= final
                        group p by p.Status into grpPro
                        select new RelProdutosVendidos
                        {
                            Quantidade = grpPro.Count(),
                            Valor = grpPro.Sum(e => e.Preco)

                        };
            return itens.ToList();
        }

        public List<Produto> ListaDeProdutos()
        {
            var itens = (from p in _context.Produtos
                         .Include(u => u.Usuario)
                         .Include(c => c.Categoria)
                         .Include(i => i.Imagens)
                         where p.Status == Status.DISPONIVEL
                         select p);

            return itens.ToList();
        }

        public  IEnumerable<Produto> Produtos()
        {
            return _context.Produtos.Include(c => c.Categoria);
        }

        public async Task<Produto> GetProdutoById(int? id)
        {
            var produto = await _context.Produtos.Include("Imagens")
                .Include(p => p.Categoria)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);

            return produto;
        }

        public Produto GetProdutoById(int produtoId)
        {
            return _context.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
        }

        public IQueryable<String> IQueryPesquisaCat()
        {
            IQueryable<String> categoriaQuery = from m in _context.Produtos
                                                orderby m.Categoria.Nome
                                                select m.Categoria.Nome;

            return categoriaQuery;
        }


    }




    /*
    public Imagem GetImage(int id)
    {
        Imagem im = _context.Imagem.Find(id);
        return im;
    }

    public void SaveImagem(Imagem im)
    {
        _context.Imagem.Add(im);
        _context.SaveChanges();
    }

    public async Task <Produto> ProdutoImagem(int ProdutoId)
    {
        var produto = await  _context.Produtos.Include("Imagens")
                     .FirstOrDefaultAsync(m => m.ProdutoId == ProdutoId);

        return produto;
    }
    */
}
