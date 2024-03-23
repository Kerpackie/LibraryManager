using System.Text.Json.Serialization;

namespace LibraryManager.Core.Models;

public class Subject
{
	[JsonIgnore]
	public int Id { get; set; }
	public string? Name { get; set; }
	[JsonIgnore]
	public ICollection<BookSubject>? BookSubjects { get; set; }
}