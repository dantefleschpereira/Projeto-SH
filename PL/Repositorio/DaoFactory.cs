using PL.Repositorio;
using System;
using System.Text;


namespace PL.Repositorio
{
    public class DaoFactory
    {
        public static IProdutoDao CreateProdutoDao()
        {
            return new ProdutoEF();
        }
    }
}