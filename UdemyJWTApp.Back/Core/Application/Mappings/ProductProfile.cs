using AutoMapper;
using UdemyJWTApp.Back.Core.Application.Dto;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Mappings
{
    public class ProductProfile :Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product,ProductListDto>().ReverseMap();
        }




    }
}
