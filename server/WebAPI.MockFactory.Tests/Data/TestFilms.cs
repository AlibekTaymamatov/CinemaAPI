namespace WebAPI.MockFactory.Tests.Data
{
    using System;
    using System.Collections.Generic;
    using Domain.Models;

    public static class TestFilms
    {
        private static DateTime date = new DateTime(2021, 7, 20);

        public static Film FilmA => new () { Name = "FilmA", Poster = "testurl", Description = "testDescription", Duratuin = 160, Rating = 3, StartDate = date };

        public static Film FilmB => new () { Name = "FilmB", Poster = "testurl", Description = "testDescription", Duratuin = 160, Rating = 5, StartDate = date };

        public static Film FilmC => new () { Name = "FilmB", Poster = "testurl", Description = "testDescription", Duratuin = 160, Rating = 7, StartDate = date };

        public static List<Film> AllProducts => new () { FilmA, FilmB, FilmC };
    }
}
