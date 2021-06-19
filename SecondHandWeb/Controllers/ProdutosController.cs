using BLL;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PL;
using System.Threading.Tasks;

namespace SecondHandWeb.Controllers
{
    [Authorize(Roles = "Comprador")]
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

        // GET: Items
        public async Task<IActionResult> Index()
        {
            return View(await _produtoFacade.ListAll());
        }



        // GET: Items/Details/5
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
              

        public async Task<IActionResult> Comprar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoFacade.ProdutoById(id);
            if (produto == null)
            {
                return NotFound();
            }

            return View(produto);
        }


    }
}
