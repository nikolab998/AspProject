using System;
using System.Collections.Generic;
using System.Text;
using static AspProject.Domain.Like;

namespace AspProject.Application.DataTransfer
{
    public class LikeDto
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public Stat Status { get; set; }
    }
}
