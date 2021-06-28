using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class QuestionAnswer
    {
        public int QAId { get; set; }
        public String User { get; set; }
        public String Text { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
    }
}
