using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntitySeeds;

internal class CoverSeed : IEntityTypeConfiguration<Cover>
{
	public void Configure(EntityTypeBuilder<Cover> builder)
	{
		builder.HasData(
			new Cover { Id = 1, Small = "https://twinklelearning.in/uploads/noimage.jpg", Medium = "https://twinklelearning.in/uploads/noimage.jpg", Large = "https://twinklelearning.in/uploads/noimage.jpg"}
		);
	}
}