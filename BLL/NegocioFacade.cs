using Entities.Models;
using PL;
using PL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class NegocioFacade
    {

        private readonly IProdutoDao _dao;

        public NegocioFacade()
        {
            _dao = DaoFactory.CreateProdutoDao();
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

    }
}