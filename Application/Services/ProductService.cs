using ProductPulseServer.Application.DTOs;
using ProductPulseServer.Application.Interfaces;
using ProductPulseServer.Domain.Entities;
using ProductPulseServer.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProductPulseServer.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Product> AddProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Title = productDto.Title
            };
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<Product> UpdateProductAsync(int id, ProductDto productDto)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return null;

            product.Name = productDto.Name;
            product.Title = productDto.Title;

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
    }
}