using System.Collections.Generic;
using Entities.Interfaces;
using Entities.Models;

namespace BLL
{
    public class NegocioFacade
    {

        private readonly IProdutoDao _dao;

        public NegocioFacade(IProdutoDao dao)
        {
            _dao = dao;
        }

        public void AnunciarProduto(Produto produto)
        {
            _dao.InserirProduto(produto);
        }
        public List<Produto> EncontrarProdutoPorCategoriaId(int categoriaId)
        {
            return _dao.FindProdutoByCategoriaId(categoriaId);
        }
        public List<Produto> EncontrarProdutoPorPalavraChavePorCategoriaId(string palavra, int categoriaId)
        {
            return _dao.FindProductByKeywordAndCategoriaId(palavra, categoriaId);
        }

        public List<Produto> ListaDeProduto()
        {
            return _dao.ListaDeProdutos();
        }

        public List<Produto> EncontrarProdutoPorFaixaDeValores(decimal valorInicial, decimal valorFinal)
        {
            return _dao.FindProdutoByFaixa(valorInicial, valorFinal);
        }

        public IEnumerable<Produto> Produtos()
        {
            return _dao.Produtos();
        }

        public Produto ProdutoById(int produtoId)
        {
            return _dao.GetProdutoById(produtoId);
        }

    }
}