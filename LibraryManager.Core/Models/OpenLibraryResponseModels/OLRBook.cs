using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LibraryManager.Core.Models.OpenLibraryResponseModels
{
	[Obsolete("Use Book instead.")]
	public class OLRBook
	{
		[JsonIgnore]
		[Key] public int Id { get; set; }
		public string? ISBN { get; set; }
		public string? Title { get; set; }
		public OLRAuthor? Author { get; set; }
		public int PageCount { get; set; }
		public int PagesRead { get; set; }
		public bool Owned { get; set; }
		public bool Loaned { get; set; }
		public OLRPublisher? Publisher { get; set; }
		[JsonIgnore]
		public int CoverId { get; set; }
		public bool CoversDownloaded { get; set; }
		public OLRCover? Cover { get; set; }
		public List<OLRSubject>? Subjects { get; set; }
		[JsonIgnore]
		public ICollection<OLRBookSubject> BookSubjects { get; set; }

		public OLRBook()
		{
			
		}

		public OLRBook(OpenLibraryResponse openLibraryResponse)
		{
			if (openLibraryResponse != null)
			{
				ISBN = openLibraryResponse.Identifiers?.Isbn_13?[0] ?? openLibraryResponse.Identifiers?.Isbn_10?[0];
				Title = openLibraryResponse.Title;
				Author = openLibraryResponse.Authors?[0];
				PageCount = openLibraryResponse.Number_of_pages;
				Publisher = openLibraryResponse.Publishers?[0];
				Subjects = openLibraryResponse.Subjects;
				Cover = openLibraryResponse.Cover;
			}
			else
			{
				ISBN = "";
				Title = "BROKEN SHIT.";
				PageCount = 0;
				Publisher = new OLRPublisher();
				Subjects = new List<OLRSubject>();
				Cover = new OLRCover();
			}
			
			
		}
		
		private string GetCoverUrl(OpenLibraryResponse openLibraryResponse)
		{
			return $"http://covers.openlibrary.org/b/isbn/{openLibraryResponse.Identifiers.Isbn_13[0]}-L.jpg";
		}
	}
}