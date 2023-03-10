using Homework1.Calculators.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Calculators.Concrate
{
    public class ForeachLoopCalculator : CalculatorBase
    {
        public override int GetMaxValue(int[] numbers)
        {
            var max = int.MinValue;
            foreach (var number in numbers)
            {
                if (number > max)
                    max = number;
            }
            return max;
        }

        public override int GetMinValue(int[] numbers)
        {
            var min = int.MaxValue;
            foreach (var number in numbers)
            {
                if (number < min)
                    min = number;
            }
            return min;
        }

        public override int GetSumOfNumbers(int[] numbers)
        {
            var total = 0;
            foreach (var number in numbers)
            {
                total += number;
            }
            return total;
        }
    }
}
