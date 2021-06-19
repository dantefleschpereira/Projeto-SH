using BLL;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.Componentes;

namespace SecondHandWeb.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoFacade _pedidoFacade;
        private readonly CarrinhoCompra _carrinhoCompra;

        public PedidoController(PedidoFacade pedidoFacade, CarrinhoCompra carrinhoCompra)
        {
            _pedidoFacade = pedidoFacade;
            _carrinhoCompra = carrinhoCompra;
        }
        [Authorize]
        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Checkout(Pedido pedido)
        {
            var items = _carrinhoCompra.GetCarrinhoCompraItens();

            _carrinhoCompra.CarrinhoCompraItens = items;

            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio");
            }

            if (ModelState.IsValid)
            {
                _pedidoFacade.CriarPedido(pedido);

                ViewBag.CheckoutCompletoMensagem = "Obrigado por sua compra :) ";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                _carrinhoCompra.LimparCarrinho();
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
            // _context.Produtos.Remove(produto); remover o produto vendido do banco de dados
            return View(pedido);
        }

        public IActionResult CheckoutCompleto()
        {
            ViewBag.Cliente = TempData["Cliente"];
            ViewBag.DataPedido = TempData["DataPedido"];
            ViewBag.NumeroPedido = TempData["NumeroPedido"];
            ViewBag.TotalPedido = TempData["TotalPedido"];
            ViewBag.CheckoutCompletoMensagem = "Obrigado por sua compra :) ";
            return View();
        }
    }
}
