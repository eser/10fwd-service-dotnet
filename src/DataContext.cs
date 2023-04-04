using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
  public DataContext(DbContextOptions options) : base(options)
  {
  }

  public DbSet<User> Users { get; set; } = null!;
  public DbSet<Organization> Organizations { get; set; } = null!;
  public DbSet<OrganizationMembership> OrganizationMemberships { get; set; } = null!;
  public DbSet<Profile> Profiles { get; set; } = null!;
}
