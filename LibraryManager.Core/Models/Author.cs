using System.Text.Json.Serialization;

namespace LibraryManager.Core.Models;

public class Author
{
	[JsonIgnore]
	public int Id { get; set; }
	public string? Name { get; set; }
	[JsonIgnore]
	public ICollection<Book>? Books { get; set; }
}