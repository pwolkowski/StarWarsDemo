using System;
using System.Collections.Generic;
using StarWarsDemo.SWApiServices.Dto;

namespace StarWarsDemo.Web.VM
{
    public class FilmDetailsVm
    {
        public int FilmId { get; set; }
        public string Title { get; set; }
        public int EpisodeId { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public string ReleaseDate { get; set; }
        public List<string> Characters { get; set; }
        public List<string> Planets { get; set; }
        public List<string> Starships { get; set; }
        public List<string> Vehicles { get; set; }
        public List<string> Species { get; set; }
        public DateTime Created { get; set; }
        public List<int> Ratings { get; set; }
        public List<string> NewRatingErrors { get; set; } = new List<string>();

        public static FilmDetailsVm Map(FilmDetails filmDetails)
        {
            return new FilmDetailsVm
            {
                FilmId = filmDetails.FilmId,
                Title = filmDetails.Title,
                EpisodeId = filmDetails.EpisodeId,
                OpeningCrawl = FormatToHtml(filmDetails),
                Director = filmDetails.Director,
                Producer = filmDetails.Producer,
                ReleaseDate = filmDetails.ReleaseDate,
                Characters = filmDetails.Characters,
                Planets = filmDetails.Planets,
                Starships = filmDetails.Starships,
                Vehicles = filmDetails.Vehicles,
                Species = filmDetails.Species,
                Created = filmDetails.Created,
                Ratings = filmDetails.Ratings,
            };
        }

        private static string FormatToHtml(FilmDetails filmDetails)
        {
            return filmDetails.OpeningCrawl.Replace("\r\n", "<br>\r\n");
        }
    }
}
