using BLL;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL;

namespace SecondHandWeb.Controllers
{
    public class PedidoController : Controller
    {
        private readonly PedidoFacade _pedidoFacade;
        private readonly CarrinhoCompraDao _carrinhoCompra;

        public PedidoController(PedidoFacade pedidoFacade, CarrinhoCompraDao carrinhoCompra)
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
            decimal precoTotalPedido = 0.0m;
            int totalItensPedido = 0;

            var items = _carrinhoCompra.GetCarrinhoCompraItens();

            _carrinhoCompra.CarrinhoCompraItens = items;

            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho esta vazio");
            }

            //Valor total do pedido
            foreach (var item in items)
            {
                totalItensPedido += item.Quantidade;
                precoTotalPedido += (item.Produto.Preco * item.Quantidade);
            }

            //Total de itens do pedido
            pedido.TotalItensPedido = totalItensPedido;

            //Total do pedido ao pedido
            pedido.PedidoTotal = precoTotalPedido;

            if (ModelState.IsValid)
            {
                _pedidoFacade.CriarPedido(pedido);

                ViewBag.CheckoutCompletoMensagem = "Acompanhe a situação do seu pedido no menu Histórico de Compras";
                ViewBag.TotalPedido = _carrinhoCompra.GetCarrinhoCompraTotal();

                _carrinhoCompra.LimparCarrinho();
                return View("~/Views/Pedido/CheckoutCompleto.cshtml", pedido);
            }
          
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
