using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Repository.Entidades;

namespace Repository.Interfaces
{
    public interface IProdutoRepositorio
    {
        Task<List<ProdutoModel>> Get();
        Task<ProdutoModel> GetById(Guid id);
        List<ProdutoModel> GetByDescription(string descricao);
        Task Post(ProdutoModel produtoModel);
        Task Put(Guid id, ProdutoInputModel produtoInputModel);
        Task Remove(Guid id);
    }
}
