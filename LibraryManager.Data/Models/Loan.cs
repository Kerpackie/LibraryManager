namespace LibraryManager.Data.Models;

public class Loan
{
	public int Id { get; set; }
	public string Borrower { get; set; } = null!;
	public DateTime LoanDate { get; set; }
	public DateTime? ReturnDate { get; set; }
	public bool IsReturned { get; set; }
	public bool Deleted { get; set; }
	public virtual ICollection<Book> Books { get; set; }
	
	public Loan()
	{
		Books = new HashSet<Book>();
	}
}