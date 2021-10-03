using System.Text.Json;
using LudumDare49.API.Models;
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
        }

        public DbSet<Player> Players { get; set; }
    }
}