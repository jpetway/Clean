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
            throw new NotImplementedException();
        }

        public int GetFibonacciValue(int n)
        {
            if (_fibonacciList.Count() < 3) return n;
            else return _fibonacciList.Where(x => x.Key < n && x.Key >= (n - 2)).Sum(x => x.Value);
        }

        public void LoadFibonacciList(int n, int value)
        {
            throw new NotImplementedException();
        }
    }
}
