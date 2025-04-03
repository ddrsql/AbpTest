using AbpTest.Books.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace AbpTest.Books
{
    public interface IBookAppService : IApplicationService
    {
        Task InitBookAsync();
        Task<BookOutput> UpdateDataAsync();
    }
}
