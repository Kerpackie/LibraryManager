using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Core.Models.OpenLibraryResponseModels
{
    public class OpenLibrarySearchResponse
    {
        public int NumFound { get; set; }
        public List<OpenLibraryDoc> Docs { get; set; }
    }
}
