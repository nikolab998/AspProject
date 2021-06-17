using AspProject.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Queries
{
    public interface IGetPostsIdQuery : IQuery<int,PostDto>
    {
    }
}
