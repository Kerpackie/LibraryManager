namespace LibraryManager.Core.Models
{
    public class Cover
    {
        public Cover()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string? Small { get; set; }
        public string? Medium { get; set; }
        public string? Large { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        
        public void Trim()
        {
            Small = Small?.Trim();
            Medium = Medium?.Trim();
            Large = Large?.Trim();
        }
    }
}
