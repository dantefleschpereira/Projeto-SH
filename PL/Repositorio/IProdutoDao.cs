﻿using System;
using Entities.Models;
using System.Collections.Generic;
using System.Text;


namespace PL.Repositorio
{
    public interface IProdutoDao
    {
        List<Produto> FindProdutoByCategoriaId(int CategoriaId);
        void InserirProduto(Produto produto);
    }
}