using FluentValidation;

using ModernisationChallengeApi.Dtos.TaskDtos;

namespace ModernisationChallengeApi.DtoValidations.TaskValidations;

public class UpsertTaskRequestValidation : AbstractValidator<UpsertTaskRequest>
{
    public UpsertTaskRequestValidation()
    {
        RuleFor(t => t.Details).NotEmpty();
    }
}
