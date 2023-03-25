using learnApi.Data;
using learnApi.Models;
using learnApi.Repostiory.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace learnApi.Repostiory
{
    public class VillaRepository : IVillaRepository
    {
        //injecting the db context in the ctor
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Villa entity)
        {
            await _db.Villas.AddAsync(entity);
            await SaveAsync();
        }

        public async Task<Villa> GetAsync(Expression<Func<Villa, bool>> filter = null, bool tracked = true)
        {
            // better than IEnumerable with larger amounts of data or when doing alot of filters
            IQueryable<Villa> query = _db.Villas;
            if(!tracked) query.AsNoTracking();
            if(filter != null) query = query.Where(filter);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<Villa>> GetAllAsync(Expression<Func<Villa, bool>> filter = null)
        {
            IQueryable<Villa> query = _db.Villas;
            if (filter != null) query = query.Where(filter);
            return await query.ToListAsync();
        }

        public async Task RemoveAsync(Villa entity)
        {
            _db.Villas.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(Villa entity)
        {
            _db.Villas.Update(entity);
            await SaveAsync();
        }
    }
}
