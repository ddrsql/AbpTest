using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus;
using Volo.Abp.Identity;

namespace AbpTest.Books.LocalEventHandlers;

public class BookCreatedHandler : ILocalEventHandler<EntityCreatedEventData<Book>>, ITransientDependency
{
    private readonly IBookRepository _bookRepository;

    public BookCreatedHandler(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public async Task HandleEventAsync(EntityCreatedEventData<Book> eventData)
    {
        var db = await _bookRepository.GetDbContextAsync();
        var asdf = db.Entry(eventData.Entity);
    }
}
