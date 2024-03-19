﻿using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Core.Models
{
	public class Book
	{
		[Key]
		public string ISBN { get; set; }
		public string Title { get; set; }
		public string Author { get; set; }
		public int PublicationYear { get; set; }
		public string Publisher { get; set; }
		public string Genre { get; set; }
		public int NumberOfPages { get; set; }
	}
}