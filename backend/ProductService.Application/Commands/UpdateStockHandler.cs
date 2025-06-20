using MediatR;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Commands
{
    public class UpdateStockHandler : IRequestHandler<UpdateStockCommand, bool>
    {
        private readonly IProductRepository _repository;

        public UpdateStockHandler(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateStockCommand request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetByIdAsync(request.ProductId);
            if (product == null || product.IsDeleted) 
                return false;

            product.Stock += request.Stock;
            await _repository.UpdateAsync(product);
            return true;
        }
    }
}
