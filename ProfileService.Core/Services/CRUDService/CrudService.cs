using ProfileService.Data.Context;
using ProfileService.Data.Entities;
using System.Linq;

namespace ProfileService.Core.Services.CRUDService
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        protected readonly ProfileContext _context;

        public CrudService(ProfileContext context)
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
        
        public virtual T Update(T model)
        {
            var entity = _context.Update(model);
            _context.SaveChanges();
            return entity.Entity;
        }

        public IQueryable<T> All => _context.Set<T>().AsQueryable();
    }
}
