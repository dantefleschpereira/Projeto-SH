using BLL;
using Entities.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Componentes;

namespace SecondHandWeb.Controllers
{
    [Authorize(Roles = "Comprador")]
    public class CarrinhoCompraController : Controller
    {
        private readonly IProduto _produtoDao;
        private readonly ProdutoFacade _produtoFacade;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IProduto produtoDao,
                                        ProdutoFacade produtoFacade,CarrinhoCompra carrinhoCompra)
        {
            _produtoDao = produtoDao;
            _produtoFacade = produtoFacade;
            _carrinhoCompra = carrinhoCompra;
        }
        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };

            return View(carrinhoCompraVM);
        }

        [Authorize]
        public RedirectToActionResult AdicionarItemNoCarrinhoCompra(int produtoId)
        {
            var produtoSelecionado = _produtoDao.GetProdutoById(produtoId);
            //var produtoSelecionado = _produtoFacade.GetProdutoById(produtoId);
           // var produtoSelecionado = _produtoFacade.GetProdutoById(produtoId);
               

            if (produtoSelecionado != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(produtoSelecionado, 1);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int produtoId)
        {
            var produtoSelecionado = _produtoDao.GetProdutoById(produtoId);
           // var produtoSelecionado = _produtoFacade.GetProdutoById(produtoId);
            if (produtoSelecionado != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(produtoSelecionado);
            }
            return RedirectToAction("Index");
        }
    }
}
