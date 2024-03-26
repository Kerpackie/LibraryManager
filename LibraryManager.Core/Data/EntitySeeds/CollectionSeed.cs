using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntitySeeds;

public class CollectionSeed : IEntityTypeConfiguration<Collection>
{
	public void Configure(EntityTypeBuilder<Collection> builder)
	{
		builder.HasData(
			new Collection { Id = 1, Name = "Wishlist" },
			new Collection { Id = 2, Name = "Read" },
			new Collection { Id = 3, Name = "To Read" }
		);
	}
}