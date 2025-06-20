using MediatR;

namespace TransactionService.Application.Commands
{
    public class UpdateTransactionCommand : IRequest
    {
        public int Id { get; set; }
        public string TransactionType { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Detail { get; set; }
    }
}
