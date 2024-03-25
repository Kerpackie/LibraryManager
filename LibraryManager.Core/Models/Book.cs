﻿using LibraryManager.Core.Models.OpenLibraryResponseModels;

namespace LibraryManager.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Isbn { get; set; }
        public string Title { get; set; } = null!;
        public int? AuthorId { get; set; }
        public int PageCount { get; set; }
        public int PagesRead { get; set; }
        public int Owned { get; set; }
        public int Loaned { get; set; }
        public int? PublisherId { get; set; }
        public int CoverId { get; set; }
        public int CoversDownloaded { get; set; }

        public virtual Author? Author { get; set; }
        public virtual Cover Cover { get; set; } = null!;
        public virtual Publisher? Publisher { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Note> Notes { get; set; }
        public virtual ICollection<Collection> Collections { get; set; }

        public Book()
        {
            Subjects = new HashSet<Subject>();
            Notes = new HashSet<Note>();
            Collections = new HashSet<Collection>();
        }

        public Book(OpenLibraryResponse openLibraryResponse)
        {
            Isbn = openLibraryResponse.Identifiers?.Isbn_13?[0] ?? openLibraryResponse.Identifiers?.Isbn_10?[0];
            Title = openLibraryResponse.Title;
            PageCount = openLibraryResponse.Number_of_pages;
            PagesRead = 0;
            Owned = 0;
            Loaned = 0;
            CoversDownloaded = 0;

            Author = new Author{ Name = openLibraryResponse.Authors?[0].Name };
            Publisher = new Publisher{ Name = openLibraryResponse.Publishers?[0].Name };
            Cover = new Cover{
                Small = openLibraryResponse.Cover?.Small, 
                Medium = openLibraryResponse.Cover?.Medium, 
                Large = openLibraryResponse.Cover?.Large};

            Subjects = openLibraryResponse.Subjects?.Select(s => new Subject{ Name = s.Name }).ToList();

        }
       
        public void Trim()
        {
            Title = Title.Trim();
            Isbn = Isbn?.Trim();
        }
    }
}
