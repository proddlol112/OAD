using System;

class Program
{
    // === DANE (NIE ZMIENIAĆ) ===
    static readonly string[] NPC = { "Wieśniak", "Rycerz", "Czarodziej" };
    static readonly string[] CEL = { "zgubił miecz", "potrzebuje ziół", "szuka mapy" };
    static readonly string[] MIEJSCE = { "w lesie", "w jaskini", "na bagnach" };

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        int difficulty = ReadIntInRange("Podaj trudność (1-5): ", 1, 5);

        // Na 4: wybór trybu w programie. Na 2/3 możesz wpisać na sztywno "I" albo "R".
        Console.Write("Tryb kroków: I = iteracja, R = rekurencja: ");
        string mode = (Console.ReadLine() ?? "").Trim().ToUpper();
        if (mode != "I" && mode != "R") mode = "I";

        Random rng = new Random();
        string npc = Pick(rng, NPC);
        string cel = Pick(rng, CEL);
        string miejsce = Pick(rng, MIEJSCE);

        // === WYJŚCIE (NIE ZMIENIAĆ) ===
        Console.WriteLine();
        Console.WriteLine($"QUEST: {npc} {cel} {miejsce}.");
        Console.WriteLine("Kroki:");

        // === TODO: UZUPEŁNIJ GENEROWANIE KROKÓW ===
        if (mode == "I")
        {
            // TODO (NA 2): wygeneruj kroki ITERACYJNIE (for/while) i wypisz je.
            // Wymagany format: Console.WriteLine($"  Krok {i}: ...");
            PrintStepsIterative(difficulty, miejsce);
        }
        else
        {
            // TODO (NA 3): wygeneruj kroki REKURENCYJNIE (bez pętli do kroków).
            PrintStepsRecursive(current: 1, max: difficulty, miejsce: miejsce);
        }

        int reward = difficulty * 100;
        Console.WriteLine($"Nagroda: {reward} złota");
    }

    // === ZASADA KROKÓW (NIE ZMIENIAĆ) ===
    static string BuildStepText(int stepNumber, string miejsce)
    {
        if (stepNumber % 2 == 1) return $"Idź {miejsce} i rozejrzyj się.";
        return "Zrób akcję: szukaj / walcz / zbierz.";
    }

    // ===== TODO FUNKCJE DO ZROBIENIA PRZEZ UCZNIA =====

    static void PrintStepsIterative(int difficulty, string miejsce)
    {
        for (int i = 1; i <= difficulty; i++)
        {
            Console.WriteLine($" Krok {i}: {BuildStepText(i, miejsce)}");
        }
        // TODO (NA 2): pętla od 1 do difficulty
        // i wypisz:
        // Console.WriteLine($"  Krok {i}: {BuildStepText(i, miejsce)}");
    }

    static void PrintStepsRecursive(int current, int max, string miejsce)
    {
        if (current > max) 
            return;
        
        Console.WriteLine($"  Krok {current}: {BuildStepText(current, miejsce)}");
        PrintStepsRecursive(current + 1, max, miejsce);
        // TODO (NA 3): rekurencja
        // Warunek stopu: jeśli current > max to return;
        // Wypisz krok current, potem wywołaj funkcję dla current+1.
    }

    // ===== GOTOWE NARZĘDZIA (NIE ZMIENIAĆ) =====

    static string Pick(Random rng, string[] arr) => arr[rng.Next(arr.Length)];

    static int ReadIntInRange(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= min && value <= max)
                return value;

            Console.WriteLine($"Błąd: wpisz liczbę od {min} do {max}.");
        }
    }
}
