using Path.Repositori.Dbcontext;
using Path.Repositori.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path.Repositori.Implementation
{
    public class GenericRepositorie<T> : IGenericRepositorie<T> where T : class
    {
        private readonly PathContext _context;

        public GenericRepositorie(PathContext context)
        {
            _context = context;
        }
        public async Task<T> Create(T model)
        {
            try
            {
                _context.Set<T>().Add(model);
                await _context.SaveChangesAsync();
                return model;
            }catch 
            {
                throw;
            }
        }

        public async Task<bool> Delete(T model)
        {
            try
            {
                _context.Set<T>().Remove(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async  Task<bool> Edit(T model)
        {
            try
            {
                _context.Set<T>().Update(model);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public IQueryable<T> Get(System.Linq.Expressions.Expression<Func<T, bool>>? filter = null)
        {
            IQueryable<T> get = (filter == null) ? _context.Set<T>() : _context.Set<T>().Where(filter);
            return get;
        }
    }
}
