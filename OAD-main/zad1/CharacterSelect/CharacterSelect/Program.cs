using CharacterSelect.Application.Factory;
using CharacterSelect.Domain.Enum;

namespace CharacterSelect
{
    public static class Program
    {
        public static void Main()
        {
            Console.Title = "Character Select";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== WYBÓR POSTACI ===");
                Console.WriteLine("1) Wojownik");
                Console.WriteLine("2) Mag");
                Console.WriteLine("3) Łotrzyk");
                Console.WriteLine("4) Luntik");
                Console.WriteLine("5) Artem");
                Console.WriteLine("6) Kolia");
                Console.WriteLine("0) Wyjście");
                Console.Write("Wybierz klasę [0-6]: ");

                var input = Console.ReadLine();
                if (input == "0") break;

                if (!int.TryParse(input, out var choice) || choice < 1 || choice > 6)
                {
                    Pause("Niepoprawny wybór. Naciśnij Enter…");
                    continue;
                }

                var cls = (CharacterClass)choice;

                Console.Write("Podaj imię postaci (Enter = domyślne): ");
                var name = Console.ReadLine();

                var character = CharacterFactory.Create(cls, name);

                Console.Clear();
                Console.WriteLine(">>> Utworzono postać!");
                character.Describe();

                // Console.WriteLine("\nAkcja: atak");
                // character.Attack();
                //
                // Console.WriteLine("Akcja: umiejętność specjalna");
                // character.UseSpecial();

                Console.WriteLine("\nChcesz utworzyć kolejną postać? (t/n): ");
                var again = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
                if (again != "t" && again != "tak") break;
            }

            Console.WriteLine("\nDzięki za grę! Do zobaczenia 👋");
        }

        private static void Pause(string msg)
        {
            Console.WriteLine(msg);
            Console.ReadLine();
        }
    }
}