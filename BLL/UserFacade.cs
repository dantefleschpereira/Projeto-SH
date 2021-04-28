using Entities.Models;
using PL;
using PL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class UserFacade
    {
      
        private readonly IProdutoDao _dao;

        public UserFacade()
        {
            _dao = DaoFactory.CreateProdutoDao();
        }

        public void AnunciarProduto(Produto produto)
        {
            _dao.InserirProduto(produto);
        }

        public List<Produto> EncontrarProdutoPorCategoriaId(int CategoriaId)
        {
            return _dao.FindProdutoByCategoriaId(CategoriaId);
        }

    }
}