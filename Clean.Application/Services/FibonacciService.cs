using Clean.Application.DTOs;
using Clean.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Services
{
    public class FibonacciService : IFibonacciService
    {
        public List<FibonacciDto> _fibonacciList = new List<FibonacciDto>();
        public FibonacciDto FibonacciNPosition(int n)
        {
            for (int i = 1; i <= n; i++)
            {
                var value = GetFibonacciValue(i);
                LoadFibonacciList(i, value);
            }

            var returnItem = _fibonacciList.OrderByDescending(x => x.Key).FirstOrDefault();

            return returnItem;
        }

        private long GetFibonacciValue(int n)
        {
            if (_fibonacciList.Count() < 3) return n;
            else
            {
                var skip = (n - 2) - 1;
                var previousTwo = _fibonacciList.Skip(skip).Take(2);
                return previousTwo.Sum(x => x.Value);
            };
        }

        public void LoadFibonacciList(int n, long value)
        {
            _fibonacciList.Add(new FibonacciDto { Key = n, Value = value });
        }
    }
}
