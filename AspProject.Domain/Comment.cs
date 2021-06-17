using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class Comment : BaseEntity
    {
        public string Name { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
    }
}
