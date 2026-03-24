using FluentValidation;

namespace EnterpriseSystem.Module.Organization.Application.Users.Command.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.").EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.").MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
            RuleFor(x => x.Name).NotEmpty().WithMessage("First name is required.");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last name is required.");
            RuleFor(x => x.DocumentType).NotEmpty().WithMessage("Document type is required.");
            RuleFor(x => x.DocumentNumber).NotEmpty().WithMessage("Document number is required.");
        }
    }
}
