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
    [Authorize(Roles = "User")]
    public class MeusProdutosController : Controller
    {
        private readonly CategoriaFacade _categoriaFacade;
        private readonly ProdutoFacade _produtoFacade;
        public readonly UserManager<ApplicationUser> _userManager;
        private readonly SecondHandContext _context;


        public MeusProdutosController(UserManager<ApplicationUser> userManager,
                                        ProdutoFacade produtoFacade, CategoriaFacade categoriaFacade)
        {
            _produtoFacade = produtoFacade;
            _categoriaFacade = categoriaFacade;
            _userManager = userManager;
            _context = new SecondHandContext();
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
                return NotFound();
            }
            return View(produto);
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

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produto = await _produtoFacade.EditById(id);
            produto.Status = Status.DISPONIVEL;
            if (produto == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_categoriaFacade.Categorias(), "CategoriaId", "Nome", produto.CategoriaId);

            return View(produto);
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProdutoId,Nome,Descricao,Preco,Status,CategoriaId,Cidade,UsuarioId,DataVenda")] Produto produto)
        {
            if (id != produto.ProdutoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _produtoFacade.EditByIdAndObject(id, produto);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_produtoFacade.ProdutoExists(produto.ProdutoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction(nameof(MeusProdutos));
            }
            ViewData["CategoriaId"] = new SelectList(_categoriaFacade.Categorias(), "CategoriaId", "Nome", produto.CategoriaId);
            //ViewData["Status"] = new SelectList(_produtoFacade.ListaDeProduto(), "Status", "Status", produto.Status);

            
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

        
        }
    }





