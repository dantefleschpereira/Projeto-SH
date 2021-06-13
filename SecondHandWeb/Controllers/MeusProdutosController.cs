using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities.Models;
using PL;
using BLL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Entities.ViewModels;

namespace SecondHandWeb.Controllers
{
    [Authorize]
    public class MeusProdutosController : Controller
    {
        private readonly SecondHandContext _context;
        private readonly NegocioFacade _negocioFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;


        public MeusProdutosController(SecondHandContext context, NegocioFacade negocioFacade,
                                    UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            _negocioFacade = negocioFacade;
            _userManager = userManager;
            _environment = environment;
        }

        // GET: Produtos
        public IActionResult Index()
        {
            List<Produto> produtos = _negocioFacade.ListaDeProduto();
            return View(produtos);
        }


        public IActionResult List()
        {
            ViewBag.Produto = "Produtos";
            ViewData["Categoria"] = "Categoria";

            var produtoListViewModel = new ProdutoListViewModel();
            produtoListViewModel.Produtos = _negocioFacade.ListaDeProduto();
            produtoListViewModel.CategoriaAtual = "Categoria Atual";
            return View(produtoListViewModel);
        }

        /*
        public IActionResult List(string categoria)
        {
            string _categoria = categoria;
            IEnumerable<Produto> produtos;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                produtos = _negocioFacade.ListaDeProduto().OrderBy(p => p.ProdutoId);
                categoriaAtual = "Todos os produtos";
            }
            else
            {

                produtos = _negocioFacade.ListaDeProduto()
                           .Where(p => p.Categoria.Nome.Equals(categoria))
                           .OrderBy(p => p.Nome);

                categoriaAtual = categoria;
            }

            var produtoListViewModel = new ProdutoListViewModel
            {
                Produtos = produtos,
                CategoriaAtual = categoriaAtual
            };

            return View(produtoListViewModel);
        }
        */

        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.Include("Imagens")
                .Include(p => p.Categoria)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // GET: Produtos/Create
        public async Task<IActionResult> Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "Email");

            var usuario = await _userManager.GetUserAsync(HttpContext.User);

            Produto novoProduto = new Produto();
            {
                //UsuarioId = usuario.Id;
            }
            return View();
        }

        // POST: Produtos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Descricao,Preco,StatusVenda,CategoriaId,Cidade,UsuarioId,DataVenda")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", produto.UsuarioId);
            return View(produto);
        }

        // GET: Produtos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", produto.UsuarioId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
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
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoExists(produto.ProdutoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaId", produto.CategoriaId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", "UsuarioId", produto.UsuarioId);
            return View(produto);
        }

        // GET: Produtos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _context.Produtos
                .Include(p => p.Categoria)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.ProdutoId == id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.ProdutoId == id);
        }


        public async Task<IActionResult> DadosUsuario()
        {
            var usuario = await _userManager.GetUserAsync(User);
            ViewBag.Id = usuario.Id;
            ViewBag.UserName = usuario.UserName;

            return View();
        }

        public IActionResult ListaDosMeusProdutos()
        {
            List<Produto> produtos = _negocioFacade.ListaDeProduto();
            return View(produtos);
        }


        public ActionResult GetImage(int id)
        {
            Imagem im = _context.Imagem.Find(id);
            if (im != null)
            {
                return File(im.ImageFile, im.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }


        [HttpPost]
        public async Task<IActionResult> LoadFiles(int ProdutoId,
            List<Microsoft.AspNetCore.Http.IFormFile> files)
        {
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    Imagem im = new Imagem();
                    im.ProdutoId = ProdutoId;
                    im.ImageMimeType = formFile.ContentType;
                    im.ImageFile = new byte[formFile.Length];

                    using (var stream = new System.IO.MemoryStream())
                    {
                        await formFile.CopyToAsync(stream);
                        im.ImageFile = stream.ToArray();

                    }
                    _context.Imagem.Add(im);
                }

                _context.SaveChanges();

            }

            var produto = await _context.Produtos.Include("Imagens")
                         .FirstOrDefaultAsync(m => m.ProdutoId == ProdutoId);

            return View("Details", produto);
        }

    }
}
