using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Repositories
{
    public interface IProdutoRepositorio
    {
        Task<List<Produto>> Get();
        Task Create(Produto produto);
        Task<Produto> GetById(Guid id);
    }
}