Console.WriteLine("Hello!\r\nInput the first number:\r\n");
var firstNumber = int.Parse(Console.ReadLine());
Console.WriteLine("Input the second number:\r\n");
var secondNumber = int.Parse(Console.ReadLine());

Console.WriteLine("What do you want to do with those numbers?\r\n[A]dd\r\n[S]ubtract\r\n[M]ultiply\r\n");

var choice = Console.ReadLine();

if (CaseInsensitiveCheck(choice, "A"))
{
    int result = firstNumber + secondNumber;
    PrintResultMessage(firstNumber, secondNumber, result, "+");
}
else if (CaseInsensitiveCheck(choice, "S"))
{
    int result = firstNumber - secondNumber;
    PrintResultMessage(firstNumber, secondNumber, result, "+");
}
else if (CaseInsensitiveCheck(choice, "M"))
{
    int result = firstNumber * secondNumber;
    PrintResultMessage(firstNumber, secondNumber, result, "*");
}

void PrintResultMessage(int firstNumber, int secondNumber, int result, string @operator)
{
    Console.WriteLine($"{firstNumber} {@operator} {secondNumber} = {result}");
}

bool CaseInsensitiveCheck(string choise, string action)
{
    return choise.ToUpper() == action;
}

Console.WriteLine("Press any key to close");

Console.ReadKey();
