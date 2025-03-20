using AbpTest.Books.Dtos;
using AbpTest.Books;
using AutoMapper;

namespace AbpTest;

public class AbpTestApplicationAutoMapperProfile : Profile
{
    public AbpTestApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Book, BookOutput>();
    }
}
