using AbpTest.Books.Dtos;
using AbpTest.Books.LocalEventHandlers;
using AbpTest.Orders;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Local;
using Volo.Abp.Identity;
using Volo.Abp.ObjectMapping;
using Volo.Abp.TenantManagement;
using Volo.Abp.Uow;
using Volo.Abp.Users;

namespace AbpTest.Books
{
    public class BookAppService: AbpTestAppService, IBookAppService
    {
        private readonly BookManager _bookManager;
        private readonly IBookRepository _bookRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IIdentityUserRepository _identityuserRepository;
        private readonly IIdentityRoleRepository _identityRoleRepository;
        private readonly IObjectMapper _objectMapper;
        private readonly ILocalEventBus _localEventBus;

        public BookAppService(BookManager bookManager, IBookRepository bookRepository,
            ITenantRepository tenantRepository,
            IOrderRepository orderRepository,
            IIdentityUserRepository identityuserRepository,
            IIdentityRoleRepository identityRoleRepository,
            IObjectMapper objectMapper,
            ILocalEventBus localEventBus)
        {
            _bookManager = bookManager;
            _bookRepository = bookRepository;
            _tenantRepository = tenantRepository;
            _orderRepository = orderRepository;
            _identityuserRepository = identityuserRepository;
            _identityRoleRepository = identityRoleRepository;
            _objectMapper = objectMapper;
            _localEventBus = localEventBus;
        }

        public async Task InitBookAsync()
        {
            for (var i = 0; i < 200; i++)
            {
                var book = new Book(Guid.NewGuid(), DateTime.Now.ToString("MMssffff"));
                await _bookRepository.InsertAsync(book);
            }
        }

        public async Task<BookOutput> UpdateDataAsync()
        {
            var books = await _bookRepository.GetListAsync();
            var taskList = books.Select(async book =>
            {
                var bookId = book.Id;
                using (var uow = UnitOfWorkManager.Begin(true, true))
                {
                    await Test(bookId);
                    await uow.CompleteAsync();
                }
            });
            await taskList.WhenAll();

            var result = _objectMapper.Map<Book, BookOutput>(books.FirstOrDefault());
            return result;
        }

        public async Task Test(Guid id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            book.UpdateName();   
        }
    }
}
