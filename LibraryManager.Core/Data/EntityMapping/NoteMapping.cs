using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class NoteMapping : IEntityTypeConfiguration<Note>
{
	public void Configure(EntityTypeBuilder<Note> builder)
	{
		builder
			.HasIndex(e => e.BookId, "IX_Notes_BookId");

		builder
			.HasOne(d => d.Book)
			.WithMany(p => p.Notes)
			.HasForeignKey(d => d.BookId);
	}
}