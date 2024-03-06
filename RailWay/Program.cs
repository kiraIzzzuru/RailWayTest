using RailWay;


ComandManager comandManager = ComandManager.GetInstance();
while (true)
{
    Console.WriteLine("Если необходимо вывести в виде списка доступные парки и список вершин, описывающих парк введите 1. " +
    "Если необходимо вывести в виде списка все участки схемы станции введите 2. \r\n" +
    "Если необходимо вывести в виде списка участки станции, " +
    "входящие в кратчайший путь между указанными участками, введите команду 3 и " +
    "затем номер начальной точки и номер конечной точки.  Например,3 0 5. ");
    string? name = Console.ReadLine();

    comandManager.Run(name);

    Console.WriteLine("Нажмите Enter для продолжения или 'q' для выхода.");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.Q)
        break; // Выход из цикла, если пользователь ввел 'q'
}
