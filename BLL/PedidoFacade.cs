using Entities.Models;
using PL;

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
    }
}
