using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Business.Entidades;
using Repository.Data;
using Repository.Interfaces;

namespace Repository.Repositorios
{
    public class CategoriaRepositorio : ICategoriaRepositorio
    {
        private readonly Context _context;

        public CategoriaRepositorio(Context context)
        {
            _context = context;
        }
        public async Task<List<CategoriaModel>> GetAll()
        {
            var categorias = await _context.Categorias.ToListAsync();
            return categorias;
        }
        public async Task<CategoriaModel> GetById(Guid id)
        {
            var categoria = await _context.Categorias
              .SingleOrDefaultAsync(c => c.Id == id);
            return categoria;
        }
        public async Task<List<CategoriaModel>> GetByDescription(string descricao)
        {
            var categoria = await _context.Categorias
              .Where(c => c.Descricao.Contains(descricao.ToLower()))
              .ToListAsync();
            return categoria;
        }
        public void Post(CategoriaModel model)
        {
            _context.Categorias.Add(model);
            _context.SaveChangesAsync();
        }
        public void Put(Guid id, CategoriaInputModel inputModel)
        {
            var categoria = _context.Categorias
                .SingleOrDefault(c => c.Id == id);

            categoria.UpdateCategoria(inputModel.Codigo, inputModel.Descricao);

            _context.SaveChangesAsync();
        }
        public async Task<bool> Remove(Guid id)
        {
            var produto = _context.Produtos.
                SingleOrDefault(p => p.CategoriaId == p.Categoria.Id);

            if (produto == null)
            {
                var categoria = _context.Categorias                
                    .SingleOrDefault(c => c.Id == id);

                _context.Categorias.Remove(categoria);
                await _context.SaveChangesAsync();
                return false;
            }

            return true;
        }
    }
}