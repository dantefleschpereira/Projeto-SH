using Entities.Models;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BLL
{
    public class ProdutoFacade
    {
        private readonly ProdutoDao _produtoDao;

        public ProdutoFacade(ProdutoDao produtoDao)
        {
            _produtoDao = produtoDao;
        }

        public async Task<List<Produto>> ListAll(ApplicationUser usuario) => await _produtoDao.ListAll(usuario);
        public async Task<Produto> DetailsById(int? id) => await _produtoDao.DetailsById(id);
        public async Task Create(Produto produto, ApplicationUser usuario) => await _produtoDao.Create(produto, usuario);
        public async Task<Produto> EditById(int? id) => await _produtoDao.EditById(id);
        public async Task<Produto> EditByIdAndObject(int id, Produto produto) => await _produtoDao.EditByIdAndObject(id, produto);
        public async Task DeleteById(int? id) => await _produtoDao.DeleteById(id);
        public bool ProdutoExists(int id) => _produtoDao.ProdutoExists(id);
        public IQueryable<Produto> BuscarProdutoPorPalavra(string palavra) => _produtoDao.FindProductByKeyword(palavra);
        public IQueryable<Produto> BuscarProdutoPorPalavraCategoria(string palavra) => _produtoDao.FindProductByCatByKeyword(palavra);
        public List<Produto> EncontrarProdutoPorCategoriaId(int categoriaId) => _produtoDao.FindProdutoByCategoriaId(categoriaId);        
        public List<Produto> EncontrarProdutoPorPalavraChavePorCategoriaId(string palavra, int categoriaId) => _produtoDao.FindProductByKeywordAndCategoriaId(palavra, categoriaId);      
        public List<Produto> ListaDeProduto() => _produtoDao.ListaDeProdutos();       
        public async Task<List<Produto>> ListaProdutosAsync() => await _produtoDao.ListaDeProdutosAsync();
        public IQueryable<Produto> EncontrarProdutoPorFaixaDeValores(decimal valorInicial, decimal valorFinal) => _produtoDao.FindProdutoByFaixa(valorInicial, valorFinal);        
        public IQueryable<Produto> ProdutosQuery() => _produtoDao.Produtos();       
        public async Task<Produto> ProdutoById(int? id) => await _produtoDao.GetProdutoById(id);
        public IQueryable<String> IQueryPesquisaCateg() => _produtoDao.IQueryPesquisaCat();
        public void Comprar(int id, string nomeUsuario) => _produtoDao.ComprarProduto(id, nomeUsuario);
        public void ConfirmarVendaProduto(int id) => _produtoDao.ConfirmarVenda(id);
        public void CancelarVendaProduto(int id) => _produtoDao.CancelarVenda(id);
        public async Task<List<Produto>> ProdutosEmNegociacao(ApplicationUser usuario) => await _produtoDao.ListaDeProdutosNegociacao(usuario);
        public async Task<List<Produto>> BuscarHistoricoProdutos(string IdComprador) => await _produtoDao.HistoricoProdutos(IdComprador);

        //public Imagem GetImage(int id) => _produtoDao.GetImage(id);
        //public void SaveImagem(Imagem im) => _produtoDao.SaveImagem(im);
        //public async Task<Produto> ProdutoImagem(int ProdutoId) => await _produtoDao.ProdutoImagem(ProdutoId);
    }
}
