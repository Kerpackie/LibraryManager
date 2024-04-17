namespace LibraryManager.Data.Models.OpenLibraryResponseModels;

[Obsolete("Response from OpenLibrary API.")]
public class OLRIdentifier
{
	public List<string>? Librarything { get; set; }
	public List<string>? Wikidata { get; set; }
	public List<string>? Goodreads { get; set; }
	public List<string>? Isbn_10 { get; set; }
	public List<string>? Isbn_13 { get; set; }
	public List<string>? Lccn { get; set; }
	public List<string>? Openlibrary { get; set; }
}