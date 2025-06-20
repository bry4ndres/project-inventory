using MediatR;

namespace ProductService.Application.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public CreateProductCommand(string name, string description, string category, string image, decimal price, int stock)
        {
            Name = name;
            Description = description;
            Category = category;
            Image = image;
            Price = price;
            Stock = stock;
        }
    }
}
