using Microsoft.AspNetCore.Mvc;

namespace PL.Componentes
{
    public class CarrinhoCompraResumo : ViewComponent
    {
        private readonly CarrinhoCompraDao _carrinhoCompra;

        public CarrinhoCompraResumo(CarrinhoCompraDao carrinhoCompra)
        {
            _carrinhoCompra = carrinhoCompra;
        }

        public IViewComponentResult Invoke()
        {
            var items = _carrinhoCompra.GetCarrinhoCompraItens();
            
            _carrinhoCompra.CarrinhoCompraItens = items;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }
    }
}
