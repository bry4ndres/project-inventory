using MediatR;
using ProductService.Application.Interfaces;

namespace ProductService.Application.Commands
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new KeyNotFoundException($"Producto con el ID {request.Id} no fue encontrado.");

            await _productRepository.DeleteAsync(product);
            return Unit.Value;
        }
    }
}
