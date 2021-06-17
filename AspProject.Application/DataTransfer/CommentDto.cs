using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.DataTransfer
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
