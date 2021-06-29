using Entities.Models;
using Microsoft.EntityFrameworkCore;
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

        public CategoriaDao(SecondHandContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> ListAll()
        {
            return await _context.Categorias.ToListAsync();
        }

        public List<Categoria> TodasCategorias()
        {
            return  _context.Categorias.ToList();
        }

        public async Task<Categoria> DetailsById(int? id)
        {
            return await _context.Categorias.FirstOrDefaultAsync(m => m.CategoriaId == id);
        }

        public async Task Create(Categoria categoria)
        {
            _context.Add(categoria);
            await _context.SaveChangesAsync();
        }
        public async Task<Categoria> EditById(int? id)
        {
            return await _context.Categorias.FindAsync(id);
        }

        public async Task<Categoria> EditByIdAndObject(int id, Categoria categoria)
        {
            _context.Update(categoria);
            await _context.SaveChangesAsync();

            return categoria;
        }
       
        public async Task DeleteById(int? id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(m => m.CategoriaId == id);
            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();
        }

        public bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.CategoriaId == id);
        }

    }
}
