using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleRPG2
{
    public class UI
    {

    }

    public class Main_menu : UI
    {
        public static string mainMenu()
        {
            Console.Clear();
            Console.WriteLine("Bienvenue dans ConsoleRPG 2!\n");
            Console.WriteLine("[1] - Jouer");
            Console.WriteLine("[2] - Charger une partie");
            Console.WriteLine("[3] - Paramètres");
            Console.WriteLine("[4] - Quitter le jeu\n");

            Console.WriteLine("Entrez l'option choisie:");
            try
            {
                string userinput = Console.ReadLine()!;
                return userinput switch
                {
                    "1" => "character_creation",
                    "2" => "load_menu",
                    "3" => "settings_menu",
                    "4" => "game_exit",
                    _ => "main_menu",
                };
            }
            catch (Exception)
            {
                Program.displayError($"Une erreur est survenue lors de l'affichage du menu principal.");
            }
            return "main_menu";
        }

        public static void loadMenu()
        {
            Console.Clear();
            Console.WriteLine("Cette fonctionalité n'est pas encore disponbile");
            Console.ReadLine();
        }

        public static void settingsMenu()
        {
            Console.Clear();
            Console.WriteLine("Cette fonctionalité n'est pas encore disponbile");
            Console.ReadLine();
        }

        public static void exitMenu()
        {
            Console.Clear();
            Console.WriteLine("Êtes vous sûr de vouloir quitter le jeu ? (O/N)");
            switch (Console.ReadLine()!.ToLower())
            {
                case "o":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case "oui":
                    Console.Clear();
                    Environment.Exit(0);
                    break;
                case "n":
                    break;
                case "non":
                    break;
                default:
                    exitMenu();
                    break;
            }
        }
    }

    public class Character_creator : UI
    {
        // Ecran de la création de personnage.
        public static Player? characterCreator()
        {
            Console.Clear();
            Console.WriteLine("Quel est ton nom ?");
            try
            {
                string playerName = Console.ReadLine()!;
                Player player = new Player(playerName);
                return player;
            }
            catch (Exception)
            {
                Console.WriteLine("Entrez un nom valide.");
                Console.WriteLine("Appuyez sur entrer pour continuer.");
                Console.ReadLine();
                return null;
            }
        }

        public static void playerStatAssignationScreen(Player player)
        {
            List<int> rolls = new List<int> { DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll() };

            while (rolls.Count != 0)
            {
                Console.Clear();
                Console.WriteLine("Vous devez à présent assigner vos valeurs de caractéristiques. Voici les valeurs tirées :");
                for (int i = 0; i < rolls.Count(); i++)
                {
                    if (i != rolls.Count() - 1)
                        Console.Write($"{rolls[i]}, ");
                    else Console.Write($"{rolls[i]}");
                }
                Console.WriteLine($"\n\nA quelle caractéristique voulez-vous assigner la première valeur dans la liste ({rolls[0]}) ?");
                Console.WriteLine($"[1] - Force ({player.getStrength()})");
                Console.WriteLine($"[2] - Dextérité ({player.getDexterity()})");
                Console.WriteLine($"[3] - Constitution ({player.getConstitution()})");
                Console.WriteLine($"[4] - Sagesse ({player.getWisdom()})");
                Console.WriteLine($"[5] - Intelligence ({player.getIntelligence()})");
                Console.WriteLine($"[6] - Charisme ({player.GetCharisma()})");
                Console.WriteLine($"[7] - Tout assigner aléatoirement");
                Console.WriteLine($"[8] - Reroll");
                Console.WriteLine("\nVotre choix:");
                switch (Console.ReadLine())
                {
                    case "1":
                        if (player.getStrength() == 0)
                        {
                            player.setStrength(rolls[0]);
                            rolls.RemoveAt(0);
                        }
                        else
                        {
                            int temp = player.getStrength();
                            player.setStrength(rolls[0]);
                            rolls[0] = temp;
                        }
                        break;
                    case "2":
                        if (player.getDexterity() == 0)
                        {
                            player.setDexterity(rolls[0]);
                            rolls.RemoveAt(0);
                        }
                        else
                        {
                            int temp = player.getDexterity();
                            player.setDexterity(rolls[0]);
                            rolls[0] = temp;
                        }
                        break;
                    case "3":
                        if (player.getConstitution() == 0)
                        {
                            player.setConstitution(rolls[0]);
                            rolls.RemoveAt(0);
                        }
                        else
                        {
                            int temp = player.getConstitution();
                            player.setConstitution(rolls[0]);
                            rolls[0] = temp;
                        }
                        break;
                    case "4":
                        if (player.getWisdom() == 0)
                        {
                            player.setWisdom(rolls[0]);
                            rolls.RemoveAt(0);
                        }
                        else
                        {
                            int temp = player.getWisdom();
                            player.setWisdom(rolls[0]);
                            rolls[0] = temp;
                        }
                        break;
                    case "5":
                        if (player.getIntelligence() == 0)
                        {
                            player.setIntelligence(rolls[0]);
                            rolls.RemoveAt(0);
                        }
                        else
                        {
                            int temp = player.getIntelligence();
                            player.setIntelligence(rolls[0]);
                            rolls[0] = temp;
                        }
                        break;
                    case "6":
                        if (player.GetCharisma() == 0)
                        {
                            player.setCharisma(rolls[0]);
                            rolls.RemoveAt(0);
                        }
                        else
                        {
                            int temp = player.GetCharisma();
                            player.setCharisma(rolls[0]);
                            rolls[0] = temp;
                        }
                        break;
                    case "7":
                        player.setStats(rolls[0], rolls[1], rolls[2], rolls[3], rolls[4], rolls[5]);
                        for (int i = 0; i < 6; i++)
                        {
                            rolls.RemoveAt(0);
                        }
                        break;
                    case "8":
                        rolls = new List<int> { DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll(), DiceRoller.statDiceRoll() };
                        player.setStats(0, 0, 0, 0, 0, 0);
                        break;

                    default:
                        continue;
                }
            }
        }
    }

    public class PlayerActionMenu : UI
    {
        private static List<string> MenuStates = new List<string>() { "action_menu" };

        public static void ActionMenu(int input)
        {
            if (input == 0 && getCurrentState() != "action_menu")
            {
                removeLastState();
            }
            else if(input == 0 && getCurrentState() == "action_menu")
            {
                Console.Clear();
                Console.WriteLine("Êtes vous sûr de vouloir revenir au menu principal ? (O/N)");
                string ans = Console.ReadLine()!.ToLower();
                if(ans == "o" || ans == "oui"){
                    StateMachine.removeLastState();
                }
            }

            switch (getCurrentState())
            {
                case "action_menu":
                    {

                        switch (input)
                        {
                            case 1:
                                Console.WriteLine("1 Pressed !");
                                break;
                            case 2:
                                Console.WriteLine("2 Pressed !");
                                break;
                            case 3:
                                Console.WriteLine("3 Pressed !");
                                break;
                            case 4:
                                Console.WriteLine("4 Pressed !");
                                break;
                            case 5:
                                Console.WriteLine("5 Pressed !");
                                break;
                            case 6:
                                Console.WriteLine("6 Pressed !");
                                break;
                            case 7:
                                Console.WriteLine("7 Pressed !");
                                break;
                            case 8:
                                Console.WriteLine("8 Pressed !");
                                break;
                            case 9:
                                Console.WriteLine("9 Pressed !");
                                break;
                        }
                        break;
                    }
            }
        }

        public static void DisplayActionMenu(){
            switch(getCurrentState()){
                case "action_menu":
                    Console.WriteLine("[0] - Exit to Main Menu");
                    break;
            }
        }

        public static void removeLastState()
        {
            MenuStates.RemoveAt(0);
        }

        // Ajoute à l'index 0 un nouvel état
        public static void addState(string state)
        {
            MenuStates.Insert(0, state);
        }

        // Renvoie l'état courant
        public static string getCurrentState()
        {
            return MenuStates.First();
        }

        // Renvoie l'état à l'index voulu
        public static string getState(int index)
        {
            return MenuStates.ElementAt(index);
        }

        // Permet d'assigner l'état à un index à un autre état.
        public static void setState(int index, string state)
        {
            MenuStates[0] = state;
        }

        // Remplace l'état courant par un autre.
        public static void updateCurrentState(string state)
        {
            removeLastState();
            addState(state);
        }
    }
}
