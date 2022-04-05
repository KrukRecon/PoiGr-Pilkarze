using System.Collections.Generic;

namespace Lab_02_4
{
    internal static class ExtensionMethods
    {
        public static int ToInt(this string item)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                return 0;
            }

            int.TryParse(item, out var intItem);
            return intItem;
        }

        public static string CollectionToString(this IEnumerable<Piłkarz> pilkarze)
        {
            var stringifiedPilkarze = new List<string>();
            foreach (var pilakrz in pilkarze)
            {
                stringifiedPilkarze.Add($"{pilakrz.Nazwisko},{pilakrz.Imię},{pilakrz.Waga},{pilakrz.Wzrost},{pilakrz.Pozycja}");
            }

            return string.Join("$", stringifiedPilkarze);
        }

        public static List<Piłkarz> StringToCollection(this string decryptedData)
        {
            var pilkarze = new List<Piłkarz>();

            if (string.IsNullOrWhiteSpace(decryptedData))
            {
                return pilkarze;
            }

            var collectionOfStrings = decryptedData.Split('$');

            foreach (var str in collectionOfStrings)
            {
                var pilkarz = str.Split(',');

                pilkarze.Add(new Piłkarz
                {
                    Nazwisko = pilkarz[0],
                    Imię = pilkarz[1],
                    Waga = pilkarz[2].ToInt(),
                    Wzrost = pilkarz[3].ToInt(),
                    Pozycja = (Pozycja)pilkarz[4].PozycjaMapper()
                });
            }

            return pilkarze;
        }

        private static int PozycjaMapper(this string pozycja)
        {
            if (string.IsNullOrWhiteSpace(pozycja) || pozycja.Equals("-1"))
            {
                return -1;
            }

            switch (pozycja)
            {
                case "Bramkarz":
                    return 0;
                case "Obrońca":
                    return 1;
                case "Pomocnik":
                    return 2;
                case "Napastnik":
                    return 3;
                default:
                    return -1;
            }
        }
    }
}
