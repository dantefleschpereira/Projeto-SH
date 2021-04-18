using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.Models
{
    public interface IProdutoDao
    {
        ICollection <Produto> FindAll(int CategoriaId);  
    }
}