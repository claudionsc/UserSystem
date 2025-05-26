using Microsoft.EntityFrameworkCore;

namespace UsersSystem.Data
{
    public class AppDbContext : DbContext
    {
        AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
