using AspProject.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Queries
{
    public interface IGetCommentIdQuery : IQuery<int,CommentDto>
    {
    }
}
