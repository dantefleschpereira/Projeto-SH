using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using PL;
using Microsoft.AspNetCore.Authorization;
using BLL;

namespace SecondHandWeb.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class AdminPedidosController : Controller
    {

        private readonly PedidoFacade _pedidoFacade;

        public AdminPedidosController(PedidoFacade pedidoFacade)
        {
            _pedidoFacade = pedidoFacade;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pedidoFacade.ListAll());
        }

 
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _pedidoFacade.DetailsById(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }
    
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PedidoId,Nome,Sobrenome,Endereco1,Endereco2,Cep,Estado,Cidade,Telefone,Email,PedidoEnviado,PedidoEntregueEm")] Pedido pedido)
        {
            if (ModelState.IsValid)
            {
                await _pedidoFacade.Create(pedido);
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _pedidoFacade.EditById(id);
            if (pedido == null)
            {
                return NotFound();
            }
            return View(pedido);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PedidoId,Nome,Sobrenome,Endereco1,Endereco2,Cep,Estado,Cidade,Telefone,Email,PedidoEnviado,PedidoEntregueEm")] Pedido pedido)
        {
            if (id != pedido.PedidoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _pedidoFacade.EditByIdAndObject(id, pedido);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PedidoExists(pedido.PedidoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(pedido);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pedido = await _pedidoFacade.DetailsById(id);
            if (pedido == null)
            {
                return NotFound();
            }

            return View(pedido);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _pedidoFacade.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool PedidoExists(int id)
        {
            return _pedidoFacade.PedidoExists(id);
        }
    }
}
