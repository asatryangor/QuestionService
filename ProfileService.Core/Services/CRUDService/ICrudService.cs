using ProfileService.Data.Entities;
using System.Linq;

namespace ProfileService.Core.Services.CRUDService
{
    public interface ICrudService<T> where T : BaseEntity
    {
        T Create(T model);
        T Update(T model);
        bool Delete(T model);
        IQueryable<T> All { get; }
    }
}
