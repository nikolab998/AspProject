using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();
    }
}
