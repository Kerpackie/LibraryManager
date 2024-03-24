namespace LibraryManager.Core.Models.OpenLibraryResponseModels;
[Obsolete("Response from OpenLibrary API.")]
public class OLRBookSubject
{
	public int BookId { get; set; }
	public OLRBook OlrBook { get; set; }

	public int SubjectId { get; set; }
	public OLRSubject OlrSubject { get; set; }
}