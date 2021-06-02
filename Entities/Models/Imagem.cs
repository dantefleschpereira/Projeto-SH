using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Imagem
    {
        public int ImagemId { get; set; }

        [Display(Name = "Upload image")]
        public byte[] ImageFile { get; set; }
        public string ImageMimeType { get; set; }

        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }

    }
}
