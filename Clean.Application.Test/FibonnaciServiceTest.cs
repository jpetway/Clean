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
        
        public FibonnaciServiceTest()
        {
            _service = new FibonacciService();
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, 3)]
        [InlineData(5, 8)]
        public void LoadFibonacciList_ShouldAddListItem(int n, int value)
        {
            //Act
            _service.LoadFibonacciList(n, value);

            //Assert
            Assert.Contains(_service._fibonacciList, x => x.Key == n &&  x.Value == value);
        }

        [Theory]
        [InlineData(1,1)]
        [InlineData(2,2)]
        [InlineData(3,3)]
        [InlineData(4,5)]
        [InlineData(5,8)]
        [InlineData(6,13)]
        [InlineData(7,21)]
        [InlineData(8,34)]
        public void FibonacciNPosition_ShouldReturnFibonacciValue(int n, int expectedValue)
        {
            //Act
            var nValue = _service.FibonacciNPosition(n);

            //Assert
            Assert.Equal(expectedValue, nValue.Value);
        }
    }
}
