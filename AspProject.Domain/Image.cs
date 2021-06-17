using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class Image : BaseEntity
    {
        public string ImagePath { get; set; }
        public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
    }
}
