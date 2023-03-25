using learnApi.Models;

namespace learnApi.Repostiory.IRepostiory
{
    public interface IVillaNumberRepository : IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
