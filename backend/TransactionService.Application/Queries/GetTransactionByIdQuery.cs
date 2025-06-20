using MediatR;
using System;
using TransactionService.Application.DTOs;

namespace TransactionService.Application.Queries
{
    public class GetTransactionByIdQuery : IRequest<TransactionDto?>
    {
        public int Id { get; }

        public GetTransactionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
