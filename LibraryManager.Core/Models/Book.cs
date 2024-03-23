using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManager.Core.Models
{
	public class Book
	{
		[JsonIgnore]
		public int Id { get; set; }
		public string? ISBN { get; set; }
		public string? Title { get; set; }
		public string? Author { get; set; }
		public int PageCount { get; set; }
		public int PagesRead { get; set; }
		public bool Owned { get; set; }
		public bool Loaned { get; set; }
		public Publisher? Publisher { get; set; }
		[JsonIgnore]
		public int CoverId { get; set; }
		public bool CoversDownloaded { get; set; }
		public Cover? Cover { get; set; }
		public List<Subject>? Subjects { get; set; }
		[JsonIgnore]
		public ICollection<BookSubject>? BookSubjects { get; set; }

		public Book()
		{
			
		}

		public Book(OpenLibraryResponse openLibraryResponse)
		{
			if (openLibraryResponse != null)
			{
				ISBN = openLibraryResponse.Identifiers?.Isbn_13?[0] ?? openLibraryResponse.Identifiers?.Isbn_10?[0];
				Title = openLibraryResponse.Title;
				Author = openLibraryResponse.Authors?[0].Name;
				PageCount = openLibraryResponse.Number_of_pages;
				Publisher = openLibraryResponse.Publishers?[0];
				Subjects = openLibraryResponse.Subjects;
				Cover = openLibraryResponse.Cover;
			}
			else
			{
				ISBN = "";
				Title = "BROKEN SHIT.";
				Author = "";
				PageCount = 0;
				Publisher = new Publisher();
				Subjects = new List<Subject>();
				Cover = new Cover();
			}
			
			
		}
		
		private string GetCoverUrl(OpenLibraryResponse openLibraryResponse)
		{
			return $"http://covers.openlibrary.org/b/isbn/{openLibraryResponse.Identifiers.Isbn_13[0]}-L.jpg";
		}
	}
}