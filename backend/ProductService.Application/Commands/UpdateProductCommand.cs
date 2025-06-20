using MediatR;

namespace ProductService.Application.Commands
{
    public class UpdateProductCommand : IRequest
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Description { get; set; } 
        public string Category { get; set; } 
        public string Image { get; set; } 
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
