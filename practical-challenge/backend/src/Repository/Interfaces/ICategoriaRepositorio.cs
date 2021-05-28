using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Business.Entidades;

namespace Repository.Interfaces
{
    public interface ICategoriaRepositorio
    {
        Task<List<CategoriaModel>> GetAll();
        Task<CategoriaModel> GetById(Guid id);
        Task<List<CategoriaModel>> GetByDescription(string descricao);
        void Post(CategoriaModel model);
        void Put(Guid id, CategoriaInputModel inputModel);
        Task<bool> Remove(Guid id);
    }
}