using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Models.OpenLibraryResponseModels
{
    public class OpenLibraryDoc
    {
        public List<string> AuthorAlternativeName { get; set; }
        public List<string> AuthorKey { get; set; }
        public List<string> AuthorName { get; set; }
        public List<string> Contributor { get; set; }
        public string CoverEditionKey { get; set; }
        public int CoverI { get; set; }
        public List<string> Ddc { get; set; }
        public string EbookAccess { get; set; }
        public int EbookCountI { get; set; }
        public int EditionCount { get; set; }
        public List<string> EditionKey { get; set; }
        public int FirstPublishYear { get; set; }
        public List<string> FirstSentence { get; set; }
        public bool HasFulltext { get; set; }
        public List<string> Ia { get; set; }
        public List<string> IaCollection { get; set; }
        public string IaCollectionS { get; set; }
        public List<string> ISBN { get; set; }
        public string Key { get; set; }
        public List<string> Language { get; set; }
        public long LastModifiedI { get; set; }
        public List<string> Lcc { get; set; }
        public List<string> Lccn { get; set; }
        public string LendingEditionS { get; set; }
        public string LendingIdentifierS { get; set; }
        public int NumberOfPagesMedian { get; set; }
        public List<string> Oclc { get; set; }
        public string PrintDisabledS { get; set; }
        public bool PublicScanB { get; set; }
        public List<string> PublishDate { get; set; }
        public List<string> PublishPlace { get; set; }
        public List<int> PublishYear { get; set; }
        public List<string> Publisher { get; set; }
        public List<string> Seed { get; set; }
        public string Title { get; set; }
        public string TitleSort { get; set; }
        public string TitleSuggest { get; set; }
        public string Type { get; set; }
        public List<string> IdAmazon { get; set; }
        public List<string> IdLibraryThing { get; set; }
        public List<string> IdGoodreads { get; set; }
        public List<string> Subject { get; set; }
        public List<string> Place { get; set; }
        public List<string> IaLoadedId { get; set; }
        public List<string> IaBoxId { get; set; }
        public double RatingsAverage { get; set; }
        public double RatingsSortable { get; set; }
        public int RatingsCount { get; set; }
        public int RatingsCount1 { get; set; }
        public int RatingsCount2 { get; set; }
        public int RatingsCount3 { get; set; }
        public int RatingsCount4 { get; set; }
        public int RatingsCount5 { get; set; }
        public int ReadinglogCount { get; set; }
        public int WantToReadCount { get; set; }
        public int CurrentlyReadingCount { get; set; }
        public int AlreadyReadCount { get; set; }
        public List<string> PublisherFacet { get; set; }
        public List<string> PlaceKey { get; set; }
        public List<string> SubjectFacet { get; set; }
        public List<string> SubjectKey { get; set; }
        public string DdcSort { get; set; }
        public List<string> AuthorFacet { get; set; }
        public List<string> PlaceFacet { get; set; }
        public long Version { get; set; }
    }

}
