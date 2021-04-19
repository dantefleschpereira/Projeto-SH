using System;
using Entities.Models;
using System.Collections.Generic;
using System.Text;


namespace PL.Dao
{
    public interface IProdutoDao
    {
        ICollection <Produto> FindAll(int CategoriaId);  
    }
}