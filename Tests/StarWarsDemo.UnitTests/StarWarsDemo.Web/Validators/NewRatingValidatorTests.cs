using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using StarWarsDemo.Web.Validators;
using Xunit;

namespace StarWarsDemo.UnitTests.StarWarsDemoWeb.Validators
{
    public class NewRatingValidatorTests
    {
        [Theory]
        [InlineData("1")]
        [InlineData("0")]
        [InlineData("10")]
        public void When_Rating_Correct_Return_Ok(string rating)
        {
            var validator = new NewRatingValidator();
            var result = validator.TestValidate(rating);
            result.ShouldNotHaveValidationErrorFor(rating => rating);
        }

        [Theory]
        [InlineData("")]
        [InlineData("-1")]
        [InlineData("11")]
        [InlineData("ddd")]
        public void When_Rating_Is_Wrong_Return_Error(string rating)
        {
            var validator = new NewRatingValidator();
            var result = validator.TestValidate(rating);
            result.ShouldHaveValidationErrorFor(rating => rating);
        }
    }
}
