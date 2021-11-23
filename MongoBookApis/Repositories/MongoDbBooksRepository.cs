using System;
using MongoBookApis.Repositories;
using MongoDB.Driver;
using MongoBookApis.Models;
using MongoBookApis.Dtos;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace MongoBookApis.Repositories
{
    public class MongoDbBooksRepository: IBooksRepository
    {
        private const string databaseName = "BookstoreDb";

        private const string collectionName = "Books";

        private readonly IMongoCollection<Book> booksCollection;

        private readonly FilterDefinitionBuilder<Book> filterBuiler = Builders<Book>.Filter;

        public MongoDbBooksRepository(IMongoClient mongoClient)
        {
            IMongoDatabase database = mongoClient.GetDatabase(databaseName);
            booksCollection = database.GetCollection<Book>(collectionName);
        }

        public async Task CreateBookAsync(Book book)
        {
            await booksCollection.InsertOneAsync(book);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await booksCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Book> GetBookAsync(Guid id)
        {
            var filter = filterBuiler.Eq(book => book.Id,id);
            
            return await booksCollection.Find(filter).SingleOrDefaultAsync();
            
        }
        public async Task<IEnumerable<Book>> SearchAsync(string title = "", string authors = "", string minNumPage = "", string maxNumPage = "")
        {
            

            var titleFilter = filterBuiler.Regex(book => book.Title, "/.*" + title + ".*/");
            var authorsFilter = filterBuiler.Regex(book => book.Authors, "/.*" + authors + ".*/");
            var minNumPageFilter = filterBuiler.Gt(book => book.NumPage, minNumPage);
            Console.WriteLine(maxNumPage);
            if (minNumPage == "" || minNumPage == null)
            {
                minNumPageFilter = filterBuiler.Gt(book => book.NumPage, "0");
            }
            var maxNumPageFilter = filterBuiler.Lt(book => book.NumPage, maxNumPage);
            if (maxNumPage == "" || maxNumPage == null)
            {
                Console.WriteLine("yes");
                maxNumPageFilter = filterBuiler.Lt(book => book.NumPage, double.PositiveInfinity.ToString());
            }
            
            var combineFilters = Builders<Book>.Filter.And(titleFilter, authorsFilter,minNumPageFilter,maxNumPageFilter);
            return await booksCollection.Find(combineFilters).ToListAsync();
        }
        private Exception NotImplementedException()
        {
            throw new NotImplementedException();
        }
    }
}
