using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class CollectionMapping : IEntityTypeConfiguration<Collection>
{
	public void Configure(EntityTypeBuilder<Collection> builder)
	{
		builder
			.HasIndex(e => e.Name, "IX_Collections_Name")
			.IsUnique();
	}
}