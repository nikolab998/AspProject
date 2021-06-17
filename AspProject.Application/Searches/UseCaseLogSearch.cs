using AspProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public string UseCaseName { get; set; }
        public string Actor { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Data { get; set; }
    }
}
