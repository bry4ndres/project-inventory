using MediatR;
using TransactionService.Application.DTOs;
using TransactionService.Application.Interfaces;

namespace TransactionService.Application.Queries
{
    public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, IEnumerable<TransactionDto>>
    {
        private readonly ITransactionRepository _repository;

        public GetAllTransactionsHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
        {
            var transactions = await _repository.GetAllAsync();

            return transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                Date = t.Date,
                TransactionType = t.TransactionType,
                ProductId = t.ProductId,
                Quantity = t.Quantity,
                UnitPrice = t.UnitPrice,
                Detail = t.Detail
            });
        }
    }
}
