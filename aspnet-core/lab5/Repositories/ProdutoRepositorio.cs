using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Repositories
{
  public class ProdutoRepositorio : IProdutoRepositorio
  {   
    private readonly Context _context;
    public ProdutoRepositorio(Context context)
    {
        _context = context;
    }
    public async Task<List<Produto>> Get()
    {
      await using (var db = _context)
      {
        return db.Produtos.ToList();
      }
    }

    public async Task Create(Produto produto)
    {
      await using (var db = _context)
      {
        await db.Produtos.AddAsync(produto);
        await db.SaveChangesAsync();
      }
    }

    public async Task<Produto> GetById(Guid id)
    { 
      Produto newProduto = new Produto();

      await using (var db = _context)
      {
        var produtos = db.Produtos.ToList();
        foreach (var produto in produtos)
        {
          if (produto.Id == id)
          {
              newProduto = produto;
          }
        }
        return newProduto;
      }
    }  
  }
}