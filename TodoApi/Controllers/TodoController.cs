using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Data;
using TodoApi.Exceptions;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private TodoRepository Repository;
        
        public TodoController()
        {
            Repository = new TodoRepository();
        }

        //public TodoController(TodoRepository repository)
        //{
        //    Repository =repository;
        //}

        // GET: api/Todoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Todo>>> GetTodo()
        {
            return  Repository.List();
        }

        // GET: api/Todoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodo(int id)
        {
            var todo =  Repository.FindById(id);

            if (todo == null)
            {
                return NotFound();
            }

            return todo;
        }

        // PUT: api/Todoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodo(int id, Todo todo)
        {
            if (id != todo.Id)
            {
                return BadRequest();
            }
            try
            {
                Repository.Update(id, todo);
                return StatusCode(200);
            }
            catch (ObjectNotExistsInRepoException<Todo> onex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST: api/Todoes
        [HttpPost]
        public async Task<ActionResult<Todo>> PostTodo(Todo todo)
        {
            Repository.Add(todo);
            return CreatedAtAction("GetTodo", new { id = todo.Id }, todo);
        }

        // DELETE: api/Todoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Todo>> DeleteTodo(int id)
        {
            var todo =  Repository.FindById(id);
            if (todo == null)
            {
                return NotFound();
            }
            Repository.Delete(id);
            //todo check
            return todo;
        }

    }
}
