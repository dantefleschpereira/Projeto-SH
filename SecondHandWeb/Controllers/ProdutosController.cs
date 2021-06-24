using BLL;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PL;
using SecondHandWeb.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWeb.Controllers
{
    [Authorize(Roles = "User, Administrador")]
    public class ProdutosController : Controller
    {
        private readonly SecondHandContext _context;
        private readonly ProdutoFacade _produtoFacade;
        public readonly UserManager<ApplicationUser> _userManager;

        public ProdutosController(SecondHandContext context,
                                    UserManager<ApplicationUser> userManager,
                                    ProdutoFacade produtoFacade)
        {
            _context = context;
            _produtoFacade = produtoFacade;
            _userManager = userManager;
            
        }

        public async Task<IActionResult> Index(string categoria, string searchString)
        {
          
            IQueryable<String> categoriaQuery = _produtoFacade.IQueryPesquisaCateg();

            var produtos = _produtoFacade.ProdutosQuery();

            if (!string.IsNullOrEmpty(searchString))
            {
                produtos = _produtoFacade.BuscarProdutoPorPalavra(searchString);
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                //produtos = _produtoFacade.BuscarProdutoPorPalavraCategoria(categoria);
               produtos = produtos.Where(x => x.Categoria.Nome.Equals(categoria));
            }
            
            var produtoCategoriaVM = new ProdutoCategoriaVM
            {
                Categorias = new SelectList(await categoriaQuery.Distinct().ToListAsync()),
                Produtos = await produtos.ToListAsync()
            };

            return View(produtoCategoriaVM);
        }
               

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }
         
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoFacade.DetailsById(id);

            if (produto == null)
            {
                return NotFound();
            }
            return View(produto);
        }      
       
        private bool ProdutoExists(int id)
        {
            return _produtoFacade.ProdutoExists(id);
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

        public async Task<IActionResult> Comprar(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            var usuario = await _userManager.GetUserAsync(HttpContext.User);
            var produto = await _produtoFacade.ProdutoById(id);
            _produtoFacade.Comprar(id, usuario.Nome);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }

    }
}
