using Entities.Models;
using PL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProdutoFacade
    {
        private ProdutoDao ProdutoDao;

        public ProdutoFacade()
        {
            ProdutoDao = new ProdutoDao();
        }

        public async Task<List<Produto>> ListAll() => await ProdutoDao.ListAll();
        public async Task<Produto> DetailsById(int? id) => await ProdutoDao.DetailsById(id);
        public async Task Create(Produto produto) => await ProdutoDao.Create(produto);
        public async Task<Produto> EditById(int? id) => await ProdutoDao.EditById(id);
        public async Task<Produto> EditByIdAndObject(int id, Produto produto) => await ProdutoDao.EditByIdAndObject(id, produto);
        public async Task<Produto> GetToDeleteById(int? id) => await ProdutoDao.GetToDeleteById(id);
        public async Task DeleteById(int? id) => await ProdutoDao.DeleteById(id);
        public bool ProdutoExists(int id) => ProdutoDao.ProdutoExists(id);
        //public Imagem GetImage(int id) => ProdutoDao.GetImage(id);
        //public void SaveImagem(Imagem im) => ProdutoDao.SaveImagem(im);
        //public async Task<Produto> ProdutoImagem(int ProdutoId) => await ProdutoDao.ProdutoImagem(ProdutoId);

        public void AnunciarProduto(Produto produto)
        {
            ProdutoDao.InserirProduto(produto);
        }
        public List<Produto> EncontrarProdutoPorCategoriaId(int categoriaId)
        {
            return ProdutoDao.FindProdutoByCategoriaId(categoriaId);
        }
        public List<Produto> EncontrarProdutoPorPalavraChavePorCategoriaId(string palavra, int categoriaId)
        {
            return ProdutoDao.FindProductByKeywordAndCategoriaId(palavra, categoriaId);
        }

        public List<Produto> ListaDeProduto()
        {
            return ProdutoDao.ListaDeProdutos();
        }

        public List<Produto> EncontrarProdutoPorFaixaDeValores(decimal valorInicial, decimal valorFinal)
        {
            return ProdutoDao.FindProdutoByFaixa(valorInicial, valorFinal);
        }

        public IEnumerable<Produto> Produtos()
        {
            return ProdutoDao.Produtos();
        }

        public Produto ProdutoById(int produtoId)
        {
            return ProdutoDao.GetProdutoById(produtoId);
        }

    } 
}
