using System.Runtime.InteropServices;
using System.Security.Claims;

namespace ConsoleRPG2
{
    public class Program{
        Player player = new Player("Unknown");
        
        public void Run(){
            
            StateMachine.addState("main_menu");
            while (true){
                string currentState = StateMachine.getCurrentState();

                switch (currentState){

                    case "generate_map":
                    DrawMap.generateMap();
                    DrawMap.ReadMap();
                    DrawMap.DisplayMap();
                    //player.setRandomPlayerPos();
                    StateMachine.removeLastState();
                    break;

                    case "main_menu":
                        StateMachine.updateCurrentState(Main_menu.mainMenu());
                        if(StateMachine.getCurrentState().Equals("character_creation")){
                            StateMachine.addState("generate_map");
                        }
                        break;

                    case "character_creation":
                        try{
                            player = Character_creator.characterCreator()!;
                            Character_creator.playerStatAssignationScreen(player);
                            player.updateAll();
                            StateMachine.updateCurrentState("player_action");
                        }
                        catch (Exception){
                            displayError($"Une erreur est survenue lors de la création du personnage. Assurez-vous d'entrer un nom correct");
                        }
                        break;

                    case "player_action":
                    player.movePlayer();
                    DrawMap.UpdateMapPlayerPos(player);
                    DrawMap.DisplayMap();
                    Console.WriteLine($"XPOS: {player.getPlayerXPos()} YPOS: {player.getPlayerYPos(
                    )}");
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