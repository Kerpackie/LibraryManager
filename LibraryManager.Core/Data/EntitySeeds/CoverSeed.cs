using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntitySeeds;

internal class CoverSeed : IEntityTypeConfiguration<Cover>
{
	public void Configure(EntityTypeBuilder<Cover> builder)
	{
		builder.HasData(
			new Cover { Id = 1, Small = "0", Medium = "0", Large = "0"}
		);
	}
}