using System;

namespace AspNetCoreTodo.DTOs
{
    public class TodoItemDto
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTimeOffset? DueAt { get; set; }
    }
}
