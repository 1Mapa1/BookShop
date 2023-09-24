using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.db;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OnlineShopWebApp
{
    public class ProductCashe : BackgroundService
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IMemoryCache memoryCache;

        public ProductCashe(IServiceProvider serviceProvider, IMemoryCache memoryCache)
        {
            this.serviceProvider = serviceProvider;
            this.memoryCache = memoryCache;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested) 
            {
                CachingAllProducts();

                await Task.Delay(TimeSpan.FromMilliseconds(60000), stoppingToken);
            }
        }

        private void CachingAllProducts()
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

                var products = databaseContext.Products.ToList();

                if (products != null) 
                { 
                    memoryCache.Set(Constans.KeyCacheAllProducts, products);
                }

                foreach (var product in products)
                {
                    if (product != null)
                    {
                        memoryCache.Set(product.Id, product);
                    }
                }
            }
        }
    }
}
