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
    public class TodoListItemController : ControllerBase
    {
        private TodoListItemRepository Repository;

        public TodoListItemController(GenericRepository<TodoListItem> repository)
        {
            Repository = (TodoListItemRepository)repository;
        }

        // GET: api/TodoListItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoListItem>>> GetItems()
        {
            return Repository.List();
        }

        [HttpGet("{due}")]
        public async Task<ActionResult<IEnumerable<TodoListItem>>> GetItemsByDate(DateTime due)
        {
            return Repository.FindByDueDate(due).ToList();
        }

        // GET: api/TodoListItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoListItem>> GetItem(int id)
        {
            var item = Repository.FindById(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/TodoListItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, TodoListItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            try
            {
                Repository.Update(id, item);
                return StatusCode(200);
            }
            catch (ObjectNotExistsInRepoException<TodoListItem> onex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        // POST: api/TodoListItem
        [HttpPost]
        public async Task<ActionResult<TodoListItem>> PostItem(TodoListItem item)
        {
            Repository.Add(item);
            return CreatedAtAction("GetTodoListItem", new { id = item.Id }, item);
        }

        // DELETE: api/TodoListItem/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoListItem>> DeleteItem(int id)
        {
            var item = Repository.FindById(id);
            if (item == null)
            {
                return NotFound();
            }
            Repository.Delete(id);
            //item check
            return item;
        }

    }
}
