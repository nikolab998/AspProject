using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Domain
{
    public class Like : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public Stat Status { get; set; }
        public Post Post { get; set; }
        public User User { get; set; }
        public enum Stat
        {
            Null = 0,
            Liked = 1,
            Disliked =2
        }
    }
}
