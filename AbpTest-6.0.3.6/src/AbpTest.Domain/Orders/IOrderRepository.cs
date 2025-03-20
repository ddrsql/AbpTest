using AbpTest.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace AbpTest.Orders
{
    public interface IOrderRepository : IBasicRepository<Order, Guid>
    {
        Task<Order> GetBookByIdAsync(Guid id);
    }
}
