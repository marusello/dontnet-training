using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entidades;
using Repository.Interfaces;

namespace Repository.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly Context _context;

        public ProdutoRepositorio(Context context)
        {
            _context = context;
        }

        public async Task<List<ProdutoModel>> Get()
        {
            var produtos = await _context.Produtos.Include(x => x.Categoria).ToListAsync();
            return produtos;
               
        }
        public async Task<ProdutoModel> GetById(Guid id)
        {
            await using var db = _context;
            var produto = await db.Produtos
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);
            return produto;
        }
        public List<ProdutoModel> GetByDescription(string descricao)
        {            
            var produto = _context.Produtos
              .Where(c => c.Descricao.Contains(descricao.ToLower()))
              .ToList();
            return produto;
        }

        public async Task Post(ProdutoModel produtoModel)
        {       
            _context.Produtos.Add(produtoModel);
            await _context.SaveChangesAsync();            
        }

        public async Task Put(Guid id, ProdutoInputModel produtoInputModel)
        {
            await using var db = _context;
            var produto = db.Produtos
                .SingleOrDefault(c => c.Id == id);

            produto.Codigo = produtoInputModel.Codigo;
            produto.Descricao = produtoInputModel.Descricao;
            produto.Preco = produtoInputModel.Preco;
            produto.UnidadeMedida = produtoInputModel.UnidadeMedida;
            produto.CategoriaId = produtoInputModel.Categoria.Id;

            await db.SaveChangesAsync();
        }

        public async Task Remove(Guid id)
        {
            await using var db = _context;
            var produto = db.Produtos
                .SingleOrDefault(c => c.Id == id);

            db.Produtos.Remove(produto);
            await db.SaveChangesAsync();
        }
    }
}
