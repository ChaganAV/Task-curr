// See https://aka.ms/new-console-template for more information

    int countCurrent = 3; // размер массива
    string[,] arrayCurr = new string [3,2] {
    {"0", "USD Доллар США"},
    {"1", "EUR Евро"},
    {"2", "RUB Российский рубль"}};
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
    switch(curr)
    {
        case "USD":
            arraySum[0,0] = arrayRate[0,0] * sumCurr;
            break;
        case "EUR":
            arraySum[1,0] = arrayRate[1,0] * sumCurr;
            break;
        case "RUB":
            arraySum[2,0] = arrayRate[2,0] * sumCurr;
            break;

    }
}

void SumBalance(string val)
{

}

void PrintBalance()
{
    Console.WriteLine($"Ваш баланс на {DateTime.Now.Date}");
    for (int i = 0; i < countCurrent; i++)
    {
        Console.WriteLine($"{arrayCurr[i,1]} - {arraySum[i,1]}");
    }
}


