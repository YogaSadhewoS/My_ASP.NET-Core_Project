using FluentValidation;
using AspNetCoreTodo.DTOs;

public class TodoItemDtoValidator : AbstractValidator<TodoItemDto>
{
    public TodoItemDtoValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title harus diisi.")
            .MinimumLength(6).WithMessage("Title harus lebih dari 5 karakter.");
    }
}
