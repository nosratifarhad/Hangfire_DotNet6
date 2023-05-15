﻿using HangfireWebApplication.Domain;
using HangfireWebApplication.Domain.Entitys;

namespace HangfireWebApplication.Infra.Repositories.WriteRepositories.ProductWriteRepositories
{
    public class ProductWriteRepository : IProductWriteRepository
    {
        public async Task<int> CreateProductAsync(Product product)
        {
            await Task.Delay(1000);
            return Random.Shared.Next();
        }

        public async Task DeleteProductAsync(int productId)
        {
            await Task.Delay(1000);
        }

        public async Task UpdateProductAsync(Product product)
        {
            await Task.Delay(1000);
        }
    }
}
