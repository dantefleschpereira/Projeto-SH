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
        private readonly SecondHandContext context;
        public RelatorioVendasService(SecondHandContext _context)
        {
            context = _context;
        }

        public async Task<List<Pedido>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                .Include(l => l.PedidoItens)
                .ThenInclude(l=> l.Produto)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
        }
    }
}
