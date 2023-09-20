using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean.Application.Interfaces;

namespace Clean.Application.Services
{
    public class FizzBuzzService : IFizzBuzzService
    {
        public required Dictionary<int, string> _fizzbuzz = new Dictionary<int, string>();

        public Dictionary<int, string> GetFizzBuzz()
        {
            for (int i = 1; i <= 100; i++)
            {
                SetFizz(i);
                SetBuzz(i);
            }
            return _fizzbuzz;
        }
        public void SetFizz(int number)
        {
            if (IsDivisibleByX(3,number)) LoadFizzBuzz(number, "fizz");
        }
        public void SetBuzz(int number)
        {
            if (IsDivisibleByX(5, number)) LoadFizzBuzz(number, "buzz");
        }
        public static bool IsDivisibleByX(int divisible, int number)
        {
            var returnVal = number % divisible == 0;
            return returnVal;
        }

        public void LoadFizzBuzz(int number, string fizzBuzz) 
        {
            if(/*_fizzbuzz.Count > 1 && */_fizzbuzz.ContainsKey(number)) _fizzbuzz[number] = $"{_fizzbuzz[number]}{fizzBuzz}";
            else _fizzbuzz.Add(number, fizzBuzz);
        }
    }
}
