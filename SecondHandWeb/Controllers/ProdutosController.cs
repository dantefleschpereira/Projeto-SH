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
    [Authorize]
    public class ProdutosController : Controller
    {
        
        private readonly ProdutoFacade _produtoFacade;
        public readonly UserManager<ApplicationUser> _userManager;

        public ProdutosController(UserManager<ApplicationUser> userManager,
                                    ProdutoFacade produtoFacade)
        {
           
            _produtoFacade = produtoFacade;
            _userManager = userManager;
            
        }

        public async Task<IActionResult> Index(string categoria, string searchString,
                                                decimal precoMin, decimal precoMax)
        {
          
            IQueryable<String> categoriaQuery = _produtoFacade.IQueryPesquisaCateg();

            var produtos = _produtoFacade.ProdutosQuery();

            if (!string.IsNullOrEmpty(searchString))
            {
                produtos = _produtoFacade.BuscarProdutoPorPalavra(searchString);
            }

            if (!string.IsNullOrEmpty(categoria))
            {
             
               produtos = produtos.Where(x => x.Categoria.Nome.Equals(categoria));
            }
            if (precoMin > -1 && precoMax > precoMin)
            {
                produtos = _produtoFacade.EncontrarProdutoPorFaixaDeValores(precoMin, precoMax);
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
            Imagem im = _produtoFacade.GetImagem(id);
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

        public async Task<IActionResult> AddQuestion(int ProdutoId, string qaString)
        {
            var usuario = await _userManager.GetUserAsync(User);

            ViewBag.Id = usuario.Id;
            ViewBag.UserName = usuario.UserName;

            QuestionAnswer novo = new QuestionAnswer()
            {
                Text = qaString,
                User = usuario.UserName,
                ProdutoId = ProdutoId
            };

            _produtoFacade.addQuestion(novo);

            return RedirectToAction("Details", "Produtos", new { Id = ProdutoId });
        }

    }
}
