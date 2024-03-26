using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntitySeeds;

public class CollectionSeed : IEntityTypeConfiguration<Collection>
{
	public void Configure(EntityTypeBuilder<Collection> builder)
	{
		builder.HasData(
			new Collection { Name = "Wishlist" },
			new Collection { Name = "Read" },
			new Collection { Name = "To Read" }
		);
	}
}