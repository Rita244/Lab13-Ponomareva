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

// Console.WriteLine();
// Console.WriteLine("=== Несколько catch ===");

// Console.Write("Введите делитель: ");
// try
// {
//     int divisor = int.Parse(Console.ReadLine());
//     int result = 100 / divisor;
//     Console.WriteLine($"Результат: {result}");
// }
// catch (FormatException)
// {
//     Console.WriteLine("Ошибка: это не число");
// }
// catch (DivideByZeroException)
// {
//     Console.WriteLine("Ошибка: нельзя делить на ноль");
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"Непредвиденная ошибка: {ex.Message}");
// }

// ### Шаг 7. Блок, который выполняется всегда

// Console.WriteLine();
// Console.WriteLine("=== finally ===");

// try
// {
//     Console.WriteLine("Пытаемся выполнить операцию...");
//     int[] numbers = { 1, 2, 3 };
//     Console.WriteLine(numbers[5]);
// }
// catch (IndexOutOfRangeException ex)
// {
//     Console.WriteLine($"Ошибка: {ex.Message}");
// }
// finally
// {
//     Console.WriteLine("Этот блок выполнится в любом случае");
// }

// Console.WriteLine();
// Console.WriteLine("=== finally без ошибки ===");

// try
// {
//     Console.WriteLine("Операция без ошибок");
// }
// finally
// {
//     Console.WriteLine("И здесь finally тоже сработал");
// }

// ### Шаг 9. Выбрасывание встроенного исключения

// Console.WriteLine();
// Console.WriteLine("=== throw ===");

// try
// {
//     double result = CalculateSquareRoot(-5);
//     Console.WriteLine(result);
// }
// catch (ArgumentException ex)
// {
//     Console.WriteLine($"Ошибка: {ex.Message}");
// }

// double CalculateSquareRoot(double number)
// {
//     if (number < 0)
//     {
//         throw new ArgumentException("Число не может быть отрицательным");
//     }
//     return Math.Sqrt(number);
// }

// ### Шаг 10. Собственный класс исключения

// using System;

// Console.WriteLine();
// Console.WriteLine("=== Собственное исключение ===");

// try
// {
//     Withdraw(1000, 1500);
// }
// catch (NegativeBalanceException ex)
// {
//     Console.WriteLine($"Операция отклонена: {ex.Message}");
// }

// Withdraw(1000, 400);

// static void Withdraw(double balance, double amount)
// {
//     if (amount > balance)
//     {
//         throw new NegativeBalanceException($"Недостаточно средств: на счёте {balance}, а нужно снять {amount}");
//     }
//     Console.WriteLine($"Снято {amount}, остаток {balance - amount}");
// }

// class NegativeBalanceException : Exception
// {
//     public NegativeBalanceException(string message) : base(message)
//     {
//     }
// }

// ### Шаг 12. Собираем обработку исключений в калькулятор

// using System;

// class Program
// {
//     static void Main()
//     {
//         bool exit = false;
        
//         do
//         {
//             try
//             {
//                 Console.Write("Введите первое число: ");
//                 string input1 = Console.ReadLine()!;
                
//                 Console.Write("Введите второе число: ");
//                 string input2 = Console.ReadLine()!;
                
//                 Console.Write("Введите операцию (+, -, *, /): ");
//                 string operation = Console.ReadLine()!;

//                 int num1 = int.Parse(input1);
//                 int num2 = int.Parse(input2);

//                 double result = 0;

//                 switch (operation)
//                 {
//                     case "+":
//                         result = num1 + num2;
//                         break;
//                     case "-":
//                         result = num1 - num2;
//                         break;
//                     case "*":
//                         result = num1 * num2;
//                         break;
//                     case "/":
//                         if (num2 == 0)
//                         {
//                             throw new DivideByZeroException();
//                         }
//                         result = (double)num1 / num2;
//                         break;
//                     default:
//                         throw new UnknownOperationException($"Неизвестная операция: {operation}");
//                 }

