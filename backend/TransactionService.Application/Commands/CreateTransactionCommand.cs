using MediatR;

namespace TransactionService.Application.Commands
{
    public class CreateTransactionCommand : IRequest<int>
    {
        public string TransactionType { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Detail { get; set; }
    }
}
