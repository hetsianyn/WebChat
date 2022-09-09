using BLL.DTOs;
using FluentValidation;

namespace BLL.Validations;

public class CreateMessageValidator : AbstractValidator<MessageDto>
{
    public CreateMessageValidator()
    {
        RuleFor(x => x.Content).NotEmpty().NotNull();
    }
}