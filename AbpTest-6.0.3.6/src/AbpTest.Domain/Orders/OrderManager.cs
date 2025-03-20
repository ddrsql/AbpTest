using AbpTest.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace AbpTest.Orders
{
    public class OrderManager : DomainService
    {
        protected IUnitOfWorkManager UnitOfWorkManager => base.LazyServiceProvider.LazyGetRequiredService<IUnitOfWorkManager>();
        private readonly IRepository<Order, Guid> _repository;
        private readonly IBookRepository _bookRepository;

        public OrderManager(IRepository<Order, Guid> repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }

        public virtual async Task<Order> AddBookAsync()
        {
            var order = new Order(Guid.NewGuid(), "test");
            using (var uow = UnitOfWorkManager.Begin(true, true))
            {
                order = await _repository.InsertAsync(order);
                //await uow.SaveChangesAsync();
                var bb = await _bookRepository.GetBookByIdAsync(order.Id);
                await uow.CompleteAsync();
            }
            try
            {
                //var aa = await _repository.GetAsync(book.Id);
                var bb = await _bookRepository.GetBookByIdAsync(order.Id);
            }
            catch (Exception ex)
            {

            }
            return order;
        }
    }
}
