using System;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        public TodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync(string userId)
        {
            return await _context.TodoItems
                .Where(x => !x.IsDone && x.UserId == userId)
                .ToArrayAsync();
        }

        public async Task AddAsync(TodoItem item)
        {
            _context.TodoItems.Add(item);
            await Task.CompletedTask;
        }

        public async Task<TodoItem?> GetByIdAsync(Guid id, string userId)
        {
            return await _context.TodoItems
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task DeleteAsync(TodoItem item)
        {
            _context.TodoItems.Remove(item);
            await Task.CompletedTask;
        }
    }
}
