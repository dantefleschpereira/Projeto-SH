using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class CategoriaDao
    {
        private readonly SecondHandContext _context;
        public CategoriaDao()
        {
            _context = new SecondHandContext();
        }

    }
}
