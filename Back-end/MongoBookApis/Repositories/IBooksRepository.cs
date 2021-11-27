using System;
using MongoBookApis.Models;
using System.Collections.Generic;
using MongoBookApis.Dtos;
using System.Threading.Tasks;

namespace MongoBookApis.Repositories
{
    public interface IBooksRepository
    {
        Task<Book> GetBookAsync(Guid id);

        Task<IEnumerable<Book>> GetBooksAsync();

        Task CreateBookAsync(Book book);

        Task<IEnumerable<Book>> SearchAsync(string title = "", string authors = "", string minNumPage = "", string maxNumPage= "");
    }
}
