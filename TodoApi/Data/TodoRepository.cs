using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Exceptions;
using TodoApi.Models;

namespace TodoApi.Data
{
    public class TodoRepository : GenericRepository<Todo>
    {
        public  override void  Update(int Id, Todo entity)
        {
            var todo = FindById(Id);
            if (todo == null)
            {
                throw new ObjectNotExistsInRepoException<Todo>() { objectId=Id};
            }
            else
            {
                todo.Name = entity.Name;
                todo.DueDate = entity.DueDate;
                todo.isDone = entity.isDone;
            }
        }
    }
}
