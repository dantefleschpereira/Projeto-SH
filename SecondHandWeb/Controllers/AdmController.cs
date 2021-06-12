using BLL;
using Entities.Interfaces;
using Microsoft.AspNetCore.Mvc;
using PL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecondHandWeb.Controllers
{
    public class AdmController : Controller
    
    {
        private readonly AdmFacade _adm;
        private readonly IProdutoDao _dao;


        public AdmController()
        {
            _adm = new AdmFacade(_dao);
        }

        public IActionResult Index()
        {
            return View();
        }

       
    }
}
