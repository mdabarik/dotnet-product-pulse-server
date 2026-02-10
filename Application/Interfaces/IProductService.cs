using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductPulseServer.API.Controllers;
using ProductPulseServer.Application.DTOs;
using ProductPulseServer.Domain.Entities;

namespace ProductPulseServer.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> AddProductAsync(ProductDto productDto);
        Task<Product> UpdateProductAsync(int id, ProductDto productDto);
        Task<bool> DeleteProductAsync(int id);
    }
}