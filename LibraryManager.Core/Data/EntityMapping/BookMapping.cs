using LibraryManager.Core.Data.ValueConverters;
using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Core.Data.EntityMapping;

public class BookMapping : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.Property(book => book.Title)
            .HasColumnType("varchar")
            .HasMaxLength(128)
            .IsRequired();
        
        builder.Property(book => book.PublicationYear)
            .HasColumnType("char(4)")
            .HasConversion(new DateTimeToChar4Converter());
        
        builder
            .HasOne(book => book.Genre)
            .WithMany(genre => genre.Books)
            .HasPrincipalKey(genre => genre.Id)
            .HasForeignKey(book => book.MainGenreId);
    }
}