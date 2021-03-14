using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FakeItEasy;
using Logic;
using StarWarsDemo.Dal;
using StarWarsDemo.SWApiServices;
using StarWarsDemo.SWApiServices.Dto;
using Xunit;
using FluentAssertions;

namespace StarWarsDemo.UnitTests.StarWarsDemoLogic
{
    public class FilmServiceTests
    {
        [Fact]
        public async Task test()
        {
            var swApiService = A.Fake<ISWApiService>();
            var ratingRepository = A.Fake<IRatingRepository>();
            A.CallTo(() => swApiService.GetFilmDetails(A.Dummy<int>())).Returns(new FilmDetails());
            A.CallTo(() => ratingRepository.GetRatings(A.Dummy<int>())).Returns(new List<int>() {1, 2, 3});

            var sut = new FilmsService(swApiService, ratingRepository);
            var result = await sut.GetFIlmDetails(A.Dummy<int>());

            result.Ratings.Should().HaveCount(3);
            result.Ratings.FirstOrDefault().Should().Be(1);
            result.Ratings.LastOrDefault().Should().Be(3);
        }
    }
}
