using Entities.Models.Dao.Impl;
using System;
using System.Text;


namespace Entities.Models.Dao
{
    public class DaoFactory
    {
        public static IProdutoDao CreateProdutoDao()
        {
            return new ProdutoDaoImpl();
        }
    }
}