using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Exceptions;
using TodoApi.Models;

namespace TodoApi.Data
{
    class TodoListItemRepository : GenericRepository<TodoListItem>
    {
        public override void Update(int id, TodoListItem entity)
        {
            var toUpdate = FindById(id);
            if (toUpdate == null) {
                throw new ObjectNotExistsInRepoException<TodoListItem>();
            }
        }
    }
}
