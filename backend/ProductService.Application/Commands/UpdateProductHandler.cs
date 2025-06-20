using MediatR;
using ProductService.Application.Interfaces;
using ProductService.Domain.Entities;

namespace ProductService.Application.Commands
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {

            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
                throw new KeyNotFoundException($"Producto con el ID {request.Id} no fue encontrado.");


            product.Name = request.Name;
            product.Description = request.Description;
            product.Category = request.Category;
            product.Image = request.Image;
            product.Price = request.Price;
            product.Stock = request.Stock;


            await _productRepository.UpdateAsync(product);
            return Unit.Value;
        }
    }
}
