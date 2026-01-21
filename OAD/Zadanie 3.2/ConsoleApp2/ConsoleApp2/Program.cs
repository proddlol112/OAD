using System;
using System.Collections.Generic;

public class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // DANE
        var data = new QuestData(
             [ "Wieśniak", "Rycerz", "Czarodziej" ],
             [ "zgubił miecz", "potrzebuje ziół", "szuka mapy" ],
             [ "w lesie", "w jaskini", "na bagnach" ]
        );

        int difficulty = Input.ReadIntInRange("Podaj trudność (1-5): ", 1, 5);

        Console.Write("Tryb kroków: I = iteracja, R = rekurencja: ");
        string mode = (Console.ReadLine() ?? "").Trim().ToUpper();
        if (mode != "I" && mode != "R") mode = "I";

        var rng = new Random();

        // TODO (NA 5): stwórz obiekt questa (Quest) i uzupełnij pola.
        // TODO (NA 6): zrób to przez Factory (QuestFactory.CreateRandom)
        Quest quest = QuestFactory.CreateRandom(rng, data, difficulty);
        
        // TODO (NA 5): możesz zrobić if(mode) i generować kroki w Main.
        // TODO (NA 6): użyj Strategy (IStepsGenerator) wybranej przez Factory.
        IStepsGenerator stepsGenerator = StepsGeneratorFactory.Create(mode);

        // WYJŚCIE
        Console.WriteLine();
        Console.WriteLine($"QUEST: {quest.Npc} {quest.Goal} {quest.Place}.");
        Console.WriteLine("Kroki:");

        foreach (var step in stepsGenerator.GenerateSteps(quest))
            Console.WriteLine(step);

        Console.WriteLine($"Nagroda: {quest.RewardGold} złota");
    }
}

// ===== MODELE =====
public record Quest(string Npc, string Goal, string Place, int Difficulty)
{
    public int RewardGold => Difficulty * 100;
}

public record QuestData(string[] Npc, string[] Goals, string[] Places);

// ===== FACTORY (NA 6) =====
public static class QuestFactory
{
    public static Quest CreateRandom(Random rng, QuestData data, int difficulty)
    {
        // (Gotowe — uczniowie na 6 mają użyć tego zamiast losowania w Main)
        string npc = data.Npc[rng.Next(data.Npc.Length)];
        string goal = data.Goals[rng.Next(data.Goals.Length)];
        string place = data.Places[rng.Next(data.Places.Length)];
        return new Quest(npc, goal, place, difficulty);
    }
}

// ===== STRATEGY (NA 6) =====
public interface IStepsGenerator
{
    IEnumerable<string> GenerateSteps(Quest quest);
}

// Iteracyjna strategia
public class IterativeStepsGenerator : IStepsGenerator
{
    public IEnumerable<string> GenerateSteps(Quest quest)
    {
        for (int i = 1; i <= quest.Difficulty; i++)
            yield return $"  Krok {i}: {StepText(i, quest.Place)}";
    }

    private static string StepText(int stepNumber, string place)
        => stepNumber % 2 == 1 ? $"Idź {place} i rozejrzyj się."
                               : "Zrób akcję: szukaj / walcz / zbierz.";
}

// Rekurencyjna strategia
public class RecursiveStepsGenerator : IStepsGenerator
{
    public IEnumerable<string> GenerateSteps(Quest quest)
    {
        var list = new List<string>();
        Fill(list, 1, quest.Difficulty, quest.Place);
        return list;
    }

    private static void Fill(List<string> output, int current, int max, string place)
    {
        // TODO (NA 5/6): uczniowie mogą dostać to jako gotowe albo do uzupełnienia
        if (current > max) return;
        output.Add($"  Krok {current}: {StepText(current, place)}");
        Fill(output, current + 1, max, place);
    }

    private static string StepText(int stepNumber, string place)
        => stepNumber % 2 == 1 ? $"Idź {place} i rozejrzyj się."
                               : "Zrób akcję: szukaj / walcz / zbierz.";
}

// Factory do wyboru strategii
public static class StepsGeneratorFactory
{
    public static IStepsGenerator Create(string mode)
        => mode == "R" ? new RecursiveStepsGenerator()
                       : new IterativeStepsGenerator();
}

// ===== INPUT =====
public static class Input
{
    public static int ReadIntInRange(string prompt, int min, int max)
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