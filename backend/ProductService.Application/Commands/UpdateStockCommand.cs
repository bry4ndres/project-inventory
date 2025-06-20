using MediatR;

namespace ProductService.Application.Commands
{
    public class UpdateStockCommand : IRequest<bool>
    {
        public int ProductId { get; }
        public int Stock { get; }

        public UpdateStockCommand(int productId, int stock)
        {
            ProductId = productId;
            Stock = stock;
        }
    }
}
