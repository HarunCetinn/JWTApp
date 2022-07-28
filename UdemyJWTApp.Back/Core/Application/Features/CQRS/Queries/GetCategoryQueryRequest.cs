using MediatR;
using UdemyJWTApp.Back.Core.Application.Dto;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto>
    {
        public int Id { get; set; }

        public GetCategoryQueryRequest(int ıd)
        {
            Id = ıd;
        }
    }
}
