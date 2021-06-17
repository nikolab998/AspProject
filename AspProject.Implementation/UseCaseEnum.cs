using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Implementation
{
    public enum UseCaseEnum
    {
        EfRegisterUserCommand = 1,

        EfCreateCategoryCommand = 2, //Admin
        EfUpdateCategoryCommand = 3, //Admin
        EfDeleteCategoryCommand = 4, //Admin
        EfGetCategoryIdQuery = 5, // User
        EfGetCategoryQuery = 6, // User

        EfCreatePostCommand = 7, //Admin
        EfUpdatePostCommand = 8, //Admin
        EfDeletePostCommand = 9, //Admin
        EfGetPostIdQuery = 10, //User
        EfGetPostQuery = 11, //User

        EfCreateCommentCommand = 12, // User and Admin
        EfUpdateCommentCommand = 13, //Admin
        EfDeleteCommentCommand = 14, //Admin
        EfGetCommentIdQuery = 15, // User
        EfGetCommentQuery = 16, // User

        EfUpdateUserCommand = 17, //Admin
        EfDeleteUserCommand = 18, //Admin
        EfGetUserIdQuery = 19, // User
        EfGetUserQuery = 20, // User
        EfCreateLikeCommand = 21, // User
        EfGetUseCaseLogsQuery = 22 //Admin

    }
}
