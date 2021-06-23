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
    public class AdminProdutosController : Controller
    {

        private readonly ProdutoFacade produtoFacade;

        public AdminProdutosController(ProdutoFacade _produtoFacade)
        {

            produtoFacade = _produtoFacade;
        }

     
        
        public async Task<IActionResult> Index()
        {
            return View(await produtoFacade.ListaProdutosAsync());
        }
        
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await produtoFacade.DetailsById(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await produtoFacade.DetailsById(id);

            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await produtoFacade.DeleteById(id);

            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return produtoFacade.ProdutoExists(id);
        }
    }
}
