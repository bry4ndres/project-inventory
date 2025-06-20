﻿using MediatR;
using ProductService.Application.Commands;
using ProductService.Application.DTOs;

namespace ProductService.Application.Queries
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>> { }
}
