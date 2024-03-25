namespace LibraryManager.Core.Models;

public class Note
{
	public int Id { get; set; }
	public string Content { get; set; } = null!;
	public int BookId { get; set; }
	public virtual Book Book { get; set; } = null!;
}