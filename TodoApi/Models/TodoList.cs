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
        public TodoListItem(int id, int todoId, string name) : base(id, name)
        {
            TodoId = todoId;
        }
        public Todo Todo { get; set; }
        public int TodoId { get; set; }
    }
    public class Todo : Entity
    {
        public Todo(int id, string name, DateTime due, int userId) : base(id, name)
        {
            DueDate = due;
            UserID = userId;
        }
        public DateTime DueDate { get; set; }
        public IList<TodoListItem> Items { get; set; }
        public int UserID { get; set; }
    }


}
