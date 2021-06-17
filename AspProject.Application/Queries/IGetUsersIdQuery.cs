using AspProject.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Queries
{
    public interface IGetUsersIdQuery : IQuery<int,UserDto>
    {
    }
}
