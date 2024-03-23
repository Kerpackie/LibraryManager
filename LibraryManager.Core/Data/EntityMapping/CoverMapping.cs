using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class CoverMapping : IEntityTypeConfiguration<Cover>
{
	public void Configure(EntityTypeBuilder<Cover> builder)
	{
		builder.Property(c => c.Large)
			.IsRequired()
            .HasColumnType("varchar")
			.HasMaxLength(256);
		
		builder.Property(c => c.Medium)
			.IsRequired()
			.HasColumnType("varchar")
			.HasMaxLength(256);
		
		builder.Property(c => c.Small)
			.IsRequired()
			.HasColumnType("varchar")
			.HasMaxLength(256);
	}
}