using VoteService.Data.Context;
using VoteService.Data.Entities;
using System.Linq;

namespace VoteService.Core.Services.VoteService
{
    public class VoteService : IVoteService
    {
        protected readonly VoteContext _context;

        public VoteService(VoteContext context)
        {
            _context = context;
        }
        
        public Vote Create(Vote model)
        {
            var entity = _context.Add(model);
            _context.SaveChanges();
            return entity.Entity;
        }

        public bool Delete(Vote model)
        {
            if (model == null)
            {
                return false;
            }
            _context.Remove(model);
            _context.SaveChanges();
            return true;
        }
        
        public Vote Update(Vote model)
        {
            var entity = _context.Votes.Update(model);
            _context.SaveChanges();
            return entity.Entity;
        }

        public IQueryable<Vote> All => _context.Set<Vote>().AsQueryable();
    }
}
