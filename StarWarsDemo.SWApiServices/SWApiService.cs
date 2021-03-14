using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RestSharp;
using StarWarsDemo.SWApiServices.Dto;
using StarWarsDemo.SWApiServices.Models;

namespace StarWarsDemo.SWApiServices
{
    public class SWApiService : ISWApiService
    {
        public async Task<List<Film>> GetFilms()
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest("films/", DataFormat.Json);
            var films = await client.GetAsync<FilmsResponse>(request);
            return films.Results.Select(
                    s => new Film
                    {
                        Id = ExtractFilmId(s.Url),
                        Title = s.Title,
                        Url = s.Url
                    })
                .ToList();
        }

        public async Task<FilmDetails> GetFilmDetails(int filmId)
        {
            var client = new RestClient("https://swapi.dev/api/");
            var request = new RestRequest($"films/{filmId}/", DataFormat.Json);
            var filmDetails = await client.GetAsync<FilmDetailsResponse>(request);
            var test = await MapTo(filmDetails);
            return test;
        }

        private int ExtractFilmId(string url)
        {
            var uri = new Uri(url);
            return int.Parse(Regex.Match(uri.Segments.Last(), @"\d+").Value);
        }

        private async Task<FilmDetails> MapTo(FilmDetailsResponse response)
        {
            var filmDetails = new FilmDetails()
            {
                FilmId = ExtractFilmId(response.url),
                Title = response.title,
                Created = response.created,
                Director = response.director,
                EpisodeId = response.episode_id,
                OpeningCrawl = response.opening_crawl,
                Producer = response.producer,
                ReleaseDate = response.release_date
            };
            var charactersTask = Task.Factory.StartNew(() =>
            {
                filmDetails.Characters =  GetNameByItemsUrls(response.characters).Result;
            });
            var speciesTask = Task.Factory.StartNew(() =>
            {
                filmDetails.Species = GetNameByItemsUrls(response.species).Result;
            });
            var vehiclesTask = Task.Factory.StartNew(() =>
            {
                filmDetails.Vehicles = GetNameByItemsUrls(response.vehicles).Result;
            });
            var planetsTask = Task.Factory.StartNew(() =>
            {
                filmDetails.Planets = GetNameByItemsUrls(response.planets).Result;
            });
            var starshipsTask = Task.Factory.StartNew(() =>
            {
                filmDetails.Starships = GetNameByItemsUrls(response.starships).Result;
            });

            Task.WaitAll(charactersTask, speciesTask, vehiclesTask, planetsTask, starshipsTask);

            return filmDetails;
        }

        private async Task<List<string>> GetNameByItemsUrls(IEnumerable<string> itemsUrls)
        {
            var names = new List<string>();
            var tasks = itemsUrls.Select(
                async item =>
                {
                    var client = new RestClient(item);
                    var request = new RestRequest("", DataFormat.Json);
                    var result = await client.GetAsync<FilmDetailItemResponse>(request);
                    names.Add(result.Name);
                });
            await Task.WhenAll(tasks);
            return names;
        }
    }
}
