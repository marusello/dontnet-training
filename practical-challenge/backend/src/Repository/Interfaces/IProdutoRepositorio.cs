using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Entidades;

namespace Repository.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> GetAll();
        Task<ProdutoModel> GetById(Guid id);
        Task<List<ProdutoModel>> GetByDescription(string descricao);
        void Post(ProdutoModel model);
        void Put(Guid id, ProdutoInputModel inputModel);
        void Remove(Guid id);
    }
}
