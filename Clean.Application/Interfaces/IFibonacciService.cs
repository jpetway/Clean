using Clean.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Application.Interfaces
{
    public interface IFibonacciService
    {
        FibonacciDto FibonacciNPosition(int n);
        int GetFibonacciValue(int n);
        void LoadFibonacciList(int n, int value);
    }
}
