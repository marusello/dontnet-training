using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using lab1.Models;

namespace lab1.Repositories
{
    public interface IProdutoRepositorio
    {
        Produto Get(Guid id);

        IList<Produto> GetAll();

        void Add(Produto produto);

        void Update(Produto produto);

        void Remove(Guid id);
    }
}
