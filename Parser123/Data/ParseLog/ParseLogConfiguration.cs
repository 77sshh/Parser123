using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Parser123.Data.ParseLog;

public class ParseLogConfiguration: IEntityTypeConfiguration<ParseLog>
{
	public void Configure(EntityTypeBuilder<ParseLog> builder)
	{
		builder.ToTable("parseLogs").HasKey(l => l.Id);
	}
}