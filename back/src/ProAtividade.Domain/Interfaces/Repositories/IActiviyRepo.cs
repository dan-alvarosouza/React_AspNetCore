using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAtividade.Domain.Entities;

namespace ProAtividade.Domain.Interfaces.Repositories
{
    public interface IActiviyRepo
    {
        Task<Activity[]> GetAllAsync();
        Task<Activity[]> GetByIdAsync();

        Task<Activity[]> GetByTitleAsync();
    }
}