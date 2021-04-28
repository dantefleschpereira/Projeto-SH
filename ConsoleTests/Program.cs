using BLL;
using Entities.Models;
using PL.Repositorio;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

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


            //1)Usuários do sistema devem poder anunciar itens para venda.
            UserFacade _user = new UserFacade();

            _user.AnunciarProduto(new Produto()
            {
                Nome = "Celular Samsung",
                Descricao = "Celular Samsung S9+ na cor preta",
                Preco = 1500,
                StatusVenda = StatusVenda.NEGOCIACAO,
                CategoriaId = 1,
                CidadeId = 1,
                VendedorId = 3,

            });

            //2) itens a venda de uma determinada categoria
            ICollection<Produto> lista;
            lista = _user.EncontrarProdutoPorCategoriaId(1);

            foreach (var produto in lista)
            {
                Console.WriteLine
                    ("Categoria: {0} \nProduto: {1} \nDescrição: {2} \nPreço: R${3}"
                    , produto.Categoria.Nome, produto.Nome
                    , produto.Descricao, produto.Preco.ToString("N2"));
                Console.WriteLine("");
            }
            Console.ReadLine();




            //2)itens a venda dada uma palavra chave e uma categoria
            //TODO

            //2)itens a venda dentro de uma faixa de valores
            //TODO


            //3)itens anunciados por um determinado vendedor, agrupados pelo status da venda
            //TODO

            //3)número total de itens vendidos num período e o valor total destas vendas
            //TODO
        }
    }
}
