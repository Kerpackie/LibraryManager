using System.Text.Json.Serialization;

namespace LibraryManager.Data.Models.OpenLibraryResponseModels;

[Obsolete]
public class Genre
{
	public int Id { get; set; }
	public string Name { get; set; } = string.Empty;
	
	[JsonIgnore]
	public ICollection<OLRBook> Books { get; set; } = new HashSet<OLRBook>();
}