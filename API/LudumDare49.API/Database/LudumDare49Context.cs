using System.Text.Json;
using LudumDare49.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LudumDare49.API.Database
{
    public class LudumDare49Context : DbContext

    {
        public LudumDare49Context(DbContextOptions options) : base(options) { }

        public DbSet<Player> Players { get; set; }
    }
}