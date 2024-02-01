using System.Reflection.Metadata;

namespace ConsoleRPG2
{
    public static class DiceRoller
    {
        private static readonly Random random = new Random();

        // Jet de dé classique, avec ndice, diceSize, un bonus à chaque roll, et un bonus au resultat final. Renvoie Succès ou Echec selon le resultat par rapport à DC.
        // Pas spécialement utile la tout de suite mdr
        public static string classicDiceRoll(int nDice, int diceSize, int rollBonus, int resultBonus, int DC)
        {
            int result = 0;
            for (int i = 0; i < nDice; i++)
            {
                result += random.Next(1, diceSize + 1);
            }
            if (result + (rollBonus * nDice) + resultBonus >= DC) return "Success";
            else return "Failure";
        }

        // Jet de dé classique où l'on recupère le résultat final.
        // Bien pour les dégats
        public static int DiceRoll(int nDice, int diceSize, int rollBonus, int resultBonus)
        {
            int result = 0;
            for (int i = 0; i < nDice; i++)
            {
                result += random.Next(1, diceSize + 1) + rollBonus;
            }
            return result + resultBonus;
        }

        // Jet de dé classique avec un D20, et la mécanique d'avantage et de désavatage.
        // Pour les jets d'attaques, tests de caractéristiques et autres. Super utile.
        public static string D20CheckDC(bool advantage, bool disadvantage, int rollBonus, int DC)
        {
            int result = 0;
            if ((advantage && disadvantage) || (!advantage && !disadvantage))
            {
                result += random.Next(1, 21);
            }
            else
            {
                int[] rolls = new int[2];
                for (int i = 0; i < 2; i++)
                {
                    rolls[i] = random.Next(1, 21);
                }
                if (advantage) result = Math.Max(rolls[0], rolls[1]);
                else result = Math.Min(rolls[0], rolls[1]);
            }
            if (result == 20) return "Critical Success";
            else if (result == 1) return "Critical Failure";
            if (result + rollBonus >= DC) return "Success";
            else return "Failure";
        }

        public static int statDiceRoll()
        {
            int[] rolls = new int[4];
            for (int i = 0; i < 4; i++)
            {
                rolls[i] = random.Next(1, 7);
            }
            triSelection(rolls);
            int sum = 0;
            for (int i = 1; i < 4; i++)
            {
                sum += rolls[i];
            }
            return sum;

        }

        public static void triSelection(int[] tab)
        {
            for (int i = 0; i < tab.Length - 1; i++)
            {
                int indexMin = i;
                for (int j = i + 1; j < tab.Length; j++)
                {
                    if (tab[j] < tab[indexMin])
                    {
                        indexMin = j;
                    }
                }
                int tempMin = tab[indexMin];
                tab[indexMin] = tab[i];
                tab[i] = tempMin;
            }
        }
    }
}