namespace Backend.Repository
{
    using Contracts;
    using Domain;
    using Domain.POS;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Threading.Tasks;

    public class ProductRepository : IProduct
    {
        private readonly DataContext context;

        public ProductRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<Product> Add(Product entity)
        {
            context.Products.Add(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task<bool> Delete(Product entity)
        {
            context.Products.Remove(entity);
            int result = await context.SaveChangesAsync();

            return result > 0;
        }

        public Task<List<Product>> FindByClause(Func<Product, bool> Selector = null)
        {
            var models = context.Products
                .Where(Selector ?? (s => true));

            return Task.Run(() => models.ToList());
        }

        public async Task<Product> FindById(int key)
        {
            return await context.Products
                .FirstOrDefaultAsync(p => p.ProductId == key);
        }

        public async Task<bool> Update(Product entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            var result = await context.SaveChangesAsync();

            return result > 0;
        }
    }
}