using AbpTest.Books;
using AbpTest.Books.Dtos;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Timing;

namespace AbpTest.Controllers.Books
{
    //public class BookController : AbpTestController, IBookAppService
    //{
    //    private readonly IBookAppService _bookAppService;
    //    private readonly IClock _clock;

    //    public BookController(IBookAppService bookAppService, IClock clock)
    //    {
    //        _bookAppService = bookAppService;
    //        _clock = clock;
    //    }

    //    [HttpPost]
    //    [SwaggerOperation(Summary = "创建book", Tags = new[] { "Book" })]
    //    public async Task<BookOutput> CreateAsync()
    //    {
    //        return await _bookAppService.CreateAsync();
    //    }
    //}
}
