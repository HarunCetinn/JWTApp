using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoriesQueryRequest :IRequest<List<CategoryListDto>>
    {
    }
}
