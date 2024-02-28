using Microsoft.EntityFrameworkCore;
using SifatEdu.Domain.Entities;

namespace SifatEdu.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Answer> Answers { get; set; }
    public DbSet<Test> Tests { get; set; }
    public DbSet<Participate> Participations { get; set; }
    public DbSet<CodeUchun> CodeUchuns { get; set; }
}