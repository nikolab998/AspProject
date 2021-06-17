using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.DataTransfer
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
        public int ImageId { get; set; }
        public virtual IEnumerable<string> PostCategories { get; set; }
        public virtual IEnumerable<string> Comments { get; set; }
        public virtual IEnumerable<int> UserId_Likes { get; set; }
    }
}
