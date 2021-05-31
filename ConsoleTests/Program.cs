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

            /*

            AdmFacade _adm = new AdmFacade(new ProdutoEF());
            NegocioFacade _user = new NegocioFacade();

            

            // 1)Usuários do sistema devem poder anunciar itens para venda.
            Console.WriteLine("---------------------------------------------------------------------------------------");
            _user.AnunciarProduto(new Produto()
            {
                Nome = "Celular Samsung",
                Descricao = "Celular Samsung S9+ na cor preta",
                Preco = 1500,
                StatusVenda = StatusVenda.DISPONIVEL,
                CategoriaId = 1,
                Cidade = "Gramado",
                UsuarioId = 3,
            });
            Console.WriteLine("---------------------------------------------------------------------------------------");



            // 2)Itens a venda de uma determinada categoria.
            List<Produto> lista = _user.EncontrarProdutoPorCategoriaId(1);
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Produtos a venda de uma determinada categoria.\n");

            foreach (var produto in lista)
            {
                Console.WriteLine
                    ("Categoria: {0} \nProduto: {1} \nDescrição: {2} \nPreço: R${3}\nVendedor: {4}\n"
                    , produto.Categoria.Nome, produto.Nome
                    , produto.Descricao, produto.Preco.ToString("N2"), produto.Usuario.Nome);
                Console.WriteLine("");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");



            // 2)Itens a venda dada uma palavra chave e uma categoria.
            var palavra = "Camisa";
            var categoriaId = 4;
            List<Produto> list = _user.EncontrarProdutoPorPalavraChavePorCategoriaId(palavra, categoriaId);
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Produtos a venda dada uma palavra chave e uma categoria.\n");

            foreach (var produto in list)
            {
                Console.WriteLine
                    ("Categoria: {0} \nPalavra Chave: {1} \nProduto: {2} \nDescrição: {3}\nPreço: R${4}\nVendedor: {5}\n"
                    , produto.Categoria.Nome, palavra, produto.Nome
                    , produto.Descricao, produto.Preco.ToString("N2"), produto.Usuario.Nome);
                Console.WriteLine("");
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");




            // 2)Itens a venda dentro de uma faixa de valores.
            decimal valorInicial = 100;
            decimal valorFinal = 1000;
            Console.WriteLine("---------------------------------------------------------------------------------------");

            Console.WriteLine("Produtos na faixa de valores de R${0} até RS{1}.\n", valorInicial, valorFinal);
            List<Produto> produtos = _user.EncontrarProdutoPorFaixaDeValores(valorInicial, valorFinal);
            foreach (Produto p in produtos)
            {
                Console.WriteLine("Produto: {0}\nPreço: R${1}\nVendedor: {2}\n"
                    , p.Nome, p.Preco.ToString("N2"), p.Usuario.Nome);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");




            // 3)Itens anunciados por um determinado vendedor, agrupados pelo status da venda.            
            List<Produto> lista1 = _adm.EncontrarProdutoPorVendedorPorStatusVenda(6);
            Console.WriteLine("---------------------------------------------------------------------------------------");
            Console.WriteLine("Produtos anunciados por um determinado vendedor, agrupados pelo status da venda.\n");

            foreach (Produto p in lista1)
            {
                Console.WriteLine
                    ("Produto: {0} \nStatus: {1}\nVendedor: {2}\n"
                    , p.Nome, p.StatusVenda, p.Usuario.Nome);
            }
            Console.WriteLine("---------------------------------------------------------------------------------------");

           

            // 3)Número total de itens vendidos num período e o valor total destas vendas.
            DateTime inicial = new DateTime(2021, 02, 01);
            DateTime final = new DateTime(2021, 02, 27);
            List<RelProdutosVendidos> relatorio = _adm.RelatorioVendasPeriodo(inicial, final);
            Console.WriteLine("Período do Relatório de Vendas: {0} até {1}", inicial, final);
            foreach (RelProdutosVendidos r in relatorio)
            {
                Console.WriteLine
                   ("\nQuantidade de Produtos Vendidos: {0} \nValor Total: R${1}\n"
                   , r.Quantidade, r.Valor);
            }
            */
        }
    }
}
