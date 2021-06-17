using AspProject.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Searches
{
    public class CommentSearch : PagedSearch
    {
        public string Name { get; set; }
    }
}
