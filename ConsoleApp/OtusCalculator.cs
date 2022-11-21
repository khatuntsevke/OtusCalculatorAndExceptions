using System.ComponentModel.DataAnnotations;
using System.Text;

internal static class OtusCalculator
{
    public static void Calculate(string? expression)
    {
        try
        {
            if (String.IsNullOrEmpty(expression)) throw new Exception();

            string normolizeExpression = RemoveDupliсateWhiteSpace(expression.Trim());
            var exprParts = normolizeExpression.Split();
            if (exprParts.Length != 3)
            {
                if (exprParts.Length == 2)
                {
                    try
                    {
                        int.Parse(exprParts[0]);
                        int.Parse(exprParts[1]);
                    }
                    catch (Exception)
                    {
                        throw new ExpressionIsWrong(); //case 3
                    }
                    throw new OperatorIsMissing(); //case 1
                }
                throw new ExpressionIsWrong(); //case 3
            }

            int leftOperand;
            try
            {
                leftOperand = int.Parse(exprParts[0]);
            }
            catch (Exception)
            {
                try
                {
                    Double.Parse(exprParts[0].Replace('.', ','));
                }
                catch (Exception)
                {
                    throw new OperandIsNotNumber(exprParts[0]); //case 4
                }
                throw; //case 7
            }

            int rightOperand;
            try
            {
                rightOperand = int.Parse(exprParts[2]);
            }
            catch (Exception)
            {
                try
                {                    
                    Double.Parse(exprParts[2].Replace('.', ','));
                }
                catch (Exception)
                {
                    throw new OperandIsNotNumber(exprParts[2]); //case 4
                }
                throw; //case 7
            }

            switch (exprParts[1])
            {
                case "+":
                    Sum(leftOperand, rightOperand);
                    break;
                case "-":
                    Sub(leftOperand, rightOperand);
                    break;
                case "*":
                    Mul(leftOperand, rightOperand);
                    break;
                case "/":
                    Div(leftOperand, rightOperand);
                    break;
                default:
                    throw new OperatorIsWrong(exprParts[1]);  //case 2
            }

        }
        catch (OperatorIsMissing) //case 1
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Укажите в выражении оператор: +, -, *, /");
            Console.ResetColor();
            Console.Write("\n");
        }
        catch (OperatorIsWrong ex) //case 2
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Я пока не умею работать с оператором: {ex.Data["operator"]}");
            Console.ResetColor();
            Console.Write("\n");
        }
        catch (ExpressionIsWrong) //case 3
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Выражение некорректное, попробуйте написать в формате:\na + b\na * b\na - b\na / b");
            Console.ResetColor();
            Console.Write("\n");
        }
        catch (OperandIsNotNumber ex) //case 4
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Операнд {ex.operatorStr} не является числом");
            Console.ResetColor();
            Console.Write("\n");
        }
        catch (DivideByZeroException) //case 5
        {
            Console.BackgroundColor = ConsoleColor.Magenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Деление на ноль");
            Console.ResetColor();
            Console.Write("\n");
        }
        catch (BadLuckNumber) //case 6
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"Вы получили ответ 13!");
            Console.ResetColor();
            Console.Write("\n"); ;
        }
        catch (OverflowException) // case *
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Результат выражения вышел за границы int");
            Console.ResetColor();
            Console.Write("\n");
        }
        catch (Exception) //case 7
        {
            //Console.WriteLine("Я не смог обработать ошибку");
            throw new Exception("Я не смог обработать ошибку");
        }
    }

    
    static void Sum(int a, int b)
    {
        int result = checked(a + b);
        Console.WriteLine($"Ответ: {result}");
        if (result == 13)
        {
            throw new BadLuckNumber();
        }
    }
    
    static void Sub(int a, int b)
    {
        int result = checked(a - b);
        Console.WriteLine($"Ответ: {result}");
        if (result == 13)
        {
            throw new BadLuckNumber();
        }
    }

    static void Mul(int a, int b)
    {
        int result = checked(a * b);
        Console.WriteLine($"Ответ: {result}");
        if (result == 13)
        {
            throw new BadLuckNumber();
        }
    }

    static void Div(int a, int b)
    {
        int result = checked(a / b);
        Console.WriteLine($"Ответ: {result}");
        if (result == 13)
        {
            throw new BadLuckNumber();
        }
    }

    static string RemoveDupliсateWhiteSpace(string input)
    {
        StringBuilder output = new StringBuilder(input.Length);

        char lastChar = '*';
        for (int i = 0; i < input.Length; i++)
        {
            char thisChar = input[i];
            if (!(lastChar == ' ' && thisChar == ' '))
                output.Append(thisChar);

            lastChar = thisChar;
        }

        return output.ToString();
    }
}