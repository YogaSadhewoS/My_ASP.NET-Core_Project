using AutoMapper;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.DTOs;

namespace AspNetCoreTodo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Mapping from TodoItem to TodoItemDto
            CreateMap<TodoItem, TodoItemDto>();

            // Mapping from DTO to model
            CreateMap<TodoItemDto, TodoItem>();
        }
    }
}
