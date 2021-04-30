using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using lab1.Models;
using lab1.Repositories;

public class ProdutoRepositorio: IProdutoRepositorio
{
    private static readonly List<Produto> produtos = new List<Produto>();

    public Produto Get(Guid id)
    {
        return produtos.SingleOrDefault(c => c.Id == id);
    }

    public IList<Produto> GetAll()
    {
        return produtos;
    }

    public void Add(Produto produto)
    {
        produtos.Add(produto);
    }

    public void Update(Produto produto)
    {
        var index = produtos.FindIndex(0, 1, c => c.Id == produto.Id);

        if(index < 0)
        {
            return;
        }

        produtos[index] = produto;
    }

    public void Remove(Guid id)
    {
        var oldProduto = produtos.SingleOrDefault(c => c.Id == id);

        if(oldProduto == null)
        {
            return;
        }

        produtos.Remove(oldProduto);
    }
}