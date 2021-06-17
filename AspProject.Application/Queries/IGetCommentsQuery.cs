using AspProject.Application.DataTransfer;
using AspProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Queries
{
    public interface IGetCommentsQuery : IQuery<CommentSearch, PagedResponse<CommentDto>>
    {
    }
}
