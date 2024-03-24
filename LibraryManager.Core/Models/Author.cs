﻿namespace LibraryManager.Core.Models
{
    public class Author
    {
        public Author()
        {
            Books = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
        
        public void Trim()
        {
            Name = Name.Trim();
        }
    }
}
