﻿using System.ComponentModel;

namespace AwesomeBlazor.Services.Models.Movies
{
    public enum GenreMovie : int
    {
        Action = 28,
        Adventure = 12,
        Animation = 16,
        Comedy = 35,
        Crime = 80,
        Documentary = 99,
        Drama = 18,
        Family = 10751,
        Fantasy = 14,
        History = 36,
        Horror = 27,
        Music = 10402,
        Mystery = 9648,
        Romance = 10749,
        [Description("Science Fiction")]
        ScienceFiction = 878,
        TVMovie = 10770,
        Thriller = 53,
        War = 10752,
        Western = 37
    }
}
