using MediatR;
using TransactionService.Application.Interfaces;

namespace TransactionService.Application.Commands
{
    public class UpdateTransactionCommandHandler : IRequestHandler<UpdateTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public UpdateTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(UpdateTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);
            if (transaction == null)
                throw new KeyNotFoundException($"Transacción con el ID {request.Id} no fue encontrada.");

            transaction.TransactionType = request.TransactionType;
            transaction.ProductId = request.ProductId;
            transaction.Quantity = request.Quantity;
            transaction.UnitPrice = request.UnitPrice;
            transaction.Detail = request.Detail;

            await _transactionRepository.UpdateAsync(transaction);
            return Unit.Value;
        }
    }
}
