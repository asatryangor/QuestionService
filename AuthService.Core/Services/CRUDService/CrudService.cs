using AuthService.Data.Context;
using AuthService.Data.Entities;
using System.Linq;

namespace AuthService.Core.Services.CRUDService
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        protected readonly AuthContext _context;

        public CrudService(AuthContext context)
        {
            _context = context;
        }

        public T Create(T model)
        {
            var entity = _context.Add(model);
            _context.SaveChanges();
            return entity.Entity;
        }

        public bool Delete(T model)
        {
            if (model == null)
            {
                return false;
            }
            _context.Remove(model);
            _context.SaveChanges();
            return true;
        }

        public T Get(int id)
        {
            return _context.Find<T>(id);
        }

        public virtual T Update(T model)
        {
            var entity = _context.Update(model);
            _context.SaveChanges();
            return entity.Entity;
        }

        public IQueryable<T> All => _context.Set<T>().AsQueryable();
    }
}
