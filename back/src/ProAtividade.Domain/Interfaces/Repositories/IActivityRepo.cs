using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces;

namespace ProAtividade.Domain.Interfaces.Repositories
{
    public interface IActivityRepo : IGeneralRepo
    {
        Task<Activity[]> GetAllAsync();
        Task<Activity> GetByIdAsync(int id);

        Task<Activity> GetByTitleAsync(string title);
    }
}