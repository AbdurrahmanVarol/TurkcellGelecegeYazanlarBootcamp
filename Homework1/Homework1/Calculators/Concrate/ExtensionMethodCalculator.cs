using Homework1.Calculators.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Calculators.Concrate
{
    public class ExtensionMethodCalculator : CalculatorBase
    {
        public override double GetAvarageOfNumbers(int[] numbers)
        {
            return numbers.Average();
        }
        public override int GetMaxValue(int[] numbers)
        {
            return numbers.Max();
        }

        public override int GetMinValue(int[] numbers)
        {
            return numbers.Min();
        }

        public override int GetSumOfNumbers(int[] numbers)
        {
            return numbers.Sum();
        }
    }
}
