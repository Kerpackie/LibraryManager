using System.Text.Json.Serialization;

namespace LibraryManager.Core.Models.OpenLibraryResponseModels;

[Obsolete("Response from OpenLibrary API.")]
public class OLRSubject
{
	[JsonIgnore]
	public int Id { get; set; }
	public string? Name { get; set; }
	[JsonIgnore]
	public ICollection<OLRBookSubject> BookSubjects { get; set; }
}