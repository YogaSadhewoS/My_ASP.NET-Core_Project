using AspNetCoreTodo.DTOs;
using System.Collections.Generic;

namespace AspNetCoreTodo.Models
{
    public class TodoViewModel
    {
        public IEnumerable<TodoItemDto> Items { get; set; } = new List<TodoItemDto>();
    }
}