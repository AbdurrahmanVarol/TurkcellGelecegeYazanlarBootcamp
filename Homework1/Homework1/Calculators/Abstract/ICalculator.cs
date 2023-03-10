using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework1.Calculators.Abstract
{
    public interface ICalculator
    {
        int GetMaxValue(int[] numbers);
        int GetMinValue(int[] numbers);
        int GetSumOfNumbers(int[] numbers);
        double GetAvarageOfNumbers(int[] numbers);
    }
}
