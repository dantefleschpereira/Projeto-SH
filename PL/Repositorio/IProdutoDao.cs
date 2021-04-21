using System;
using Entities.Models;
using System.Collections.Generic;
using System.Text;


namespace PL.Repositorio
{
    public interface IProdutoDao
    {
        List<Produto> FindAll(int CategoriaId);  
    }
}