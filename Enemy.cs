namespace ConsoleRPG2
{
    public class Enemy
    {
        private static Random rnd = new Random();
        private static List<char> EnemyTokens = [];

        private string EnemyName;
        private int XPos;
        private int YPos;
        private int[] previousPosition = new int[2];
        private int HPmax;
        private int CurrentHP;
        private int Level;
        private int XPReward;
        private int AC;
        private char enemyToken;

        public Enemy(string name, int hpmax, int level, int ac, int xpreward, char token)
        {
            this.EnemyName = name;
            this.HPmax = hpmax;
            this.CurrentHP = hpmax;
            this.Level = level;
            this.AC = ac;
            this.XPReward = xpreward;
            this.enemyToken = token;
            DrawMap.addCollisionChar(this.enemyToken);
            EnemyTokens.Add(this.enemyToken);
        }

        public static Enemy[] InitializeEnemies(int numberOfEnemies)
        {
            Enemy[] enemies = new Enemy[numberOfEnemies];
            for (int i = 0; i < numberOfEnemies; i++)
            {
                enemies[i] = new Enemy("Goblin", 12, 1, 14, 20, 'o');
            }
            DrawMap.InitializeEnemiesPosition(enemies);
            return enemies;
        }

        public void setXPos(int x)
        {
            this.XPos = x;
        }
        public void setYPos(int y)
        {
            this.YPos = y;
        }

        public void setPos(int x, int y)
        {
            this.setXPos(x);
            this.setYPos(y);
        }

        public int[] getPreviousPosition()
        {
            return previousPosition;
        }

        public int getXpos()
        {
            return this.XPos;
        }
        public int getYpos()
        {
            return this.YPos;
        }

        public char getDisplayToken()
        {
            return this.enemyToken;
        }

        public static List<char> getEnemyTokenList(){
            return EnemyTokens;
        }
    }
}