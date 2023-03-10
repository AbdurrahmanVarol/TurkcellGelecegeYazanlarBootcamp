
using Homework1.Calculators.Abstract;
using Homework1.Calculators.Concrate;

var numbers = new int[] { 1, 123, 412, 6234, 12, -78, -82, 0, 2, 6, 9, 908044, 8 };

var calculators = new List<CalculatorBase>
{
    new ForLoopCalculator(),
    new ForeachLoopCalculator(),
    new WhileLoopCalculator(),
    new DoWhileLoopCalculator(),
    new ExtensionMethodCalculator()
};

foreach (var calculator in calculators)
{
    Console.WriteLine($"--------{calculator.ClassName}--------");

    var maxNumber = calculator.GetMaxValue(numbers);
    var minNumber = calculator.GetMinValue(numbers);
    var avarageOfNumbers = calculator.GetAvarageOfNumbers(numbers);
    var sumOfNumbers = calculator.GetSumOfNumbers(numbers);
    Console.WriteLine($"Max number: {maxNumber}\nMin number: {minNumber}\n Avarage of numbers: {avarageOfNumbers}\nSum of numbers: {sumOfNumbers}");
}
Console.ReadKey();