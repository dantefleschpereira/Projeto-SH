using Entities.Models;
using PL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL
{
    public class PedidoFacade
    {
        private readonly PedidoDao _pedidoDao;
        

        public PedidoFacade(PedidoDao pedidoDao)
        {
            _pedidoDao = pedidoDao;
        }

        public void CriarPedido(Pedido pedido) => _pedidoDao.CriarPedido(pedido);
        public async Task<List<Pedido>> ListAll() => await _pedidoDao.ListAll();
        public async Task<Pedido> DetailsById(int? id) => await _pedidoDao.DetailsById(id);
        public async Task Create(Pedido pedido) => await _pedidoDao.Create(pedido);
        public async Task<Pedido> EditById(int? id) => await _pedidoDao.EditById(id);
        public async Task<Pedido> EditByIdAndObject(int id, Pedido pedido) => await _pedidoDao.EditByIdAndObject(id, pedido);
        public async Task DeleteById(int? id) => await _pedidoDao.DeleteById(id);
        public bool PedidoExists(int id) => _pedidoDao.PedidoExists(id);
    }
}
