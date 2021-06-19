using System;
using Entities.Models;
using System.Collections.Generic;
using System.Text;
using Entities.ViewModels;

namespace Entities.Interfaces
{
    public interface IProduto
    {
        
        Produto GetProdutoById(int produtoId);
    }
}