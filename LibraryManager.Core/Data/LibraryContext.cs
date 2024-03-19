using LibraryManager.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Core.Data;

public class LibraryContext : DbContext
{
	public DbSet<Book> Books => Set<Book>();
}