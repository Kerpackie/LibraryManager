using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class PublisherMapping : IEntityTypeConfiguration<Publisher>
{
	public void Configure(EntityTypeBuilder<Publisher> builder)
	{
		builder
			.Property(p => p.Name)
			.IsRequired()
			.HasColumnType("varchar")
			.HasMaxLength(450);

		builder
			.HasIndex(p => p.Name)
			.IsUnique();
	}
}