using System;
using System.IO;

class Program
{
    public static int Main(string[] args)
    {
        int detect = 0;
        string? cd = "0";
        string check = "-cd";
        if (args.Any(check.Contains) && args.Length >= 2)
        {
            foreach (string arg in args)
            {
                if (detect == 1)
                {
                    cd = arg;
                    break;
                }
                if (arg == "-cd")
                {
                    detect = 1;
                }
            }
        }
        else
        {
            Console.Write("Введите путь к txt файлу: ");
            cd = Console.ReadLine();
        }
        if (!cd.EndsWith(".txt") || !File.Exists(cd))
        {
            Console.WriteLine("Заданного файла не существует или он не является текстовым файлом!");
            return 1;
        }
        int i = 1;
        string num = "";
        string[] lines = File.ReadAllLines(cd);

        Console.WriteLine("Текстовой документ по пути " + cd);
        string? read = "0";
        int red = 2;
        while (read != "N" && read != "n")
        {
            if (red == 1)
            {
                Console.WriteLine("Текстовой документ теперь выглядит так:");
            }
            if (red == 2 || red == 1)
            {
                Console.WriteLine("__________________________________________");
                foreach (string line in lines)
                {
                    if (i >= 1 && i <= 9)
                    {
                        num = i.ToString() + "    ";
                    }
                    else if (i >= 10 && i <= 99)
                    {
                        num = i.ToString() + "   ";
                    }
                    else if (i >= 100 && i <= 999)
                    {
                        num = i.ToString() + "  ";
                    }
                    else if (i >= 1000 && i <= 9999)
                    {
                        num = i.ToString() + " ";
                    }
                    Console.WriteLine(num + line);
                    i++;
                }
                Console.WriteLine("__________________________________________");
                red = 0;
            }

            Console.Write("Введите строку которую хотите отредактировать, либо 'N' чтобы сохранить и выйти: ");
            read = Console.ReadLine();
            if(int.TryParse(read, out var parsedNumber))
            {
                if(parsedNumber < i && parsedNumber > 0)
                {
                    Console.Write("Введите новый текст для строчки: ");
                    string? newtext = Console.ReadLine();
                    lines[parsedNumber - 1] = newtext;
                    red = 1;
                    i = 1;
                }
            }
        }
        File.WriteAllLines(cd, lines);
        return 0;
    }
}



