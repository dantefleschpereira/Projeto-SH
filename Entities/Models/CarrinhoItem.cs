using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    [Table("CarrinhoItens")]
    public class CarrinhoItem
    {
        public int CarrinhoItemId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public string CarrinhoCompraId { get; set; }
    }
}
