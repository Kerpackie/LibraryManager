using System.Text.Json.Serialization;

namespace LibraryManager.Core.Models;

public class Cover
{
	[JsonIgnore]
	public int Id { get; set; }
	public string? Small { get; set; }
	public string? Medium { get; set; }
	public string? Large { get; set; }
}