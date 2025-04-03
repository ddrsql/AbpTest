using AbpTest.Books;
using AbpTest.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace AbpTest.EntityFrameworkCore.Orders
{
    public class EfCoreOrderRepository : EfCoreRepository<AbpTestDbContext, Order, Guid>, IOrderRepository
    {
        public EfCoreOrderRepository(IDbContextProvider<AbpTestDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Order> GetBookByIdAsync(Guid id)
        {
            return await (await GetDbSetAsync()).Where(l => l.Id == id).FirstOrDefaultAsync();
        }
    }
}
