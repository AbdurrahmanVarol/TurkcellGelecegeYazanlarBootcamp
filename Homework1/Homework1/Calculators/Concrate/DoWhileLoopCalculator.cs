using Homework1.Calculators.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Calculators.Concrate
{
    public class DoWhileLoopCalculator : CalculatorBase
    {
        public override int GetMaxValue(int[] numbers)
        {
            var max = int.MinValue;

            int i = 0;
            var length = numbers.Length;
            do
            {
                if (numbers[i] > max)
                    max = numbers[i];
                i++;
            }
            while (i < length);

            return max;
        }

        public override int GetMinValue(int[] numbers)
        {
            var min = int.MaxValue;

            int i = 0;
            var length = numbers.Length;
            do
            {
                if (numbers[i] < min)
                    min = numbers[i];
                i++;
            }
            while (i < length);
            return min;
        }

        public override int GetSumOfNumbers(int[] numbers)
        {
            var total = 0;

            int i = 0;
            var length = numbers.Length;
            do
            {
                total += numbers[i++];
            }
            while (i < length);
            return total;
        }
    }
}
