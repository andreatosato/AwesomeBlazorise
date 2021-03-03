using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace AwesomeBlazor.Services.Models.Movies
{
    public class Movie
    {
        [JsonPropertyName("poster_path")]
        public string PosterPath { get; set; }
        public string PosterUrl => $"https://image.tmdb.org/t/p/original{PosterPath}";

        [JsonPropertyName("adult")]
        public bool Adult { get; set; }

        [JsonPropertyName("overview")]
        public string Overview { get; set; }

        [JsonPropertyName("release_date")]
        public DateTimeOffset ReleaseDate { get; set; }

        [JsonPropertyName("genre_ids")]
        public List<GenreMovie> GenreIds { get; set; } = new List<GenreMovie>();

        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("original_title")]
        public string OriginalTitle { get; set; }

        [JsonPropertyName("original_language")]
        public string OriginalLanguage { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("backdrop_path")]
        public string BackdropPath { get; set; }
        public string BackdropUrl => $"https://image.tmdb.org/t/p/original{BackdropPath}";

        [JsonPropertyName("popularity")]
        public decimal Popularity { get; set; }

        [JsonPropertyName("vote_count")]
        public long VoteCount { get; set; }

        [JsonPropertyName("video")]
        public bool Video { get; set; }

        [JsonPropertyName("vote_average")]
        public decimal VoteAverage { get; set; }
    }
}
