using System;
using Entities.Models;
using System.Collections.Generic;
using System.Text;


namespace PL.Repositorio
{
    public interface IProdutoDao
    {
        void InserirProduto(Produto produto);
        List<Produto> FindProdutoByCategoriaId(int categoriaId);
        List<Produto> FindProductByKeywordAndCategoriaId(string palavra, int categoriaId);
        List<Produto> FindProdutoByFaixa(decimal valorInicial, decimal valorFinal);
        List<Produto> FindProdutoVendedorPorStatus(int usuarioId);
        List<RelProdutosVendidos> RelatorioVendasPeriodo(DateTime inicial, DateTime final);
    }
}