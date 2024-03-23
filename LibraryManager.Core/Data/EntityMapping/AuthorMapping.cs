using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class AuthorMapping : IEntityTypeConfiguration<Author>
{
	public void Configure(EntityTypeBuilder<Author> builder)
	{
		builder.Property(a => a.Name)
			.IsRequired()
			.HasMaxLength(128);
		
		builder.HasIndex(a => a.Name)
			.IsUnique();
	}
}