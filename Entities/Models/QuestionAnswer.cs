using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class QuestionAnswer
    {
        [Key]
        public int QAId { get; set; }
        public String User { get; set; }
        public String Text { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
