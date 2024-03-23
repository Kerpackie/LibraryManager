namespace LibraryManager.Core.Models;

public class OpenLibraryResponse
{
    public string Url { get; set; }
    public string Key { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public List<Author> Authors { get; set; }
    public int Number_of_pages { get; set; }
    public string Pagination { get; set; }
    public string By_statement { get; set; }
    public Identifier Identifiers { get; set; }
    public Classification Classifications { get; set; }
    public List<Publisher> Publishers { get; set; }
    public List<PublishPlace> Publish_places { get; set; }
    public string Publish_date { get; set; }
    public List<Subject> Subjects { get; set; }
    public string Notes { get; set; }
    public List<Ebook> Ebooks { get; set; }
    public Cover Cover { get; set; }
}
