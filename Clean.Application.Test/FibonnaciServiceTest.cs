using Clean.Application.Interfaces;
using Clean.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Test
{
    public class FibonnaciServiceTest
    {
        private readonly FibonacciService _service;
        
        public FibonnaciServiceTest(FibonacciService service)
        {
            _service = service;
        }

        [Theory]
        [InlineData(3,3)]
        [InlineData(4,5)]
        [InlineData(5,8)]
        public void GetFibonacciValue_ShouldReturnExpectedOutput(int n, int expectedValue)
        {
            //Arrange
            int output;

            //Act
            output = _service.GetFibonacciValue(n);

            //Assert
            Assert.Equal(expectedValue, output); 
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 8)]
        public void LoadFibonacciList(int n, int value)
        {
            //Act
            _service.LoadFibonacciList(n, value);

            //Assert
            Assert.Contains(_service._fibonacciList, x => x.Key == n &&  x.Value == value);
        }
    }
}
