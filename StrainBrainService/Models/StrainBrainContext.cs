namespace StrainBrainService.Models;

public class StrainBrainContext : DbContext
{
    public StrainBrainContext(DbContextOptions<StrainBrainContext> options) : base(options) { }

    public DbSet<Question> Questions { get; set; }

    public DbSet<User> Users { get; set; }
}
