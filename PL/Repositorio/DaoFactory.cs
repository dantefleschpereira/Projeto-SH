using PL.Repositorio;
using System;
using System.Text;


namespace Entities.Models.Dao
{
    public class DaoFactory
    {
        public static IProdutoDao CreateProdutoDao()
        {
            return new ProdutoEF();
        }
    }
}