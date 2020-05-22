using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models;
using WebApi.Services.Interfaces;
using WebApiLogger;

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TodoTasksController : ControllerBase
    {
        private ITodoTaskService _todoTaskService;
        private IMapper _mapper;
        private readonly ILoggerWebApi _logger;

        public TodoTasksController(ITodoTaskService todoTaskService,IMapper mapper, ILoggerWebApi logger)
        {
            _todoTaskService = todoTaskService;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public IActionResult Create([FromBody]TodoTaskModel model)
        {
            if (!CommonHelper.IsValidRequest(model))
                return BadRequest("Bad Request.");

            // map model to entity
            var entity = _mapper.Map<Entities.TodoTask>(model);

            try
            {
                // create todo task
                _todoTaskService.Add(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var todoTasks = _todoTaskService.GetAll();
            var model = _mapper.Map<IEnumerable<TodoTask>, IEnumerable<TodoTaskResourceModel>>(todoTasks);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("GetByFilters")]
        public IActionResult GetByFilters([FromBody]FilterModel[] model)
        {
            // map model to entity
            var entity = _mapper.Map<IEnumerable<Entities.Filter>>(model);
            
            var todoTasks = _todoTaskService.GetByFilters(entity);
            var modelResult = _mapper.Map<IEnumerable<TodoTask>, IEnumerable<TodoTaskResourceModel>>(todoTasks);

            return Ok(modelResult);
        }

        // DELETE: api/TodoTasks/3
        [AllowAnonymous]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var todoTasks = _todoTaskService.Get(id);
            if (todoTasks == null)
            {
                return NotFound("The TodoTasks record couldn't be found.");
            }

            _todoTaskService.Delete(todoTasks);
            return NoContent();
        }

        // Update: api/TodoTasks/4
        [AllowAnonymous]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] TodoTaskModel model)
        {
            if (!CommonHelper.IsValidRequest(model))
                return BadRequest("Bad Request.");

            var todoTaskToUpdate = _todoTaskService.Get(id);
            if (todoTaskToUpdate == null)
            {
                return NotFound("The TodoTasks record couldn't be found.");
            }

            var todoTask = _mapper.Map<Entities.TodoTask>(model);

            _todoTaskService.Update(todoTaskToUpdate, todoTask);
            return NoContent();
        }
    }
}