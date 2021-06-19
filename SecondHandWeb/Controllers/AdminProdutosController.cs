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

        // GET: AdminProdutos
        public async Task<IActionResult> Index()
        {
            return View(await produtoFacade.ListAll());
        }

        // GET: AdminProdutos/Details/5
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

        // GET: AdminProdutos/Create
        // GET: Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminProdutos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Descricao,Preco,StatusVenda,CategoriaId,Cidade,UsuarioId,DataVenda")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                await produtoFacade.Create(produto);
                return RedirectToAction(nameof(Index));
            }
            return View(produto);
        }

        // GET: AdminProdutos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await produtoFacade.EditById(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }

        // POST: AdminProdutos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Descricao,Preco,StatusVenda,CategoriaId,Cidade,UsuarioId,DataVenda")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await produtoFacade.EditByIdAndObject(id, produto);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!produtoFacade.ProdutoExists(produto.ProdutoId))
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
            return View(produto);
        }

        // GET: AdminProdutos/Delete/5
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

        // POST: Items/Delete/5
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
