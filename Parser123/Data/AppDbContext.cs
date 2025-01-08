using Microsoft.EntityFrameworkCore;

namespace Parser123.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options): DbContext(options)
{
	public DbSet<Product.Product> Products { get; set; } = null!;
	public DbSet<ParseLog.ParseLog> ParseLogs { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);
		
		optionsBuilder.UseSqlite("Data Source = data.db");
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);

		modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
	}
}