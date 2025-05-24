using Microsoft.EntityFrameworkCore;

public class HouseDBContext : DbContext
{
    public HouseDBContext(DbContextOptions<HouseDBContext> options) : base(options)
    {
    }

    public DbSet<HouseEntity> Houses => Set<HouseEntity>();
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite($"Data Source={Path.Join(path, "HouseDB.db")}");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        SeedData.Seed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}