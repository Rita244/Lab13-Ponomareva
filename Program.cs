// ### Шаг 2. Перехватываем FormatException — наконец безопасно

// Console.WriteLine("=== try-catch: FormatException ===");

// try
// {
//     Console.Write("Введите число: ");
//     int number = int.Parse(Console.ReadLine());
//     Console.WriteLine($"Вы ввели: {number}");
// }
// catch (FormatException)
// {
//     Console.WriteLine("Ошибка: введено не число!");
// }

// Console.WriteLine("Программа продолжает работу как ни в чём не бывало");

// ### Шаг 4. Доступ к сообщению об ошибке

// Console.WriteLine();
// Console.WriteLine("=== ex.Message ===");

// try
// {
//     int[] numbers = { 1, 2, 3 };
//     Console.WriteLine(numbers[10]);
// }
// catch (IndexOutOfRangeException ex)
// {
//     Console.WriteLine($"Произошла ошибка: {ex.Message}");
// }

// ### Шаг 5. Несколько catch-блоков в правильном порядке

Console.WriteLine();
Console.WriteLine("=== Несколько catch ===");

Console.Write("Введите делитель: ");
try
{
    int divisor = int.Parse(Console.ReadLine());
    int result = 100 / divisor;
    Console.WriteLine($"Результат: {result}");
}
catch (FormatException)
{
    Console.WriteLine("Ошибка: это не число");
}
catch (DivideByZeroException)
{
    Console.WriteLine("Ошибка: нельзя делить на ноль");
}
catch (Exception ex)
{
    Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
}