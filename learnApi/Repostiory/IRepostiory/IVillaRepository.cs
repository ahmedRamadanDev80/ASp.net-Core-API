using learnApi.Models;
using System.Linq.Expressions;

namespace learnApi.Repostiory.IRepostiory
{
    public interface IVillaRepository:IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
