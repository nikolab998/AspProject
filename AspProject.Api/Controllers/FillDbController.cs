using AspProject.DataAccess;
using AspProject.Domain;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FillDbController : ControllerBase
    {
        private readonly AspProjectContext _context;

        public FillDbController(AspProjectContext context)
        {
            _context = context;
        }

        // POST api/<FillDbController>
        [HttpPost]
        public void Post()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Cat 1"
                },
                new Category
                {
                    Name = "Cat 2"
                }
            };

            var users = new List<User>
            {
                new User
                {
                    FirstName = "Dragan",
                    LastName = "Dragic",
                    Email = "drago@gmail.com",
                    Username = "drago123",
                    Password = "drago123",
                    CreatedAt = DateTime.UtcNow,
                    ModifidedAt = null,
                    DeletedAt = null,
                    IsActive = true,
                    IsDeleted = false
                },
                new User
                {
                    FirstName = "Marko",
                    LastName = "Markovic",
                    Email = "marko@gmail.com",
                    Username = "marko123",
                    Password = "marko123",
                    CreatedAt = DateTime.UtcNow,
                    ModifidedAt = null,
                    DeletedAt = null,
                    IsActive = true,
                    IsDeleted = false,
                }
            };

            var images = new List<Image>
            {
                new Image
                {
                    ImagePath = "slika1.jpg",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                },
                 new Image
                {
                    ImagePath = "slika2.jpg",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false
                }
            };

            var posts = new List<Post>
            {
                new Post
                {
                    Title = "Post 1",
                    Description = "Desc 1",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                    User = users.First(),
                    Image = images.First()
                },
                 new Post
                {
                    Title = "Post 2",
                    Description = "Desc 2",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                    User = users.First(),
                    Image = images.Last()
                },
                  new Post
                {
                    Title = "Post 3",
                    Description = "Description 3",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                    User = users.First(),
                    Image = images.First()
                },
                   new Post
                {
                    Title = "Post 4",
                    Description = "Description 4",
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    IsDeleted = false,
                    User = users.Last(),
                    Image = images.Last()
                }
            };

            var comments = new List<Comment>
            {
                new Comment
                {
                    Name = "Kom 1",
                    User = users.First(),
                    Post = posts.First(),
                    CreatedAt = DateTime.UtcNow,
                    ModifidedAt = null,
                    DeletedAt = null,
                    IsDeleted = false,
                    IsActive = true
                },
                new Comment
                {
                    Name = "Kom 2",
                    User = users.Last(),
                    Post = posts.Last(),
                    CreatedAt = DateTime.UtcNow,
                    ModifidedAt = null,
                    DeletedAt = null,
                    IsDeleted = false,
                    IsActive = true
                }
            };

            var useCases = new List<UserUseCase>
            {
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 5
                },
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 6
                },
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 10
                },
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 11
                },
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 12
                },
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 15
                },
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 16
                },
                new UserUseCase
                {
                    User = users.First(),
                    UseCaseId = 19
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 2
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 3
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 4
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 5
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 6
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 7
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 8
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 9
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 10
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 11
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 12
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 13
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 14
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 15
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 16
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 17
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 18
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 19
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 20
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 21
                },
                new UserUseCase
                {
                    User = users.Last(),
                    UseCaseId = 22
                },
            };

            var productCategories = new List<PostCategory>
            {
                new PostCategory
                {
                    Post = posts.ElementAt(0),
                    Category = categories.First()
                },
                new PostCategory
                {
                    Post = posts.ElementAt(0),
                    Category = categories.Last()
                }
            };

            _context.Categories.AddRange(categories);
            _context.Users.AddRange(users);
            _context.Images.AddRange(images);
            _context.Posts.AddRange(posts);
            _context.Comments.AddRange(comments);
            _context.UserUseCases.AddRange(useCases);

            _context.SaveChanges();

        }

    }
}
