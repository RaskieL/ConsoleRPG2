using System.Runtime.InteropServices;

namespace ConsoleRPG2
{
    public class Program{
        Player player = new Player("Unknown");
        public void Run(){
            StateMachine.addState("main_menu");
            
            while (true){
                string currentState = StateMachine.getCurrentState();

                switch (currentState){

                    case "main_menu":
                        StateMachine.updateCurrentState(Main_menu.mainMenu());
                        break;

                    case "character_creation":
                        try{
                            player = Character_creator.characterCreator()!;
                            Character_creator.playerStatAssignationScreen(player);
                            player.updateAll();
                            StateMachine.updateCurrentState("game_menu");
                        }
                        catch (Exception){
                            displayError($"Une erreur est survenue lors de la création du personnage. Assurez-vous d'entrer un nom correct");
                        }
                        break;

                    case "game_menu":
                        player.displayCharacterSheet();
                        Console.ReadLine();
                        break;

                    default:
                        displayError($"Erreur : StateMachine\n CurrentState=\"{currentState}\"");
                        break;
                }
            }
        }

        public static void Main(string[] args){
            Program program = new Program();
            DrawMap.generateMap();
            DrawMap.ReadMap();
            DrawMap.DisplayMap();
            Console.ReadLine();
            program.Run();
        }
        public static void displayError(string errormessage){
            Console.Clear();
            Console.WriteLine(errormessage);
            Console.WriteLine("\nAppuyez sur Entrer pour continuer");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}