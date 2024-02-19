using ConsoleRPG2;

namespace ConsoleRPG2
{
    public class Events{

    }

    public class Combat{
        private Player player;
        private List<Enemy> enemyList = new List<Enemy>();
        private List<Object> InitiativeOrder = new List<object>();

        public Combat(Player player, List<Enemy> listEnemies){
            this.player = player;
            this.enemyList = listEnemies;
            this.InitiativeOrder = this.rollInitiative();
        }

        public List<Object> rollInitiative(){
            Dictionary<Object,int> InitiativeRolls = new Dictionary<object, int>();
            foreach(Enemy enemy in enemyList){
                InitiativeRolls.TryAdd(enemy, DiceRoller.DiceRoll(1, 20, 0, 0));
            }
            InitiativeRolls.TryAdd(player, DiceRoller.DiceRoll(1, 20, player.getInitiativeMod(), 0));

            var list = InitiativeRolls.ToList();
            list.Sort((pair1,pair2) => pair1.Value.CompareTo(pair2.Value));
            var finalList = new List<Object>();
            foreach(KeyValuePair<object,int> pair in list){
                finalList.Add(pair.Key);
            }
            return finalList;
        }

        public void displayInitiativeOrder(){
            Console.WriteLine("Ordre d'initiative: ");
            for(int i = InitiativeOrder.Count-1; i>=0; i--){
                if(InitiativeOrder[i] is Player){
                    Console.Write(player.getName()+", ");
                }else{
                    Enemy? enemy = InitiativeOrder[i] as Enemy;
                    Console.Write(enemy!.getName() + ", ");
                }
            }
            Console.WriteLine();
        }
        public List<object> getInitiativeOrder(){
            return this.InitiativeOrder;
        }
    }
}