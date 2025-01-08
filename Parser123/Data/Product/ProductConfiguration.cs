using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Parser123.Data.Product;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
	public void Configure(EntityTypeBuilder<Product> builder)
	{
		builder.ToTable("products").HasKey(p => p.Id);

		builder.Property(p => p.Name)
			.HasMaxLength(50);
		builder.Property(p => p.VodoparadLink)
			.HasMaxLength(200);
		builder.Property(p => p.DomotexLink)
			.HasMaxLength(200);

		builder.HasMany(p => p.Logs)
			.WithOne(l => l.Product);
	}
}