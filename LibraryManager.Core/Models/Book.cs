using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Core.Models
{
	public class Book
	{
		public int Id { get; set; }
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int PageCount { get; set; }
		public int PagesRead { get; set; }
		public bool Owned { get; set; }
		public bool Loaned { get; set; }
		public Publisher Publisher { get; set; }
		public Cover Cover { get; set; }
		public List<Subject> Subjects { get; set; }
	}
}