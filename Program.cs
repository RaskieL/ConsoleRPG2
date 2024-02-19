using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace ConsoleRPG2
{
    public class Program
    {
        public static Player player = new Player("Unknown");
        public static int[]? playersChunk;
        public static Enemy[]? enemies;
        public void Run()
        {

            StateMachine.addState("main_menu");
            while (true)
            {
                object currentState = StateMachine.getCurrentState();

                switch (currentState)
                {
                    case "generate_map":
                        do
                        {
                            DrawMap.generateMap();
                            Console.WriteLine("Lecture de la carte...");
                            DrawMap.ReadMap();
                        } while (!DrawMap.isMapOk());

                        DrawMap.UpdateMapPlayerPos(player);
                        enemies = Enemy.InitializeEnemies(10);
                        StateMachine.removeLastState();
                        break;

                    case "main_menu":
                        string nextState = Main_menu.mainMenu();
                        if(nextState != "main_menu"){
                            StateMachine.addState(nextState);
                        }
                        if (StateMachine.getCurrentState().Equals("character_creation"))
                        {
                            StateMachine.addState("generate_map");
                        }
                        break;

                    case "load_menu":
                        Main_menu.loadMenu();
                        StateMachine.removeLastState();
                        break;
                    
                    case "settings_menu":
                        Main_menu.settingsMenu();
                        StateMachine.removeLastState();
                        break;
                    
                    case "game_exit":
                        Main_menu.exitMenu();
                        StateMachine.removeLastState();
                        break;

                    case "character_creation":
                        try
                        {
                            player = Character_creator.characterCreator()!;
                            Character_creator.playerStatAssignationScreen(player);
                            player.UpdateAll();
                            StateMachine.updateCurrentState("play_state");
                        }
                        catch (Exception)
                        {
                            displayError($"Une erreur est survenue lors de la création du personnage. Assurez-vous d'entrer un nom correct");
                        }
                        break;

                    case "play_state":
                        playersChunk = player.getPlayerCurrentChunk();
                        DrawMap.DrawChunk(playersChunk[0], playersChunk[1]);
                        player.PlayerAction();
                        break;

                    case "game_menu":
                        player.DisplayCharacterSheet();
                        Console.ReadLine();
                        break;

                    case Combat:
                        Combat? combat = StateMachine.getCurrentState() as Combat;
                        List<object> initiativeOrder = combat!.getInitiativeOrder();
                        playersChunk = player.getPlayerCurrentChunk();
                        combat!.displayInitiativeOrder();
                        for(int i = initiativeOrder.Count()-1; i >=0; i--){
                            if(StateMachine.getCurrentState() is not Combat){
                                break;
                            }
                            if(initiativeOrder[i] is Player){
                                player.initMoveMarker();
                                player.PlayerCombatAction();
                            }else{
                                DrawMap.DrawChunk(playersChunk[0], playersChunk[1]);
                                Enemy? enemy = initiativeOrder[i] as Enemy;
                                Console.WriteLine($"Tour de l'ennemi {enemy!.getName()}");
                            }
                        }
                        break;

                    default:
                        displayError($"Erreur : StateMachine\n CurrentState=\"{currentState}\"");
                        break;
                }
            }
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Run();
        }
        public static void displayError(string errormessage)
        {
            Console.Clear();
            Console.WriteLine(errormessage);
            Console.WriteLine("\nAppuyez sur Entrer pour continuer");
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}