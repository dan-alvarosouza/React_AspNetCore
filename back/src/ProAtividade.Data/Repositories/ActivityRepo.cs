using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Entities;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Data.Repositories
{
    public class ActivityRepo : GeneralRepo, IActivityRepo
    {
        private readonly DataContext _context;

        public ActivityRepo(DataContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Activity[]> GetAllAsync()
        {
            IQueryable<Activity> query = _context.Activities;

            query = query.AsNoTracking().OrderBy(activ => activ.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Activity> GetByIdAsync(int id)
        {
            IQueryable<Activity> query = _context.Activities;

            query = query.AsNoTracking().OrderBy(activ => activ.Id).Where(a => a.Id == id);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Activity> GetByTitleAsync(string title)
        {
            IQueryable<Activity> query = _context.Activities;

            query = query.AsNoTracking().OrderBy(activ => activ.Id);

            return await query.FirstOrDefaultAsync(a => a.Title == title);
        }

    }
}