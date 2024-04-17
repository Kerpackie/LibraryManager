namespace LibraryManager.Data.Models.OpenLibraryResponseModels;

[Obsolete("Response from OpenLibrary API.")]
public class OLREbook
{
	public string? Preview_url { get; set; }
	public string? Availability { get; set; }
	public Dictionary<string, OLREbookFormat>? Formats { get; set; }
	public string? Read_url { get; set; }
}