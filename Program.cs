// See https://aka.ms/new-console-template for more information

    int countCurrent = 3; // размер массива
    string[,] arrayCurr = new string [3,2] {
    {"USD", "Доллар США"},
    {"EUR", "Евро"},
    {"RUB", "Российский рубль"}};
    string inputString = String.Empty;
    
    // массивы-хранилица сумм
    decimal[,] arrayRate = new decimal [3,2] {{0,61.3589M},{1,61.5718M},{2,1M}};
    decimal[,] arraySum = new decimal [3,2] {{0,0},{1,0},{2,0}};

    Console.WriteLine("=== Конвертер валют ===");
    PrintComands();
    
    while(inputString != "q")
    {
        inputString = ReadString("Введите команду");
        SelectComand(inputString);
    }


// Функции
void SelectComand(string comand)
{
    switch(comand)
    {
        case "rate":
            PrintCurrent();
            break;
        case "balance":
            PrintBalance();
            break;
        case "insert":
            InsertBalance();
            break;
        case "conv":
            ConverCurr();
            break;
        case "help":
            PrintComands();
            break;
        case "q":
            break;
        default:
            Console.WriteLine("Нет такой команды");
            break;
    }
}

string ReadString(string message)
{
    Console.WriteLine(message);
    Console.Write(">> ");
    string? inputLine = Console.ReadLine();
    return inputLine ?? "no";
}

void PrintComands()
{
    Console.WriteLine("rate - курсы валют");
    Console.WriteLine("insert - внести баланс");
    Console.WriteLine("balance - печать баланса");
    Console.WriteLine("conv - конвертировать одну валюту в другую");
    Console.WriteLine("help - справка по командам");
    Console.WriteLine("q - выход");
}

void PrintCurrent()
{
    Console.WriteLine("Курсы валют");
    for (int i = 0; i < countCurrent; i++)
    {
        Console.WriteLine($"{arrayCurr[i,0]} {arrayCurr[i,1]} - {arrayRate[i,1]}");
    }
}

void InsertBalance()
{
    string curr = ReadString("Введите код валюты");
    decimal sumCurr = 0;
    if (!Decimal.TryParse(ReadString("И баланс валюты"),out sumCurr))
    {
           Decimal.TryParse(ReadString("Введите число"),out sumCurr);
    }
    SumBalance(curr, sumCurr);
}

void SumBalance(string curr, decimal bal)
{
    for (int i = 0; i < arrayCurr.GetLength(0); i++)
    {
        if (arrayCurr[i,0] == curr)
        {
            arraySum[i,1] = bal;
        }
    }
}

void ConverCurr()
{
    string curr1 = ReadString("Введите первую валюту");
    string curr2 = ReadString("Введите вторую валюту");
    decimal result = 0;
    for(int i = 0; i < arrayCurr.GetLength(0); i++)
    {
        if (arrayCurr[i,0] == curr1)
        {
            for (int j = 0; j < arrayCurr.GetLength(0); j++)
            {
                if (arrayCurr[j,0] == curr2)
                {
                    result = arraySum[i,1]/arrayRate[i,1]*arrayRate[j,1];
                    Console.WriteLine($"{arraySum[i,1]} {arrayRate[i,0]} = {result} {arrayRate[j,0]}");
                }
            }
        }
    }
}
void PrintBalance()
{
    Console.WriteLine($"Ваш баланс на {DateTime.Now.Date}");
    for (int i = 0; i < countCurrent; i++)
    {
        Console.WriteLine($"{arrayCurr[i,1]} - {arraySum[i,1]}");
    }
}


