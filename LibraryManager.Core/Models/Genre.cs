using System.Text.Json.Serialization;

namespace LibraryManager.Core.Models;

public class Genre
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	
	[JsonIgnore]
	public ICollection<Book> Books { get; set; } = new HashSet<Book>();
}