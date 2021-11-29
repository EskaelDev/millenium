using System;
using Microsoft.Extensions.Logging;
using Millennium.Models;
using Millennium.Persistance;
using Moq;
using Xunit;

namespace Millennium.Test
{
    public class PersonRepositoryTest
    {
        [Fact]
        public void Given_Correct_Person_When_Validate_ReturnTrue()
        {
            // arrange
            var logger = Mock.Of<ILogger<Person>>();
            var repo = new PersonRepository(logger);
            var person = new Person()
            {
                Address = "Poland",
                Age = 13,
                Name = "Kamil"
            };
            // act
            var result = repo.Add(person);

            // assert
            Assert.NotNull(result.Id);
        }

        [Fact]
        public void Given_Incorrect_PersonId_When_Validate_ReturnFalse()
        {
            // arrange
            var logger = Mock.Of<ILogger<Person>>();
            var repo = new PersonRepository(logger);
            // act
            var guid = Guid.NewGuid();    
            repo.Delete(guid);
            var result = repo.GetById(guid);

            // assert
            Assert.Null(result);
        }
    }
}