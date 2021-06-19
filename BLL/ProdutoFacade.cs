using Entities.Models;
using PL;
using System.Collections.Generic;
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

        public async Task<List<Produto>> ListAll() => await _produtoDao.ListAll();
        public async Task<Produto> DetailsById(int? id) => await _produtoDao.DetailsById(id);
        public async Task Create(Produto produto) => await _produtoDao.Create(produto);
        public async Task<Produto> EditById(int? id) => await _produtoDao.EditById(id);
        public async Task<Produto> EditByIdAndObject(int id, Produto produto) => await _produtoDao.EditByIdAndObject(id, produto);
        public async Task<Produto> GetToDeleteById(int? id) => await _produtoDao.GetToDeleteById(id);
        public async Task DeleteById(int? id) => await _produtoDao.DeleteById(id);
        public bool ProdutoExists(int id) => _produtoDao.ProdutoExists(id);
        //public Imagem GetImage(int id) => _produtoDao.GetImage(id);
        //public void SaveImagem(Imagem im) => _produtoDao.SaveImagem(im);
        //public async Task<Produto> ProdutoImagem(int ProdutoId) => await _produtoDao.ProdutoImagem(ProdutoId);

        public void AnunciarProduto(Produto produto)
        {
            _produtoDao.InserirProduto(produto);
        }
        public List<Produto> EncontrarProdutoPorCategoriaId(int categoriaId)
        {
            return _produtoDao.FindProdutoByCategoriaId(categoriaId);
        }
        public List<Produto> EncontrarProdutoPorPalavraChavePorCategoriaId(string palavra, int categoriaId)
        {
            return _produtoDao.FindProductByKeywordAndCategoriaId(palavra, categoriaId);
        }

        public List<Produto> ListaDeProduto()
        {
            return _produtoDao.ListaDeProdutos();
        }

        public List<Produto> EncontrarProdutoPorFaixaDeValores(decimal valorInicial, decimal valorFinal)
        {
            return _produtoDao.FindProdutoByFaixa(valorInicial, valorFinal);
        }

        public IEnumerable<Produto> Produtos()
        {
            return _produtoDao.Produtos();
        }

        public async Task<Produto> ProdutoById(int? id)
        {
            return await _produtoDao.GetProdutoById(id);
        }

    } 
}
