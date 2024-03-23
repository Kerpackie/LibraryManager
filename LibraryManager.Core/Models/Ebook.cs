namespace LibraryManager.Core.Models;

public class Ebook
{
	public string? Preview_url { get; set; }
	public string? Availability { get; set; }
	public Dictionary<string, EbookFormat>? Formats { get; set; }
	public string? Read_url { get; set; }
}