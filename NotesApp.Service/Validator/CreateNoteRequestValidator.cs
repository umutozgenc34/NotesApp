using FluentValidation;
using NotesApp.Model.Dtos;

namespace NotesApp.Service.Validator;

public class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
{
    public CreateNoteRequestValidator()
    {
        RuleFor(x => x.Title)
       .NotEmpty().WithMessage("Title is required.")
       .MaximumLength(50).WithMessage("Max length 50");


        RuleFor(x => x.Content)
       .NotEmpty().WithMessage("Content is required.")
       .MaximumLength(2000).WithMessage("Max length 2000");

    }
}
