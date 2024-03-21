using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Core.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int PublicationYear { get; set; }
		public string Publisher { get; set; }
		public int NumberOfPages { get; set; }
		
		public Genre Genre { get; set; }
		public int MainGenreId { get; set; }
	}
}