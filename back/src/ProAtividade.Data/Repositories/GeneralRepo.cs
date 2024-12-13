using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProAtividade.Data.Context;
using ProAtividade.Domain.Interfaces.Repositories;

namespace ProAtividade.Data.Repositories
{
    public class GeneralRepo : IGeneralRepo
    {
        private readonly DataContext _context;
        public GeneralRepo(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteMany<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
    }
}