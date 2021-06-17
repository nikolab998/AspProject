using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
    }
}
