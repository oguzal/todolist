using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
        public Entity(int id, string name)
        {
            Id = id; Name = name; IsDone = false;
        }
        public string Name { get; set; }
        public bool IsDone { get; set; }
    }


    public class TodoListItem : Entity
    {
        public TodoListItem(int id, int todoId, DateTime due, string name) : base(id, name)
        {
            TodoId = todoId;
            DueDate = due;
        }
        public DateTime DueDate { get; set; }
        public int TodoId { get; set; }
    }
    public class Todo : Entity
    {
        public Todo(int id, string name,  int userId) : base(id, name)
        {          
            UserID = userId;
        }

        public IList<TodoListItem> Items { get; set; }
        public int UserID { get; set; }
    }


}
