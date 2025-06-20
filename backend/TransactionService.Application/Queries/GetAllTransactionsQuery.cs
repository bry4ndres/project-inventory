using MediatR;
using TransactionService.Application.DTOs;

namespace TransactionService.Application.Queries
{
    public class GetAllTransactionsQuery : IRequest<IEnumerable<TransactionDto>> { }
}
