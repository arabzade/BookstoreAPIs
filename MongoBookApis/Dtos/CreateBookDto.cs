using System;
using System.ComponentModel.DataAnnotations;

namespace MongoBookApis.Dtos
{
    public record CreateBookDto
    {
        [Required]
        public string Title { get; init; }

        [Required]
        public string Authors { get; init; }

        public string AverageRating { get; init; }

        public string NumPage { get; init; }

        public string RatingCount { get; init; }

        public string TextReviewCount { get; init; }

        [Required]
        public string PublicationDate { get; set; }

        public string Publisher { get; init; }
    }
}
