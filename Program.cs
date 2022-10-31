// See https://aka.ms/new-console-template for more information

    int countCurrent = 6; // размер массива
    string[,] arrayCurr = new string [6,2] {
    {"USD", "Доллар США"},
    {"EUR", "Евро"},
    {"CBP", "Фунт стерлинг Соединенного Королевства"},
    {"CHF", "Швейцарский франк"},
    {"JPY", "Японская иена"},
    {"RUB", "Российский рубль"}};
    
    // массив сумм
    decimal[,] arraySum = new decimal [6,2] {{0,0},{1,0},{2,0},{3,0},{4,0},{5,0}};

    Console.WriteLine("=== Конвертер валют ===");
    SelectListCurrent(countCurrent, arrayCurr);

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

void SelectListCurrent(int countCurr, string[,] arrCurr)
{
    for (int i = 0; i < countCurr; i++)
    {
        Console.WriteLine($"{arrCurr[i,0]} - {arrCurr[i,1]}");
    }
}
