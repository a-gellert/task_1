﻿using System;
using System.IO;

namespace XY_ParserConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            int check = 0;
            int input;

            String inputStr;
            String defaultInput = "23.8976,12.3218 25.76,11.9463 24.8293,12.2";

            char[] delimiterChars = { ' ', ',' };

            Console.WriteLine("Выберите действие:\n" +
                "1. Ввести данные вручную;\n" +
                "2. Прочитать данные из файла\n" +
                "3. Использовать значения по умолчанию.\n");

            do
            {
                check = 0;
                inputStr = Console.ReadLine();

                if (Int32.TryParse(inputStr, out input))
                {
                    switch (input)
                    {
                        case 1:
                            Console.WriteLine("Введите данные:");
                            String str = Console.ReadLine();
                            Parsing(str);
                            break;
                        case 2:
                            Parsing(defaultInput);
                            break;
                        case 3:
                            ReadFrom();
                            break;
                        default:
                            check = 1;
                            Console.WriteLine("Вы ввели неверное значение, попробуйте снова.");
                            continue;
                    }
                }
                else
                {
                    check = 1;
                    Console.WriteLine("Вы ввели неверное значение, попробуйте снова.");
                }
            }
            while (check == 1);

            Console.ReadKey();



            void Parsing(String str)
            {
                string[] coordinates = str.Split(delimiterChars);

                for (int i = 0; i < coordinates.Length; i++)
                {
                    coordinates[i] = coordinates[i].Replace('.', ',');
                }

                for (int i = 0; i < coordinates.Length; i++)
                {
                    if ((i % 2) != 1)
                    {
                        Console.Write($"\nX:{coordinates[i]}; ");
                    }
                    else
                    {
                        Console.WriteLine($"Y:{coordinates[i]}");
                    }
                }
            }


            void ReadFrom()
            {
                String path = "coord.txt";
                String str;
                {
                    using (StreamReader sr = new StreamReader(path))
                    {
                        str = sr.ReadToEnd();
                        Parsing(str);
                    }

                }
            }
        }
    }
}
    
