namespace LibraryManager.Core.Models
{
    public class Subject
    {
        public Subject()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
