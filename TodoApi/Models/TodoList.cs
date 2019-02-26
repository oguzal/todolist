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
        public string Name { get; set; }
    }

    public class TodoListItem : Entity
    {

        public bool IsDone { get; set; }
        public Todo Todo { get; set; }
        public int TodoId { get; set; }
    }
    public class Todo : Entity
    {
        public bool isDone { get; set; }
        public DateTime DueDate { get; set; }
        public IList<TodoListItem> Items { get; set; }
        public int UserID { get; set; }
    }


}
