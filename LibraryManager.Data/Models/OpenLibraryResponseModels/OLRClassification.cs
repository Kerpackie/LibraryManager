namespace LibraryManager.Data.Models.OpenLibraryResponseModels;

[Obsolete("Response from OpenLibrary API.")]
public class OLRClassification
{
	public List<string>? Lc_classifications { get; set; }
	public List<string>? Dewey_decimal_class { get; set; }
}