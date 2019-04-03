using QuestionService.Data.Context;
using QuestionService.Data.Entities;
using System.Linq;

namespace QuestionService.Core.Services.CRUDService
{
    public class CrudService<T> : ICrudService<T> where T : BaseEntity
    {
        protected readonly QuestionContext _context;

        public CrudService(QuestionContext context)
        {
            _context = context;
        }
        
        public virtual T Create(T model)
        {
            var entity = _context.Add(model);
            _context.SaveChanges();
            return entity.Entity;
        }

        public virtual bool Delete(T model)
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
