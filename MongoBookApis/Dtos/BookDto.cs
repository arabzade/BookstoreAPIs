using System;

namespace MongoBookApis.Models
{
    public record BookDto
    {
        public Guid Id { get; init; }

        public string Title { get; init; }

        public string Authors { get; init; }

        public string AverageRating { get; init; }

        public string NumPage { get; init; }

        public string RatingCount { get; init; }

        public string TextReviewCount { get; init; }

        public string PublicationDate { get; set; }

        public string Publisher { get; init; }

        public string CreatedDate { get; set; }
    }
}
