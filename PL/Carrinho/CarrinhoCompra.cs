using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PL.Carrinho
{
    public class CarrinhoCompra
    {

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }

        private readonly SecondHandContext _context;

    
        public CarrinhoCompra(SecondHandContext contexto)
        {
            _context = contexto;
        }
        
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            ISession session =
                services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
 
            var context = services.GetService<SecondHandContext>();

            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();

            session.SetString("CarrinhoId", carrinhoId);

            return new CarrinhoCompra(context)
            {
                CarrinhoCompraId = carrinhoId
            };
        }

        public void AdicionarAoCarrinho(Produto produto , int quantidade)
        {
            var carrinhoCompraItem =
                    _context.CarrinhoCompraItens.SingleOrDefault(
                        s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoCompraId == CarrinhoCompraId);

            if (carrinhoCompraItem == null)
            {
                carrinhoCompraItem = new CarrinhoCompraItem
                {
                    CarrinhoCompraId = CarrinhoCompraId,
                    Produto = produto,
                    Quantidade = 1
                };

                _context.CarrinhoCompraItens.Add(carrinhoCompraItem);
            }
            else
            {
                carrinhoCompraItem.Quantidade++;
            }
           
            _context.SaveChanges();
        }
        public void LimparCarrinho()
        {
            var carrinhoItens = _context.CarrinhoCompraItens
                                 .Where(carrinho => carrinho.CarrinhoCompraId == CarrinhoCompraId);

            _context.CarrinhoCompraItens.RemoveRange(carrinhoItens);

            _context.SaveChanges();
        }

        public int RemoverDoCarrinho(Produto produto)
        {
            var carrinhoCompraItem =
                    _context.CarrinhoCompraItens.SingleOrDefault(
                        s => s.Produto.ProdutoId == produto.ProdutoId && s.CarrinhoCompraId == CarrinhoCompraId);

            var quantidadeLocal = 0;

            if (carrinhoCompraItem != null)
            {
                if (carrinhoCompraItem.Quantidade > 1)
                {
                    carrinhoCompraItem.Quantidade--;
                    quantidadeLocal = carrinhoCompraItem.Quantidade;
                }
                else
                {
                    _context.CarrinhoCompraItens.Remove(carrinhoCompraItem);
                }
            }
            produto.Status = Status.DISPONIVEL;
            _context.SaveChanges();

            return quantidadeLocal;
        }

        public decimal GetCarrinhoCompraTotal()
        {
            var total = _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                .Select(c => c.Produto.Preco * c.Quantidade).Sum();

            return total;
        }

        public List<CarrinhoCompraItem> GetCarrinhoCompraItens()
        {
            return CarrinhoCompraItens ??
                   (CarrinhoCompraItens =
                       _context.CarrinhoCompraItens.Where(c => c.CarrinhoCompraId == CarrinhoCompraId)
                           .Include(s => s.Produto)
                           .ToList());
        }        
    }
}

 

