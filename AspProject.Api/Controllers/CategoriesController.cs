using AspProject.Application;
using AspProject.Application.Commands;
using AspProject.Application.DataTransfer;
using AspProject.Application.Exceptions;
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
    public class CategoriesController : ControllerBase
    {
        private readonly IApplicationActor actor;
        private readonly UseCaseExecutor executor;

        public CategoriesController(IApplicationActor actor, UseCaseExecutor executor)
        {
            this.actor = actor;
            this.executor = executor;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search,[FromServices] IGetCategoriesQuery query)
        {
            return Ok(executor.ExecuteQuery(query,search));
        }
    
        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetCategoriesIdQuery query)
        {
            return Ok(executor.ExecuteQuery(query,id));
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public IActionResult Post([FromBody] CategoryDto dto,[FromServices] ICreateCategoryCommand command)
        {
            executor.ExecuteCommand(command,dto);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategoryDto dto,[FromServices] IUpdateCategoryCommand command)
        {
            dto.Id = id;
            executor.ExecuteCommand(command, dto);
            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id,[FromServices] IDeleteCategoryCommand command)
        {
                executor.ExecuteCommand(command, id);
                return NoContent();   
        }
    }
}
