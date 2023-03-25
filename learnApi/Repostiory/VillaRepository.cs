using learnApi.Data;
using learnApi.Models;
using learnApi.Repostiory.IRepostiory;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace learnApi.Repostiory
{
    public class VillaRepository : Repository<Villa>, IVillaRepository
    {
        //injecting the db context in the ctor
        private readonly ApplicationDbContext _db;
        public VillaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        
        public async Task<Villa> UpdateAsync(Villa entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _db.Villas.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
