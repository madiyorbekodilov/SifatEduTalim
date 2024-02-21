using Microsoft.EntityFrameworkCore;

namespace SifatEdu.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

}