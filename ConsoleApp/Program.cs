Console.WriteLine(" === Тестируем OtusCalculator ===");
try
{
    string expression;
    
    expression = "100 + 200";
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "400 - 50";    
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "8 * 7";    
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "9 / 3";    
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "10 4";    
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "10 % 4";
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "10+4";
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "13c4 + 5";
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "13 / 0";
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "10 + 3";
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);

    expression = "10.4 + 2";
    Console.WriteLine(expression);
    OtusCalculator.Calculate(expression);    
}
catch (Exception ex)
{
    Console.WriteLine($"В калькуляторе произошла ошибка: {ex.Message}");
}
Console.WriteLine("=== Тестирование выполнено ===\n");
while (true)
{
    Console.Write("Введите выражение(\"стоп\" - выход): ");
    var expression = Console.ReadLine();
    if (expression == "стоп") break;
    try
    {
        OtusCalculator.Calculate(expression);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"В калькуляторе произошла ошибка: {ex.Message}");
        break;
    }
}
