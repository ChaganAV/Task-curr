// See https://aka.ms/new-console-template for more information

    int countCurrent = 6; // размер массива
    string[,] arrayCurr = new string [3,2] {
    {"USD", "Доллар США"},
    {"EUR", "Евро"},
    {"RUB", "Российский рубль"}};
    
    // массив сумм
    decimal[,] arraySum = new decimal [3,2] {{0,61.3589M},{1,61.5718M},{2,1M}};

    Console.WriteLine("=== Конвертер валют ===");
    SelectListCurrent();

    string curr = ReadString("Введите валюту из предложенного списка");
    decimal sumCurr = Convert.ToDecimal(ReadString("И баланс валюты"));


// Функции
string ReadString(string message)
{
    Console.WriteLine(message);
    Console.Write(">> ");
    string? inputLine = Console.ReadLine();
    return inputLine ?? "no";
}

void SelectListCurrent()
{
    for (int i = 0; i < countCurrent; i++)
    {
        Console.WriteLine($"{arrayCurr[i,0]} - {arrayCurr[i,1]}");
    }
}

void PrintCurrent()
{
    Console.WriteLine("Курсы валют");
    for (int i = 0; i < countCurrent; i++)
    {
        
    }
}
