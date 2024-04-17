namespace LibraryManager.Data.Models.OpenLibraryResponseModels;

public class OpenLibraryResponse
{
    public string? Url { get; set; }
    public string? Key { get; set; }
    public string? Title { get; set; }
    public string? Subtitle { get; set; }
    public List<OLRAuthor>? Authors { get; set; }
    public int Number_of_pages { get; set; }
    public string? Pagination { get; set; }
    public string? By_statement { get; set; }
    public OLRIdentifier? Identifiers { get; set; }
    public OLRClassification? Classifications { get; set; }
    public List<OLRPublisher>? Publishers { get; set; }
    public List<OLRPublishPlace>? Publish_places { get; set; }
    public string Publish_date { get; set; }
    public List<OLRSubject>? Subjects { get; set; }
    public string? Notes { get; set; }
    public List<OLREbook>? Ebooks { get; set; }
    public OLRCover? Cover { get; set; }
}
