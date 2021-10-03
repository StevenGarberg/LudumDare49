using LudumDare49.API.Models;
using LudumDare49.API.Models.Requests;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace LudumDare49.API.Database
{
    public class LudumDare49Context : DbContext

    {
        public LudumDare49Context(DbContextOptions options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Player>()
                .Property(r => r.Data)
                .HasConversion(
                    v => JsonConvert.SerializeObject(v),
                    v => JsonConvert.DeserializeObject<PlayerData>(v));

            modelBuilder
                .Entity<MatchResults>();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<MatchResults> MatchResults { get; set; }
    }
}