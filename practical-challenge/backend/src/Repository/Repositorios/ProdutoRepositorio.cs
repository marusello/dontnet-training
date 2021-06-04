using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Business.Entidades;
using Repository.Data;
using Repository.Interfaces;
using Business.Excecoes;

namespace Repository.Repositorios
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        private readonly Context _context;

        public ProdutoRepositorio(Context context)
        {
            _context = context;
        }

        public async Task<List<ProdutoModel>> GetAll()
        {
            var produtos = await _context.Produtos.Include(x => x.Categoria).ToListAsync();
            return produtos;
        }
        public async Task<ProdutoModel> GetById(Guid id)
        {    
            var produto = await _context.Produtos
              .Include(x => x.Categoria)
              .AsNoTracking()
              .FirstOrDefaultAsync(x => x.Id == id);

            return produto;
        }
        public async Task<List<ProdutoModel>> GetByDescription(string descricao)
        {
            var produto = await _context.Produtos
              .Include(x => x.Categoria)
              .Where(c => c.Descricao
              .Contains(descricao.ToLower()))
              .ToListAsync();                 

            return produto;
        }
        public void Post(ProdutoModel model)
        {
            _context.Produtos.Add(model);
            _context.SaveChangesAsync();
        }
        public void Put(Guid id, ProdutoInputModel inputModel)
        {
            var produto = _context.Produtos
                .SingleOrDefault(c => c.Id == id);

            if (produto == null)
                throw new BusinessException("Produto não encontrado");

            produto.UpdateProduto(inputModel.Codigo, inputModel.Descricao,
                inputModel.Preco, inputModel.UnidadeMedida, inputModel.Categoria);

            _context.SaveChangesAsync();
        }
        public void Remove(Guid id)
        {
            var produto = _context.Produtos
                .SingleOrDefault(c => c.Id == id);

            if (produto == null)
                throw new BusinessException("Produto não encontrado");

            _context.Produtos.Remove(produto);
            _context.SaveChangesAsync();
        }
    }
}
