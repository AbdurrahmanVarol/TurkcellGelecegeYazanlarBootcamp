using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Calculators.Abstract
{
    public abstract class CalculatorBase
    {
        public virtual string ClassName =>GetType().Name;
        public virtual double GetAvarageOfNumbers(int[] numbers)
        {
            var total = GetSumOfNumbers(numbers);
            var length = numbers.Length;
            var avarage = total / length;
            return avarage;
        }
        public abstract int GetMaxValue(int[] numbers);
        public abstract int GetMinValue(int[] numbers);
        public abstract int GetSumOfNumbers(int[] numbers);
    }
}
