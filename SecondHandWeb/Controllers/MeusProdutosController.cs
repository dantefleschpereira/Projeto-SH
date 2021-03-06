using BLL;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SecondHandWeb.Controllers
{
    [Authorize]
    public class MeusProdutosController : Controller
    {
        private readonly CategoriaFacade _categoriaFacade;
        private readonly ProdutoFacade _produtoFacade;
        public readonly UserManager<ApplicationUser> _userManager;

        public MeusProdutosController(UserManager<ApplicationUser> userManager,
                                        ProdutoFacade produtoFacade, CategoriaFacade categoriaFacade)
        {
            _produtoFacade = produtoFacade;
            _categoriaFacade = categoriaFacade;
            _userManager = userManager;
            
        }

        public async Task<IActionResult> Index()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);
            return View(await _produtoFacade.ListAll(usuario));
        }

        public async Task<IActionResult> MeusProdutos()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);
            return View(await _produtoFacade.ListAll(usuario));
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
                return Redirect("Index");
            }
            return View(produto);
        }

        public async Task<IActionResult> AddQuestion(int ProdutoId, string qaString)
        {
            var usuario = await _userManager.GetUserAsync(User);

            ViewBag.Id = usuario.Id;
            ViewBag.UserName = usuario.Nome;

            QuestionAnswer novo = new QuestionAnswer()
            {
                Text = qaString,
                User = usuario.Nome,
                ProdutoId = ProdutoId
            };

            _produtoFacade.AddQuestion(novo);

            return RedirectToAction("Details", "MeusProdutos", new { Id = ProdutoId });
        }

        public async Task <IActionResult> Create()
        {
            var usuario = await _userManager.GetUserAsync(HttpContext.User);

            Produto produto = new Produto() { IdVendedor = usuario.Id, NomeVendedor = usuario.Nome};
            
            
            ViewData["CategoriaId"] = new SelectList(_categoriaFacade.Categorias(), "CategoriaId", "Nome", produto.CategoriaId);

            return View();
        }

      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProdutoId,Nome,Descricao,Preco,Status,CategoriaId,Cidade,UsuarioId,DataVenda")] Produto produto, ApplicationUser usuario)
        {

            usuario = await _userManager.GetUserAsync(HttpContext.User);

            await _produtoFacade.Create(produto, usuario);
                return RedirectToAction(nameof(Index));
            
            ViewData["CategoriaId"] = new SelectList(_categoriaFacade.Categorias(), "CategoriaId", "Nome", produto.CategoriaId);

            return View(produto);
        }      
        
     
        public async Task<IActionResult> Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _produtoFacade.DeleteById(id);

            return RedirectToAction(nameof(Index));
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
                   
                    _produtoFacade.SalvarImagem(im);
                }                

            }
            var produto = await _produtoFacade.ProdutoById(ProdutoId);           

            return View("Details", produto);
        }

        public async Task<IActionResult> Vender(int id)
        {
            var produto = await _produtoFacade.ProdutoById(id);
             
            _produtoFacade.ConfirmarVendaProduto(id);            
                       
            return View(produto);
        }

        public async Task<IActionResult> CancelarVenda(int id)
        {
            var produto = await _produtoFacade.ProdutoById(id);

            _produtoFacade.CancelarVendaProduto(id);

            return View(produto);
        }

        public async Task<IActionResult> ProdutosNegociacao(ApplicationUser usuario)

        {
            usuario = await _userManager.GetUserAsync(HttpContext.User);
            return View(await _produtoFacade.ProdutosEmNegociacao(usuario));
        }

        public async Task<IActionResult> GetHistoricoDeProdutos(ApplicationUser usuario)
        {
            usuario = await _userManager.GetUserAsync(HttpContext.User);
            var produtos = await _produtoFacade.BuscarHistoricoProdutos(usuario.Id);
            return View(produtos);
        }

           }
    }





