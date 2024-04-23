using Microsoft.EntityFrameworkCore;
using NZwalks.API.Models.Domain;

namespace NZwalks.API.Data
{
    public class NZWalksDbcontext: DbContext
    {
        public NZWalksDbcontext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
                
        }
        // swappy 
        // amantya technologies
        public DbSet<Difficulty> Difficulties { get; set; }

        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

    }
}
