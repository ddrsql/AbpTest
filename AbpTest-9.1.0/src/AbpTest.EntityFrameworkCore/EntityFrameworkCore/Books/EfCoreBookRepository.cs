using AbpTest.Books;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace AbpTest.EntityFrameworkCore.Books
{
    public class EfCoreBookRepository : EfCoreRepository<AbpTestDbContext, Book, Guid>, IBookRepository
    {
        public EfCoreBookRepository(IDbContextProvider<AbpTestDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<Book> GetBookByIdAsync(Guid id)
        {
            //var one = await (await GetDbSetAsync()).Where(l => l.Id == id).AsNoTrackingIf(false).FirstOrDefaultAsync();
            //one.Name = "Tracking";
            //one = await (await GetDbSetAsync()).Where(l => l.Id == id).AsNoTrackingIf(false).FirstOrDefaultAsync();

            //var two = await (await GetDbSetAsync()).Where(l => l.Id == id).AsNoTrackingIf(true).FirstOrDefaultAsync();
            //two.Name = "NoTracking";
            //two = await (await GetDbSetAsync()).Where(l => l.Id == id).AsNoTrackingIf(true).FirstOrDefaultAsync();

            //var c = await (await GetDbSetAsync()).Select(p => new {Id = p.Id,Name = p.Name })
            //    .Where(l => l.Id == id).AsNoTrackingIf(false).FirstOrDefaultAsync();
            //c.Name = "";

            return await (await GetDbSetAsync()).Where(l => l.Id == id).FirstOrDefaultAsync();
        }
    }




    /// <summary>
    ///查询Queryable扩展类
    /// </summary>
    public static class QueryableExtension
    {
        /// <summary>
        /// 是否追踪事务扩展
        /// </summary>
        public static IQueryable<TEntity> AsNoTrackingIf<TEntity>(this IQueryable<TEntity> query, bool enable = false)
            where TEntity : class
        {
            if (enable)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
    }
}
