using Microsoft.EntityFrameworkCore;
using UsersSystem.Models;

namespace UsersSystem.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> User { get; set; }
        //Obs: criar DbSet para funcionalidades do sistema;
    }
}
