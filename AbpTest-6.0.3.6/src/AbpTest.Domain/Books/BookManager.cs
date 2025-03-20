using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Uow;

namespace AbpTest.Books
{
    public class BookManager : DomainService
    {
        protected IUnitOfWorkManager UnitOfWorkManager => base.LazyServiceProvider.LazyGetRequiredService<IUnitOfWorkManager>();
        private readonly IRepository<Book, Guid> _repository;
        private readonly IBookRepository _bookRepository;

        public BookManager(IRepository<Book, Guid> repository, IBookRepository bookRepository)
        {
            _repository = repository;
            _bookRepository = bookRepository;
        }
    }
}
