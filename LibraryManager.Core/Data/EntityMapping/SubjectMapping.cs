using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class SubjectMapping : IEntityTypeConfiguration<Subject>
{
	public void Configure(EntityTypeBuilder<Subject> builder)
	{
		builder
			.Property(s => s.Name)
			.IsRequired()
			.HasColumnType("varchar")
			.HasMaxLength(450);

		builder
			.HasIndex(s => s.Name)
			.IsUnique();
	}
}