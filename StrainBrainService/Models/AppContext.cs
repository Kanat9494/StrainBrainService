namespace StrainBrainService.Models;

public class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options) { }

    public DbSet<Question> Questions { get; set; }

    public DbSet<User> Users { get; set; }
}
