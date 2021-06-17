using AspProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Searches
{
    public class PostSearch : PagedSearch
    {
        public string Name { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
    }
}
