using Entities.Models;
using PL;
using System.Collections.Generic;

namespace BLL
{
    public class NegocioFacade
    {

        private readonly ProdutoDao _dao;

        public NegocioFacade(ProdutoDao dao)
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

       

    }
}