//                 Console.WriteLine($"Результат: {result}");
//             }
//             catch (FormatException)
//             {
//                 Console.WriteLine("Ошибка: некорректный ввод числа.");
//             }
//             catch (DivideByZeroException)
//             {
//                 Console.WriteLine("Ошибка: деление на ноль.");
//             }
//             catch (UnknownOperationException ex)
//             {
//                 Console.WriteLine($"Ошибка: {ex.Message}");
//             }
//             finally
//             {
//                 Console.WriteLine("-------------------------");
//             }

//             Console.WriteLine("Хотите продолжить? (y/n)");
//             string answer = Console.ReadLine()!;
//             if (answer.ToLower() == "n")
//             {
//                 exit = true;
//             }

//         } while (!exit);
//     }
// }

// class UnknownOperationException : Exception
// {
//     public UnknownOperationException(string message) : base(message)
//     {
//     }
// }


// ## Самостоятельные задания

// ### Задание 1. Безопасный доступ к массиву ★

// using System;

// int[] numbers = { 10, 20, 30, 40, 50 };

// Console.WriteLine("Массив: [10, 20, 30, 40, 50]");
// Console.Write("Введите индекс элемента (от 0 до 4): ");
// string input = Console.ReadLine()!;

// try
// {
//     int index = int.Parse(input);
//     int value = numbers[index];
//     Console.WriteLine($"Значение по индексу {index}: {value}");
// }
// catch (FormatException)
// {
//     Console.WriteLine("Ошибка: введено не число.");
// }
// catch (IndexOutOfRangeException)
// {
//     Console.WriteLine("Ошибка: индекса с таким номером не существует (выход за границы массива).");
// }

// ### Задание 2. Валидатор возраста через throw ★★

// using System;

// class Program
// {
//     static void Main()
//     {
//         Console.Write("Введите ваш возраст: ");
//         string input = Console.ReadLine()!;

//         try
//         {
//             int age = int.Parse(input);
//             CheckAge(age);
//             Console.WriteLine("Возраст корректный.");
//         }
//         catch (FormatException)
//         {
//             Console.WriteLine("Ошибка: введено не число.");
//         }
//         catch (ArgumentException ex)
//         {
//             Console.WriteLine($"Ошибка: {ex.Message}");
//         }
//     }

//     static void CheckAge(int age)
//     {
//         if (age < 0 || age > 120)
//         {
//             throw new ArgumentException("Возраст должен быть от 0 до 120 лет.");
//         }
//     }
// }

// ### Задание 3. Банковский счёт с двумя своими исключениями ★★★

using System;

class Program
{
    static void Main()
    {
        double balance = 1000.0;
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Пополнить счет");
            Console.WriteLine("2. Снять средства");
            Console.WriteLine("3. Выйти");
            Console.Write("Выберите действие: ");
            
            string choice = Console.ReadLine()!;

            try
            {
                switch (choice)
                {
                    case "1":
                        Console.Write("Введите сумму для пополнения: ");
                        double depositAmount = double.Parse(Console.ReadLine()!);
                        Deposit(ref balance, depositAmount);
                        Console.WriteLine("Счет успешно пополнен.");
                        break;
                    case "2":
                        Console.Write("Введите сумму для снятия: ");
                        double withdrawAmount = double.Parse(Console.ReadLine()!);
                        Withdraw(ref balance, withdrawAmount);
                        Console.WriteLine("Средства успешно сняты.");
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка: сумма должна быть числом.");
            }
            catch (InvalidAmountException ex)
            {
                Console.WriteLine($"Ошибка операции: {ex.Message}");
            }
            catch (InsufficientFundsException ex)
            {
                Console.WriteLine($"Ошибка операции: {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"Текущий баланс: {balance:F2}");
            }
        }
    }

    static void Deposit(ref double balance, double amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException("Сумма пополнения должна быть больше нуля.");
        }
        balance += amount;
    }

    static void Withdraw(ref double balance, double amount)
    {
        if (amount <= 0)
        {
            throw new InvalidAmountException("Сумма снятия должна быть больше нуля.");
        }
        if (amount > balance)
        {
            throw new InsufficientFundsException("Недостаточно средств на счете.");
        }
        balance -= amount;
    }
}

class InvalidAmountException : Exception
{
    public InvalidAmountException(string message) : base(message)
    {
    }
}

class InsufficientFundsException : Exception
{
    public InsufficientFundsException(string message) : base(message)
    {
    }
}