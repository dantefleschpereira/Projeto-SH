﻿using Entities.Models;
using PL;
using PL.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class AdmFacade
    {

        private readonly IProdutoDao _dao;

        public AdmFacade(IProdutoDao dao)
        {
            _dao = dao;
        }

        public List<Produto> EncontrarProdutoPorVendedorPorStatusVenda(int usuarioId)
        {
            return _dao.FindProdutoVendedorPorStatus(usuarioId);
        }

        public List<RelProdutosVendidos> RelatorioVendasPeriodo(DateTime inicial, DateTime final)
        {
           return _dao.RelatorioVendasPeriodo(inicial, final);
        }




        /*
        // atencao...
        //      - apenas um exemplo
        //      - implementar DAO para acesso ao DB
        //      - "tentar" usar DI
        public void Add(Grupo g)
        {
            using (var _context = new SecondHandContext() )
           {
                _context.Add(g);
                _context.SaveChanges();
            }

        }

        public List<Grupo> GetGrupos()
        {
            SecondHandContext _context = new SecondHandContext();
            var grupos = _context.Grupo.ToList();
           
            return grupos;
        } */
    }
}
