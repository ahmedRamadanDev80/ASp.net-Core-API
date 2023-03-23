using learnApi.Models;
using Microsoft.EntityFrameworkCore;

namespace learnApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Villa> Villas { get; set; }
    }
}
