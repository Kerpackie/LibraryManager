namespace LibraryManager.Core.Models;

public class Identifier
{
	public List<string> Librarything { get; set; }
	public List<string> Wikidata { get; set; }
	public List<string> Goodreads { get; set; }
	public List<string> Isbn_10 { get; set; }
	public List<string> Lccn { get; set; }
	public List<string> Openlibrary { get; set; }
}