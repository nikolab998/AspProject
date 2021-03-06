using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class PostCategory
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public virtual Post Post { get; set; }
        public virtual Category Category { get; set; }
    }
}
