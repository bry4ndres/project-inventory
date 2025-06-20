using MediatR;
using TransactionService.Application.Interfaces;
using TransactionService.Domain.Entities;

namespace TransactionService.Application.Commands
{
    public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, int>
    {
        private readonly ITransactionRepository _repository;
        private readonly IProductServiceClient _productClient;

        public CreateTransactionHandler(ITransactionRepository repository, IProductServiceClient productClient)
        {
            _repository = repository;
            _productClient = productClient;
        }

        public async Task<int> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transactionTypes = request.TransactionType;

            if (request.Quantity <= 0)
                throw new InvalidOperationException("La cantidad debe ser mayor a cero.");

            var stock = await _productClient.GetStockAsync(request.ProductId);
            if (stock == null)
                throw new InvalidOperationException("Producto no encontrado.");

            if (stock < request.Quantity && transactionTypes == "Venta")
                throw new InvalidOperationException("No hay stock del producto.");

            var transaction = new Transaction
            {
                TransactionType = request.TransactionType,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                Detail = request.Detail,
                Date = DateTime.Now
            };

            await _repository.AddAsync(transaction);

            int newStock;
            if (transactionTypes == "Venta")
            {
                newStock = -request.Quantity;
            }
            else
            {
                newStock = request.Quantity;
            }

            await _productClient.UpdateStockAsync(request.ProductId, newStock);

            return transaction.Id;
        }
    }
}
