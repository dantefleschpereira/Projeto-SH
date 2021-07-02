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
    public class AdminCategoriasController : Controller
    {
        private readonly CategoriaFacade _categoriaFacade;

        public AdminCategoriasController(CategoriaFacade categoriaFacade)
        {
            _categoriaFacade = categoriaFacade;
        }
     
        public async Task<IActionResult> Index()
        {
            return View(await _categoriaFacade.ListAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaId,Nome")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaFacade.Create(categoria);
                return RedirectToAction(nameof(Index));
            }
            return View(categoria);
        }
           
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _categoriaFacade.EditById(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaId,Nome")] Categoria categoria)
        {
            if (id != categoria.CategoriaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   await _categoriaFacade.EditByIdAndObject(id, categoria);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.CategoriaId))
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
            return View(categoria);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _categoriaFacade.DetailsById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaFacade.DeleteById(id);
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _categoriaFacade.CategoriaExists(id);
        }
    }
}
