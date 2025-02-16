using Api_One_Trick_Pony_Br.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_One_Trick_Pony_Br.Data
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions opt) : base(opt) { }

        public DbSet<Platform> Platform { get; set; }
        public DbSet<Account> Account { get; set; } = default!;
        public DbSet<Pony> Pony { get; set; } = default!;
        public DbSet<Comment> Comment { get; set; } = default!;
        public DbSet<SocialMedia> SocialMedia { get; set; } = default!;
    }
}
