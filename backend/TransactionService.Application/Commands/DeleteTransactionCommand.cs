using MediatR;

namespace TransactionService.Application.Commands
{
    public class DeleteTransactionCommand : IRequest
    {
        public int Id { get; set; }

        public DeleteTransactionCommand(int id)
        {
            Id = id;
        }
    }
}
