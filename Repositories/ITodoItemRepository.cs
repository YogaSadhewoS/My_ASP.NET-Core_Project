using System;
using System.Threading.Tasks;
using AspNetCoreTodo.Models;

namespace AspNetCoreTodo.Repositories
{
    public interface ITodoItemRepository
    {
        Task<TodoItem[]> GetIncompleteItemsAsync(string userId);
        Task AddAsync(TodoItem item);
        Task<TodoItem?> GetByIdAsync(Guid id, string userId);
        Task<bool> SaveChangesAsync();
        Task DeleteAsync(TodoItem item);
    }
}
