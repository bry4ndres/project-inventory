using MediatR;
using TransactionService.Application.DTOs;
using TransactionService.Application.Interfaces;
using TransactionService.Persistence;

namespace TransactionService.Application.Queries
{
    public class GetTransactionByIdQueryHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDto>
    {
        private readonly ITransactionRepository _repository;

        public GetTransactionByIdQueryHandler(ITransactionRepository repository)
        {
            _repository = repository;
        }

        public async Task<TransactionDto?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _repository.GetByIdAsync(request.Id);
            if (transaction == null || transaction.IsDeleted)
                return null;

            return new TransactionDto
            {
                Id = transaction.Id,
                Date = transaction.Date,
                TransactionType = transaction.TransactionType,
                ProductId = transaction.ProductId,
                Quantity = transaction.Quantity,
                UnitPrice = transaction.UnitPrice,
                Detail = transaction.Detail
            };
        }
    }
}
