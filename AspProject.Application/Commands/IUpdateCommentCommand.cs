using AspProject.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.Commands
{
    public interface IUpdateCommentCommand : ICommand<CommentDto>
    {
    }
}
