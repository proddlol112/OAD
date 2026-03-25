using System;
using ConsoleApp1.Domain.Entity;

class Program
{
    static void Main()
    {
        Gracz[] gracze = {
            new Gracz { Imie = "Kuba", Punkty = 12 },
            new Gracz { Imie = "Ola", Punkty = 25 },
            new Gracz { Imie = "Bartek", Punkty = 8 },
            new Gracz { Imie = "Ania", Punkty = 19 },
            new Gracz { Imie = "Mati", Punkty = 30 }
        };

        int porownania = 0;
        int zamiany = 0;

        Console.WriteLine("PRZED SORTOWANIEM:");
        WypiszRanking(gracze);

        for (int i = 0; i < gracze.Length - 1; i++)
        {
            for (int j = 0; j < gracze.Length - 1 - i; j++)
            {
                porownania++;

                if (gracze[j].Punkty < gracze[j + 1].Punkty)
                {
                    (gracze[j], gracze[j + 1]) = (gracze[j + 1], gracze[j]);

                    zamiany++;
                }
            }

            Console.WriteLine($"\nPo przebiegu {i + 1}:");
            WypiszRanking(gracze);
        }

        Console.WriteLine("\nPO SORTOWANIU:");
        WypiszRanking(gracze);

        Console.WriteLine("\nTOP 3:");
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"{i + 1}. {gracze[i].Imie} - {gracze[i].Punkty} pkt");
        }

        Console.WriteLine($"\nLiczba porównań: {porownania}");
        Console.WriteLine($"Liczba zamian: {zamiany}");
    }

    static void WypiszRanking(Gracz[] gracze)
    {
        for (int i = 0; i < gracze.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {gracze[i].Imie} - {gracze[i].Punkty} pkt");
        }
    }
}