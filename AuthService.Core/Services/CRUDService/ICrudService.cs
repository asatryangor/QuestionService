using AuthService.Data.Entities;
using System.Linq;

namespace AuthService.Core.Services.CRUDService
{
    public interface ICrudService<T> where T : BaseEntity
    {
        T Create(T model);
        T Update(T model);
        T Get(int id);
        bool Delete(T model);
        IQueryable<T> All { get; }
    }
}
