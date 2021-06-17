using AspProject.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Queries
{
    public interface IGetCategoriesIdQuery : IQuery<int,CategoryDto>
    {
    }
}
