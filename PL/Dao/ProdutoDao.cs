using Entities.Interfaces;
using Entities.Models;
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


        public async Task<List<Produto>> ListAll(ApplicationUser usuario)
        {
            var produtos = (from p in _context.Produtos
                         .Include(c => c.Categoria)
                         .Include(i => i.Imagens)
                            where p.IdVendedor.Equals(usuario.Id)
                            select p);
            return await produtos.ToListAsync();
        }


        public async Task<Produto> DetailsPorId(int? id)
        {
            var produto = await _context.Produtos
                .Include(i => i.Imagens)
                .Include(p => p.Categoria)
                .Include(q => q.QuestionAnswers).Where(m => m.ProdutoId == id).FirstOrDefaultAsync();

            return produto;
        }

        public async Task Create(Produto produto, ApplicationUser usuario)
        {
            produto.IdVendedor = usuario.Id;
            produto.NomeVendedor = usuario.Nome;
            produto.Status = Status.DISPONIVEL;
            _context.Add(produto);
            await _context.SaveChangesAsync();
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
        
        public IQueryable<Produto> FindProdutoByFaixa(decimal valorInicial, decimal valorFinal)
        {
            var itens = (from p in _context.Produtos
                         .Include(c => c.Categoria)                         
                         where p.Status == Status.DISPONIVEL
                         where p.Preco >= valorInicial && p.Preco <= valorFinal
                         select p);

            return itens;
        }


        public IQueryable<Produto> Produtos()
        {
            var produtos = from p in _context.Produtos.Include("Categoria")
                           where p.Status == Status.DISPONIVEL
                           select p;
            return produtos;
        }

        public async Task<Produto> GetProdutoById(int? id)
        {
            var produto = await _context.Produtos.Include("Imagens")
                .Include(p => p.Categoria)
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

        public IQueryable<Produto> FindProductByKeyword(string searchString)
        {
            var produtos = from p in _context.Produtos.Include("Categoria")
                            .Where(s => s.Nome.Contains(searchString))
                           select p;

            return produtos;
        }

        public IQueryable<Produto> FindProductByCatByKeyword(string categoria)
        {
            var produtos = from p in _context.Produtos.Include("Categoria")
                           .Where(p => p.Categoria.Nome.Equals(categoria))
                           select p;
            return produtos;
        }

        public void ComprarProduto(int Id, string nomeUsuario)
        {
            var user = _context.Users.FirstOrDefault(u => u.Nome.Equals(nomeUsuario));
            var produto = _context.Produtos.First(p => p.ProdutoId == Id);
            if (produto != null && produto.Status == Status.DISPONIVEL)
            {
                produto.NomeComprador = user.Nome;
                produto.IdComprador = user.Id;
                produto.Status = Status.NEGOCIACAO;
                
                _context.Update(produto);
                _context.SaveChanges();
            }
        }

        public void ConfirmarVenda(int Id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == Id);
            if (produto != null)
            {
                produto.Status = Status.VENDIDO;
                produto.DataVenda = DateTime.Now;
                _context.Update(produto);
                _context.SaveChanges();
            }

        }

        public async Task<List<Produto>> HistoricoProdutos(string IdComprador)
        {
            var produtos = from p in _context.Produtos.Include("Categoria")
                         .Where(p => p.Status == Status.NEGOCIACAO || p.Status == Status.VENDIDO || p.Status == Status.CANCELADO)
                         .Where(p => p.IdComprador.Equals(IdComprador))
                           select p;
            return await produtos.ToListAsync();

        }

        public void CancelarVenda(int Id)
        {
            var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == Id);
            if (produto != null)
            {
                produto.Status = Status.CANCELADO;             
                _context.Update(produto);
                _context.SaveChanges();
            }

        }

        public async Task<List<Produto>> ListaDeProdutosNegociacao(ApplicationUser usuario)
        {
            var itens = (from p in _context.Produtos

                         .Include(c => c.Categoria)
                         .Include(i => i.Imagens)
                         where p.Status == Status.NEGOCIACAO
                         where p.IdVendedor.Equals(usuario.Id)
                         select p);

            return await itens.ToListAsync();
        }


        public async Task<List<Produto>> ListaDeTodosProdutosAsync()
        {
            var itens = (from p in _context.Produtos
                         .Include(u => u.Usuario)
                         .Include(c => c.Categoria)
                         .Include(i => i.Imagens)                         
                         select p);

            return await itens.ToListAsync();

        }

        public Imagem BuscarImage(int id)
        {
            Imagem im = _context.Imagem.Find(id);
            return im;
        }

        
        public void SaveImagem(Imagem im)
        {
            _context.Imagem.Add(im);
            _context.SaveChanges();
        }

        public void AddQuestion(QuestionAnswer qa)
        {
            _context.QuestionAnswers.Add(qa);
            _context.SaveChanges();
        }

    }
}
