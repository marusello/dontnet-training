using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Excecoes;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Entidades;
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
        public async Task<List<CategoriaModel>> Get()
        {
            await using var db = _context;
            var categorias = db.Categorias.ToList();
            return categorias;
        }
        public async Task<CategoriaModel> GetById(Guid id)
        {
            await using var db = _context;
            var categoria = db.Categorias
              .SingleOrDefault(c => c.Id == id);
            return categoria;
        }
        public async Task<List<CategoriaModel>> GetByDescription(string descricao)
        {
            await using var db = _context;
            var categoria = db.Categorias
              .Where(c => c.Descricao.Contains(descricao.ToLower()))
              .ToList();
            return categoria;
        }
        public async Task Post(CategoriaModel model)
        {
            await using var db = _context;
            db.Categorias.Add(model);
            await db.SaveChangesAsync();
        }
        public async Task Put(Guid id, CategoriaInputModel categoriaInputModel)
        {
            using var db = _context;
            var categoria = db.Categorias
                .SingleOrDefault(c => c.Id == id);

            categoria.Codigo = categoriaInputModel.Codigo;
            categoria.Descricao = categoriaInputModel.Descricao;

            await db.SaveChangesAsync();
        }
        public async Task Remove(Guid id)
        {
            await using var db = _context;
            var categoria = db.Categorias
                .SingleOrDefault(c => c.Id == id);

            db.Categorias.Remove(categoria);
            await db.SaveChangesAsync();

        }
    }
}