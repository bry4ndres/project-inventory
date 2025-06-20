using MediatR;
using TransactionService.Application.Interfaces;

namespace TransactionService.Application.Commands
{
    public class DeleteTransactionCommandHandler : IRequestHandler<DeleteTransactionCommand>
    {
        private readonly ITransactionRepository _transactionRepository;

        public DeleteTransactionCommandHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<Unit> Handle(DeleteTransactionCommand request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetByIdAsync(request.Id);
            if (transaction == null)
                throw new KeyNotFoundException($"Transacción con el ID {request.Id} no fue encontrada.");

            await _transactionRepository.DeleteAsync(transaction);
            return Unit.Value;
        }
    }
}
