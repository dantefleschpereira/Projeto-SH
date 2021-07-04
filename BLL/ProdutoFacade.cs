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
        public async Task<Produto> DetailsById(int? id) => await _produtoDao.DetailsPorId(id);
        public async Task Create(Produto produto, ApplicationUser usuario) => await _produtoDao.Create(produto, usuario);
        public async Task DeleteById(int? id) => await _produtoDao.DeleteById(id);
        public bool ProdutoExists(int id) => _produtoDao.ProdutoExists(id);
        public IQueryable<Produto> BuscarProdutoPorPalavra(string palavra) => _produtoDao.FindProductByKeyword(palavra);
        public async Task<List<Produto>> BuscarListaTodosProdutosAsync() => await _produtoDao.ListaDeTodosProdutosAsync();
        public IQueryable<Produto> EncontrarProdutoPorFaixaDeValores(decimal valorInicial, decimal valorFinal) => _produtoDao.FindProdutoByFaixa(valorInicial, valorFinal);        
        public IQueryable<Produto> ProdutosQuery() => _produtoDao.Produtos();       
        public async Task<Produto> ProdutoById(int? id) => await _produtoDao.GetProdutoById(id);
        public IQueryable<String> IQueryPesquisaCateg() => _produtoDao.IQueryPesquisaCat();
        public void Comprar(int id, string nomeUsuario) => _produtoDao.ComprarProduto(id, nomeUsuario);
        public void ConfirmarVendaProduto(int id) => _produtoDao.ConfirmarVenda(id);
        public void CancelarVendaProduto(int id) => _produtoDao.CancelarVenda(id);
        public async Task<List<Produto>> ProdutosEmNegociacao(ApplicationUser usuario) => await _produtoDao.ListaDeProdutosNegociacao(usuario);
        public async Task<List<Produto>> BuscarHistoricoProdutos(string IdComprador) => await _produtoDao.HistoricoProdutos(IdComprador);
        public Imagem GetImagem(int id) => _produtoDao.BuscarImage(id);
        public void SalvarImagem(Imagem im) => _produtoDao.SaveImagem(im);
        public void addQuestion(QuestionAnswer qa) => _produtoDao.addQuestion(qa);
    }
}
