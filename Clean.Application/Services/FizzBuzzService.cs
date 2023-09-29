using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Application.Interfaces;

namespace Clean.Application.Services;

public class FizzBuzzService : IFizzBuzzService
{
    public Dictionary<int, string> _fizzbuzz = new Dictionary<int, string>();

    public Dictionary<int, string> GetFizzBuzz()
    {
        for (int i = 1; i <= 100; i++)
        {
            SetFizzBuzz(i, 3, "fizz");
            SetFizzBuzz(i, 5, "buzz");
        }
        return _fizzbuzz;
    }
    public void SetFizzBuzz(int number, int divisbleBy, string fizzBuzz)
    {
        if (IsDivisibleByX(divisbleBy,number)) LoadFizzBuzz(number, fizzBuzz);
    }
    public static bool IsDivisibleByX(int divisible, int number)
    {
        var returnVal = number % divisible == 0;
        return returnVal;
    }

    public void LoadFizzBuzz(int number, string fizzBuzz) 
    {
        if(_fizzbuzz.ContainsKey(number)) _fizzbuzz[number] = $"{_fizzbuzz[number]}{fizzBuzz}";
        else _fizzbuzz.Add(number, fizzBuzz);
    }
}
