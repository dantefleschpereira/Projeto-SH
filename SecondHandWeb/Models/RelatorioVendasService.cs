using Entities.Models;
using Microsoft.EntityFrameworkCore;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWeb.Models
{
    public class RelatorioVendasService
    {
        
        private readonly PedidoDao _pedidoDao;
        public RelatorioVendasService(PedidoDao pedidoDao)
        {
            _pedidoDao = pedidoDao;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate) => await _pedidoDao.FindCompraByDateAsync(minDate, maxDate);
        
           
    }
}
