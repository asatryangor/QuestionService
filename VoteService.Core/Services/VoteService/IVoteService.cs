using VoteService.Data.Entities;
using System.Linq;

namespace VoteService.Core.Services.VoteService
{
    public interface IVoteService
    {
        Vote Create(Vote model);
        Vote Update(Vote model);
        bool Delete(Vote model);
        IQueryable<Vote> All { get; }
    }
}
