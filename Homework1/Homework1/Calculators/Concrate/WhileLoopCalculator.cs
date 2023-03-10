using Homework1.Calculators.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Calculators.Concrate
{
    public class WhileLoopCalculator : CalculatorBase
    {
        public override int GetMaxValue(int[] numbers)
        {
            var max = int.MinValue;

            int i = 0;
            var length = numbers.Length;
            while (i < length)
            {
                if (numbers[i] > max)
                    max = numbers[i];
                i++;
            }
            return max;
        }

        public override int GetMinValue(int[] numbers)
        {
            var min = int.MaxValue;

            int i = 0;
            var length = numbers.Length;
            while (i < length)
            {
                if (numbers[i] < min)
                    min = numbers[i];
                i++;
            }
            return min;
        }

        public override int GetSumOfNumbers(int[] numbers)
        {
            var total = 0;

            int i = 0;
            var length = numbers.Length;
            while (i < length)
            {
                total += numbers[i++];
            }
            return total;
        }
    }
}
