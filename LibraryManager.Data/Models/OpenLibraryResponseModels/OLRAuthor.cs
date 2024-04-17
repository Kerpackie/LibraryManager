using System.Text.Json.Serialization;

namespace LibraryManager.Data.Models.OpenLibraryResponseModels;

[Obsolete("Use Book instead.")]
public class OLRAuthor
{
	[JsonIgnore]
	public int Id { get; set; }
	public string? Name { get; set; }
	[JsonIgnore]
	public ICollection<OLRBook>? Books { get; set; }
}