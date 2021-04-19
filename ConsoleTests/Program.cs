﻿using BLL;
using Entities.Models;
using PL.Dao;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Entities.Models.Dao;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            // apenas para testes
            AdmFacade _adm = new AdmFacade();

            _adm.Add(new Grupo()
            {
                Nome = "Grupo campeao",
                Integrantes = "<matr1, nome1> , <matr2,nome2>,...",
                GitHub = "http://github.com/meuprojetoPrivado",
                Comentarios = "Teste de insercao"
            });

            _adm.Add(new Grupo()
            {
                Nome = "Grupo dois",
                Integrantes = "<matr2.1, nome2.1> , <matr2.2,nome2.2>",
                GitHub = "http://github.com/projeto2Privado",
                Comentarios = "So para teste nao faz sentido dois grupos"
            });

            foreach (Grupo g in _adm.GetGrupos())
            {
                Console.WriteLine("Nome: {0}\n\tid: {1}\n\tComponentes: {2}\n\tComentarios: {3}\n",
                    g.Nome, g.GrupoId, g.Integrantes, g.Comentarios);

            }

            */

            //2) itens a venda de uma determinada categoria
            IProdutoDao produtoDao = DaoFactory.CreateProdutoDao();
            ICollection<Produto> lista = new List<Produto>();
            lista = produtoDao.FindAll(1);
            foreach (var produto in lista)
            {
                Console.WriteLine
                    ("Produto: {0} \nDescrição: {1} \nPreço: {2}"
                    , produto.Nome, produto.Descricao, produto.Preco);
                Console.ReadLine();
            }



        }
    }
}
