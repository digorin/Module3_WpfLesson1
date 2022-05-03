using Microsoft.VisualBasic.FileIO;
using System;
using System.Numerics;
using System.Text;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());
            Thread thread1 = new Thread(new ParameterizedThreadStart(Factoreal));
            thread1.Name = "Расчет факториала";
            thread1.Start(N);

            Thread thread2 = new Thread(new ParameterizedThreadStart(CelieChisla));
            thread2.Name = "Расчет целых чисел";
            thread2.Start(N);

            Thread thread3 = new Thread(new ParameterizedThreadStart(ParceCsv));
            thread3.Name = "Парсим csv";
            thread3.Start($@"{Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)}\123.csv");

            do
            {
                Console.Write("*");
                Thread.Sleep(1500);
            }
            while (thread1.IsAlive | thread2.IsAlive | thread3.IsAlive);


        }

        static void Factoreal(object N)
        {
            var factorial = new BigInteger(1);
            for (int i = 1; i <= (int)N; i++)
                factorial *= i;

            Console.WriteLine($"Результат расчета фактореала от числа N: {factorial}.");
        }

        static void CelieChisla(object N)
        {
            int result = 0;

            for (int i = 1; i <= (int)N; i++)
            {
                if (i % 1 == 0)
                    result += i;
            }

            Console.WriteLine($"Результат суммы целых чисел до N: {result}.");
        }

        static void ParceCsv(object path)
        {
            string result = "";
            string csv = File.ReadAllText((string)path);
            int countlines = 0;
            using (TextFieldParser parser = new TextFieldParser(new MemoryStream(Encoding.UTF8.GetBytes(csv))))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool isFirstRow = true;
                IList<string> headers = new List<string>();

                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (isFirstRow)
                    {
                        isFirstRow = false;
                        headers = fields;
                    }
                    else
                    {
                        foreach (string field in fields)
                            result += field;
                    }
                    countlines++;
                    if (countlines % 1000 == 0)
                        Console.WriteLine($"Парсинг на строке {countlines}");
                }
            }
            string savepath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            File.WriteAllText($@"{savepath}\123.txt", result);
            Console.WriteLine($@"CSV спарсен и сохранен в txt по пути: {savepath}\123.txt");
        }
    }
}
