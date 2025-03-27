using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ITodoItemRepository _repository;

        public TodoItemService(ITodoItemRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoItem[]> GetIncompleteItemAsync(IdentityUser user)
        {
            return await _repository.GetIncompleteItemsAsync(user.Id);
        }

        public async Task<bool> AddItemAsync(
            TodoItem newItem, IdentityUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            newItem.UserId = user.Id;

            await _repository.AddAsync(newItem);
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> MarkDoneAsync(
            Guid id, IdentityUser user)
        {
            var item = await _repository.GetByIdAsync(id, user.Id);
            if (item == null) return false;

            item.IsDone = true;
            return await _repository.SaveChangesAsync();
        }

        public async Task<bool> DeleteItemAsync(Guid id, IdentityUser user)
        {
            var item = await _repository.GetByIdAsync(id, user.Id);
            if (item == null) return false;

            await _repository.DeleteAsync(item);
            return await _repository.SaveChangesAsync();
        }
    }
}