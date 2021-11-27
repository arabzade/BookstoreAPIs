using System;
using MongoBookApis.Repositories;
using MongoBookApis.Models;

namespace MongoBookApis
{

    public static class Extensions
    {
        // Converting Book model to BookDto model
        public static BookDto AsDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Authors = book.Authors,
                AverageRating = book.AverageRating,
                NumPage = book.NumPage,
                RatingCount = book.RatingCount,
                TextReviewCount = book.TextReviewCount,
                PublicationDate = book.PublicationDate,
                Publisher = book.Publisher,
                CreatedDate = book.CreatedDate
            };
        }
    }
}
