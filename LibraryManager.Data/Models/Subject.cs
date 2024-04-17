﻿namespace LibraryManager.Data.Models
{
    public class Subject
    {
        public Subject()
        {
            Books = new HashSet<Book>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
        
        public void Trim()
        {
            Name = Name.Trim();
        }
    }
}