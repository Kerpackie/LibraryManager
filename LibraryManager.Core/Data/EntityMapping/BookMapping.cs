using LibraryManager.Core.Data.ValueConverters;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder
            .HasIndex(e => e.Isbn, "IX_Books_ISBN")
            .IsUnique();

        builder
            .Property(e => e.Isbn)
            .HasColumnName("ISBN");

        builder
            .HasOne(d => d.Author)
            .WithMany(p => p.Books)
            .HasForeignKey(d => d.AuthorId);

        builder
            .HasOne(d => d.Cover)
            .WithMany(p => p.Books)
            .HasForeignKey(d => d.CoverId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder
            .HasOne(d => d.Publisher)
            .WithMany(p => p.Books)
            .HasForeignKey(d => d.PublisherId);

        builder
            .HasMany(d => d.Subjects)
            .WithMany(p => p.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookSubject",
                l => l
                    .HasOne<Subject>()
                    .WithMany()
                    .HasForeignKey("SubjectId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                r => r
                    .HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
        j =>
                {
                    j.HasKey("BookId", "SubjectId");

                    j.ToTable("BookSubjects");
                });
        
        builder
            .HasMany(d => d.Collections)
            .WithMany(p => p.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookCollection",
                l => l
                    .HasOne<Collection>()
                    .WithMany()
                    .HasForeignKey("CollectionId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                r => r
                    .HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                j =>
                {
                    j.HasKey("BookId", "CollectionId");

                    j.ToTable("BookCollections");

                    j.HasIndex(new[] { "CollectionId" }, "IX_BookCollections_CollectionId");
                });
        
        builder
            .HasMany(d => d.Loans)
            .WithMany(p => p.Books)
            .UsingEntity<Dictionary<string, object>>(
                "BookLoan",
                l => l
                    .HasOne<Loan>()
                    .WithMany()
                    .HasForeignKey("LoanId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                r => r
                    .HasOne<Book>()
                    .WithMany()
                    .HasForeignKey("BookId")
                    .OnDelete(DeleteBehavior.ClientSetNull),
                j =>
                {
                    j.HasKey("BookId", "LoanId");

                    j.ToTable("BookLoans");

                    j.HasIndex(new[] { "LoanId" }, "IX_BookLoans_LoanId");
                });
    }
}