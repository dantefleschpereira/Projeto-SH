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
    [Authorize(Roles = "Comprador")]
    public class ProdutosController : Controller
    {
        private readonly SecondHandContext _context;
        private readonly ProdutoFacade produtoFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private IWebHostEnvironment _environment;


        public ProdutosController(SecondHandContext context,
                                    UserManager<ApplicationUser> userManager, IWebHostEnvironment environment)
        {
            _context = context;
            produtoFacade = new ProdutoFacade();
            _userManager = userManager;
            _environment = environment;
        }

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await produtoFacade.ListAll());
        }



        // GET: Items/Details/5
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
              

        public async Task<IActionResult> Comprar(int? id)
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


    }
}
