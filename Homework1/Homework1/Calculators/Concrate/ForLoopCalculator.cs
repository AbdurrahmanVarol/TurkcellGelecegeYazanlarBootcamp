using Homework1.Calculators.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Calculators.Concrate
{
    public class ForLoopCalculator : CalculatorBase
    {
        public override int GetMaxValue(int[] numbers)
        {
            var max = int.MinValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > max)
                    max = numbers[i];
            }
            return max;
        }

        public override int GetMinValue(int[] numbers)
        {
            var min = int.MaxValue;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                    min = numbers[i];
            }
            return min;
        }

        public override int GetSumOfNumbers(int[] numbers)
        {
            var total = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                total += numbers[i];
            }
            return total;
        }
    }
}
