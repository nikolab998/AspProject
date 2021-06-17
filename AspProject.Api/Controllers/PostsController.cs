using AspProject.Application;
using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.Application.Queries;
using AspProject.Application.Searches;
using Microsoft.AspNetCore.Http;
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
    public class PostsController : ControllerBase
    {
        private readonly UseCaseExecutor executor;
        private readonly IApplicationActor actor;

        public PostsController(UseCaseExecutor executor, IApplicationActor actor)
        {
            this.executor = executor;
            this.actor = actor;
        }

        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult Get([FromQuery] PostSearch search,[FromServices] IGetPostsQuery query)
        {
           return Ok(executor.ExecuteQuery(query, search));
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id,[FromServices] IGetPostsIdQuery query)
        {
            return Ok(executor.ExecuteQuery(query, id));
        }

        // POST api/<PostsController>
        [HttpPost]
        public IActionResult Post([FromBody] PostDto dto,[FromServices] ICreatePostCommand command)
        {
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] PostDto dto,[FromServices] IUpdatePostCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }
        [HttpPost]
        [Route("/api/like")]
        public IActionResult Like([FromBody] LikeDto dto,[FromServices] ICreateLikeCommand command)
        {
            //dto.UserId = actor.Id;
            dto.UserId = 2;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeletePostCommand command)
        {
            executor.ExecuteCommand(command,id);
            return NoContent();
        }
    }
}
