using Clean.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Test
{
    public class FizzBuzzServiceTest
    {
        private readonly FizzBuzzService _service;

        public FizzBuzzServiceTest()
        {
            _service = new FizzBuzzService();
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void SetFizz_ShouldSetDictionary(int number)
        {
            // Act
            _service.SetFizzBuzz(number, 3, "fizz");
            var list = _service._fizzbuzz.ToList();

            //Assert
            Assert.True(list.Where(x => x.Value == "fizz").Any());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void SetFizz_ShouldNotSetDictionary(int number)
        {
            // Act
            _service.SetFizzBuzz(number, 3, "fizz");
            var list = _service._fizzbuzz.ToList();

            //Assert
            Assert.False(list.Where(x => x.Value == "fizz").Any());
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        [InlineData(25)]
        public void SetBuzz_ShouldSetDictionary(int number)
        {
            //Act
            _service.SetFizzBuzz(number, 5, "buzz");
            var list = _service._fizzbuzz.ToList();
            //Assert
            Assert.True(list.Where(x => x.Value == "buzz").Any());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(12)]
        public void SetBuzz_ShouldNotSetDictionary(int number)
        {
            // Act
            _service.SetFizzBuzz(number, 5, "buzz");
            var list = _service._fizzbuzz.ToList();

            //Assert
            Assert.False(list.Where(x => x.Value == "buzz").Any());
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        [InlineData(60)]
        public void SetFizzBuzz_ShouldSetDictionary(int number)
        {
            //Act
            _service.SetFizzBuzz(number, 3, "fizz");
            _service.SetFizzBuzz(number, 5, "buzz");

            var list = _service._fizzbuzz.ToList();

            //Assert
            Assert.True(list.Where(x => x.Value == "fizzbuzz").Any());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(9)]
        [InlineData(10)]
        [InlineData(12)]
        [InlineData(20)]
        [InlineData(25)]
        public void SetFizzBuzz_ShouldNotSetDictionary(int number)
        {
            //Act
            _service.SetFizzBuzz(number, 3, "fizz");
            _service.SetFizzBuzz(number, 5, "buzz");

            var list = _service._fizzbuzz.ToList();

            //Assert
            Assert.True(list.Where(x => x.Value == "fizzbuzz").Any());
        }


    }
}
