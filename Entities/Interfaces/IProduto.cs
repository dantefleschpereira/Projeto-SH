using Entities.Models;

namespace Entities.Interfaces
{
    public interface IProduto
    {        
        Produto GetProdutoById(int produtoId);
    }
}