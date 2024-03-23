using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping
{
	public class BookSubjectMapping : IEntityTypeConfiguration<BookSubject>
	{
		public void Configure(EntityTypeBuilder<BookSubject> builder)
		{
			builder
				.HasKey(bs => new { bs.BookId, bs.SubjectId });

			builder
				.HasOne(bs => bs.Book)
				.WithMany(b => b.BookSubjects)
				.HasForeignKey(bs => bs.BookId);

			builder
				.HasOne(bs => bs.Subject)
				.WithMany(s => s.BookSubjects)
				.HasForeignKey(bs => bs.SubjectId);
		}
	}
}