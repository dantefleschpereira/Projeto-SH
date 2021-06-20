using Entities.Models;
using PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaFacade
    {
        private readonly CategoriaDao _categoriaDao;

        public CategoriaFacade(CategoriaDao categoriaDao)
        {
            _categoriaDao = categoriaDao;
        }

        public async Task<List<Categoria>> ListAll() => await _categoriaDao.ListAll();
        public async Task<Categoria> DetailsById(int? id) => await _categoriaDao.DetailsById(id);
        public async Task Create(Categoria categoria) => await _categoriaDao.Create(categoria);
        public async Task<Categoria> EditById(int? id) => await _categoriaDao.EditById(id);
        public async Task<Categoria> EditByIdAndObject(int id, Categoria categoria) => await _categoriaDao.EditByIdAndObject(id, categoria);
        public async Task<Categoria> GetToDeleteById(int? id) => await _categoriaDao.GetToDeleteById(id);
        public async Task DeleteById(int? id) => await _categoriaDao.DeleteById(id);
        public bool CategoriaExists(int id) => _categoriaDao.CategoriaExists(id);
    }
}
