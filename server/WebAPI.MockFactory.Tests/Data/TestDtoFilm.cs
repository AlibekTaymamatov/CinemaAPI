namespace WebAPI.MockFactory.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using Application.DTO.Request;

    public static class TestDtoFilm
    {
        private static DateTime date = new DateTime(2021, 7, 20);
        private static List<int> emptyArr = new List<int>() { };

        public static FilmUpdateRequestDto FilmA => new () { Id = 1, Name = "FilmB", Poster = "testurl", Description = "testDescription", Duratuin = 60, Rating = 3, StartDate = date, Genres = emptyArr };

        public static FilmCreateRequestDto FilmB => new () { Name = "FilmTest", Poster = "testurl", Description = "testDescription", Duratuin = 60, Rating = 3, StartDate = date, Genres = emptyArr };
    }
}
