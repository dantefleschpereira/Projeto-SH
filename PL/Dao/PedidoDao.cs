using Entities.Models;
using Microsoft.EntityFrameworkCore;
using PL.Carrinho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL
{
    public class PedidoDao
    {
        private readonly SecondHandContext _context;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoDao(SecondHandContext context, CarrinhoCompra carrinhoCompra)
        {
            _context = context;
            _carrinhoCompra = carrinhoCompra;
        }

        public void CriarPedido(Pedido pedido)
        {

            pedido.PedidoCompra = DateTime.Now;

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            var carrinhoCompraItens = _carrinhoCompra.CarrinhoCompraItens;

            foreach (var carrinhoItem in carrinhoCompraItens)
            {
                var pedidoDetail = new PedidoDetalhe()
                {
                    Quantidade = carrinhoItem.Quantidade,
                    ProdutoId = carrinhoItem.Produto.ProdutoId,
                    PedidoId = pedido.PedidoId,
                    Preco = carrinhoItem.Produto.Preco
                };
                _context.PedidoDetalhes.Add(pedidoDetail);
            }
            _context.SaveChanges();
        }

        public async Task<List<Pedido>> ListAll()
        {
            return await _context.Pedidos.ToListAsync();
        }

        public async Task<Pedido> DetailsById(int? id)
        {
            return await _context.Pedidos.FirstOrDefaultAsync(m => m.PedidoId == id);
        }

        public async Task Create(Pedido pedido)
        {
            _context.Add(pedido);
            await _context.SaveChangesAsync();
        }
        public async Task<Pedido> EditById(int? id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<Pedido> EditByIdAndObject(int id, Pedido pedido)
        {
            _context.Update(pedido);
            await _context.SaveChangesAsync();

            return pedido;
        }

        public async Task DeleteById(int? id)
        {
            var pedido = await _context.Pedidos.FirstOrDefaultAsync(m => m.PedidoId == id);
            _context.Pedidos.Remove(pedido);
            await _context.SaveChangesAsync();
        }

        public bool PedidoExists(int id)
        {
            return _context.Pedidos.Any(e => e.PedidoId == id);
        }

        public async Task<List<Pedido>> FindCompraByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in _context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoCompra >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoCompra <= maxDate.Value);
            }

            return await resultado
                .Include(p => p.PedidoItens).ThenInclude(p => p.Produto).OrderByDescending(x => x.PedidoCompra).ToListAsync();
        }
    }
}
