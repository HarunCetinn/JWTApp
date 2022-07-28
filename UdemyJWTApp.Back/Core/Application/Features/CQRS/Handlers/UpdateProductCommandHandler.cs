using MediatR;
using UdemyJWTApp.Back.Core.Application.Features.CQRS.Commands;
using UdemyJWTApp.Back.Core.Application.Interfaces;
using UdemyJWTApp.Back.Core.Domain;

namespace UdemyJWTApp.Back.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> _repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var updatedProduct = await _repository.GetByIdAsync(request.Id);
            if(updatedProduct != null)
            {
                updatedProduct.CategoryId = request.CategoryId;
                updatedProduct.Stock = request.Stock;
                updatedProduct.Price= request.Price;
                updatedProduct.Name= request.Name;
                await _repository.UpdateAsync(updatedProduct);
            }

            return Unit.Value;

            
        }
    }
}
