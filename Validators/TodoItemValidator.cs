using FluentValidation;
using AspNetCoreTodo.Models;

public class TodoItemValidator : AbstractValidator<TodoItem>
{
    public TodoItemValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Title harus diisi.")
            .MinimumLength(6).WithMessage("Title harus lebih dari 5 karakter.");
    }
}
