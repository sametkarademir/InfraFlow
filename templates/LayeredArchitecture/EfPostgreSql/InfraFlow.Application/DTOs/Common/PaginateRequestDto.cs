using FluentValidation;

namespace InfraFlow.Application.DTOs.Common;

public class PaginateRequestDto
{
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 25;

    public PaginateRequestDto()
    {
        
    }

    public PaginateRequestDto(int pageIndex, int pageSize)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}

public class PaginateRequestDtoValidator : AbstractValidator<PaginateRequestDto>
{
    public PaginateRequestDtoValidator()
    {
        RuleFor(x => x.PageIndex).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 100);
    }
}