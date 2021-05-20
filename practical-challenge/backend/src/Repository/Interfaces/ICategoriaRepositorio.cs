using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Repository.Entidades;

namespace Repository.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModel>> Get();
        Task<CategoriaModel> GetById(Guid id);
        Task<List<CategoriaModel>> GetByDescription(string descricao);
        Task Post(CategoriaModel categoriaModel);
        Task Put(Guid id, CategoriaInputModel categoriaInputModel);
        Task Remove(Guid id);
    }
}