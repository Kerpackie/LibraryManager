﻿namespace LibraryManager.Data.Models;

public class Collection
{
	public Collection()
	{
		Books = new HashSet<Book>();
	}

	public int Id { get; set; }
	public string Name { get; set; } = null!;

	public virtual ICollection<Book> Books { get; set; }
}