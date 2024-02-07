namespace ConsoleRPG2
{
    public class Player
    {

        private static Random rnd = new Random();
        private int playerXPos;
        private int playerYPos;
        // Nom du joueur et niveau
        private string playerName;
        private int playerLevel;

        // PV, XP, armure et distance de déplacement
        private int HPmax;
        private int HP;
        private int HPtemp;
        private int XPthreshold;
        private int XP;
        private int playerAC;
        private int MoveDistance;
        private int InitiativeMod;
        private int Initiative;
        private int MasteryBonus;

        // Caractéristiques
        private int Strength;
        private int Dexterity;
        private int Constitution;
        private int Wisdom;
        private int Intelligence;
        private int Charisma;

        // Modificateurs
        private int StrengthMod;
        private int DexterityMod;
        private int ConstitutionMod;
        private int WisdomMod;
        private int IntelligenceMod;
        private int CharismaMod;

        // Jets de sauvegarde
        private bool isStrengthSTmastered;
        private int StrengthST;
        private bool isDexteritySTmastered;
        private int DexterityST;
        private bool isConstitutionSTmastered;
        private int ConstitutionST;
        private bool isWisdomSTmastered;
        private int WisdomST;
        private bool isIntelligenceSTmastered;
        private int IntelligenceST;
        private bool isCharismaSTmastered;
        private int CharismaST;

        // Compétences
        private bool isAthleticsMastered;
        private int Athletics; // Force
        private bool isAcrobaticsMastered;
        private int Acrobatics; // Dextérité
        private bool isSleightOfHandMastered;
        private int SleightOfHand; // Dextérité
        private bool isStealthMastered;
        private int Stealth; // Dextérité
        private bool isArcanaMastered;
        private int Arcana; // Intelligence
        private bool isHistoryMastered;
        private int History; // Intelligence
        private bool isInvestigationMastered;
        private int Investigation; // Intelligence
        private bool isNatureMastered;
        private int Nature; // Intelligence
        private bool isReligionMastered;
        private int Religion; // Intelligence
        private bool isAnimalHandlingMastered;
        private int AnimalHandling; // Sagesse
        private bool isInsightMastered;
        private int Insight; // Sagesse
        private bool isMedicineMastered;
        private int Medicine; // Sagesse
        private bool isPerceptionMastered;
        private int Perception; // Sagesse
        private bool isSurvivalMastered;
        private int Survival; // Sagesse
        private bool isDeceptionMastered;
        private int Deception; // Charisme
        private bool isIntimidationMastered;
        private int Intimidation; // Charisme
        private bool isPerformanceMastered;
        private int Performance; // Charisme
        private bool isPersuasionMastered;
        private int Persuasion; // Charisme

        // Constructeur
        public Player(string name)
        {
            this.playerXPos = 3;
            this.playerYPos = 3;
            this.playerName = name;
            this.playerLevel = 1;
            this.XP = 0;
            this.XPthreshold = 300;
            this.MasteryBonus = 2;

            this.Strength = 0;
            this.Dexterity = 0;
            this.Constitution = 0;
            this.Wisdom = 0;
            this.Intelligence = 0;
            this.Charisma = 0;

            this.isAthleticsMastered = false;
            this.isAcrobaticsMastered = false;
            this.isAnimalHandlingMastered = false;
            this.isArcanaMastered = false;
            this.isDeceptionMastered = false;
            this.isHistoryMastered = false;
            this.isInsightMastered = false;
            this.isIntimidationMastered = false;
            this.isInvestigationMastered = false;
            this.isMedicineMastered = false;
            this.isNatureMastered = false;
            this.isPerceptionMastered = false;
            this.isPerformanceMastered = false;
            this.isPersuasionMastered = false;
            this.isReligionMastered = false;
            this.isSleightOfHandMastered = false;
            this.isStealthMastered = false;
            this.isSurvivalMastered = false;

            this.isStrengthSTmastered = false;
            this.isDexteritySTmastered = false;
            this.isConstitutionSTmastered = false;
            this.isWisdomSTmastered = false;
            this.isIntelligenceSTmastered = false;
            this.isCharismaSTmastered = false;

            this.MoveDistance = 9;
            this.HP = HPmax;
            this.HPtemp = 0;
            this.InitiativeMod = this.DexterityMod;
        }

        // Met à jour les modificateurs de caractéristiques.
        public void updateStatMods()
        {
            this.StrengthMod = (this.Strength - 10) / 2;
            this.DexterityMod = (this.Dexterity - 10) / 2;
            this.ConstitutionMod = (this.Constitution - 10) / 2;
            this.WisdomMod = (this.Wisdom - 10) / 2;
            this.IntelligenceMod = (this.Intelligence - 10) / 2;
            this.CharismaMod = (this.Charisma - 10) / 2;
            updateST();
            updateSkillMods();
        }

        // Met à jour les modificateurs de jets de sauvegarde
        public void updateST()
        {
            this.StrengthST = this.isStrengthSTmastered ? this.StrengthMod + this.MasteryBonus : this.StrengthMod;
            this.DexterityST = this.isDexteritySTmastered ? this.DexterityMod + this.MasteryBonus : this.DexterityMod;
            this.ConstitutionST = this.isConstitutionSTmastered ? this.ConstitutionMod + this.MasteryBonus : this.ConstitutionMod;
            this.WisdomST = this.isWisdomSTmastered ? this.WisdomMod + this.MasteryBonus : this.WisdomMod;
            this.IntelligenceST = this.isIntelligenceSTmastered ? this.IntelligenceMod + this.MasteryBonus : this.IntelligenceMod;
            this.CharismaST = this.isCharismaSTmastered ? this.CharismaMod + this.MasteryBonus : this.CharismaMod;
        }

        // Met à jour les modificateurs de compétences
        public void updateSkillMods()
        {
            this.Acrobatics = this.isAcrobaticsMastered ? this.DexterityMod + this.MasteryBonus : this.DexterityMod;
            this.AnimalHandling = this.isAnimalHandlingMastered ? this.WisdomMod + this.MasteryBonus : this.WisdomMod;
            this.Arcana = this.isArcanaMastered ? this.IntelligenceMod + this.MasteryBonus : this.IntelligenceMod;
            this.Athletics = this.isAthleticsMastered ? this.StrengthMod + this.MasteryBonus : this.StrengthMod;
            this.Deception = this.isDeceptionMastered ? this.CharismaMod + this.MasteryBonus : this.CharismaMod;
            this.History = this.isHistoryMastered ? this.IntelligenceMod + this.MasteryBonus : this.IntelligenceMod;
            this.Insight = this.isInsightMastered ? this.WisdomMod + this.MasteryBonus : this.WisdomMod;
            this.Intimidation = this.isIntimidationMastered ? this.CharismaMod + this.MasteryBonus : this.CharismaMod;
            this.Investigation = this.isInvestigationMastered ? this.IntelligenceMod + this.MasteryBonus : this.IntelligenceMod;
            this.Medicine = this.isMedicineMastered ? this.WisdomMod + this.MasteryBonus : this.WisdomMod;
            this.Nature = this.isNatureMastered ? this.IntelligenceMod + this.MasteryBonus : this.IntelligenceMod;
            this.Perception = this.isPerceptionMastered ? this.WisdomMod + this.MasteryBonus : this.WisdomMod;
            this.Performance = this.isPerformanceMastered ? this.CharismaMod + this.MasteryBonus : this.CharismaMod;
            this.Persuasion = this.isPersuasionMastered ? this.CharismaMod + this.MasteryBonus : this.CharismaMod;
            this.Religion = this.isReligionMastered ? this.IntelligenceMod + this.MasteryBonus : this.IntelligenceMod;
            this.SleightOfHand = this.isSleightOfHandMastered ? this.DexterityMod + this.MasteryBonus : this.DexterityMod;
            this.Stealth = this.isStealthMastered ? this.DexterityMod + this.MasteryBonus : this.DexterityMod;
            this.Survival = this.isSurvivalMastered ? this.WisdomMod + this.MasteryBonus : this.WisdomMod;
        }

        // Met à jour le modificateur de force
        public void updateStrengthMod(){
            this.StrengthMod = (this.Strength - 10) / 2;
        }

        // Met à jour le modificateur de dexterité
         public void updateDexterityMod(){
            this.DexterityMod = (this.Dexterity - 10) / 2;
        }

        // Met à jour le modificateur de constitution
         public void updateConstitutionMod(){
            this.ConstitutionMod = (this.Constitution - 10) / 2;
        }

        // Met à jour le modificateur de sagesse
         public void updateWisdomMod(){
            this.WisdomMod = (this.Wisdom - 10) / 2;
        }

        // Met à jour le modificateur d'intelligence
         public void updateIntelligenceMod(){
            this.IntelligenceMod = (this.Intelligence - 10) / 2;
        }

        // Met à jour le modificateur de charisme
         public void updateCharismaMod(){
            this.CharismaMod = (this.Charisma - 10) / 2;
        }

        // Met à jour les pv maximum au niveau 1
        public void updateInitialHPMax(){
            this.HPmax = 8 + this.ConstitutionMod;
            this.HP = this.HPmax;
        }

        // Met à jour la classe d'armure
        public void updateAC(){
            this.playerAC = 10 + this.DexterityMod;
        }

        // Met à jour le modificateur d'initiative
        public void updateInitiativeMod(){
            this.InitiativeMod = this.DexterityMod;
        }

        // Méthode en accès écriture pour toutes les caractéristiques et met tout à jour.
        public void setStats(int str, int dex, int con, int wis, int inte, int cha){
            this.Strength = str;
            this.Dexterity = dex;
            this.Constitution = con;
            this.Wisdom = wis;
            this.Intelligence = inte;
            this.Charisma = cha;
            this.updateAll();
        }

        // Accès en écriture pour la caractéristique de Force
        public void setStrength(int value){
            this.Strength = value;
        }

        // Accès en écriture pour la caractéristique de Dextérité
        public void setDexterity(int value){
            this.Dexterity = value;
        }

        // Accès en écriture pour la caractéristique de Constitution
        public void setConstitution(int value){
            this.Constitution = value;
        }

        // Accès en écriture pour la caractéristique de Sagesse
        public void setWisdom(int value){
            this.Wisdom = value;
        }

        // Accès en écriture pour la caractéristique d'Intelligence
        public void setIntelligence(int value){
            this.Intelligence = value;
        }

        // Accès en écriture pour la caractéristique de Charisme
        public void setCharisma(int value){
            this.Charisma = value;
        }

        // Accès en lecture pour la caractéristique de Force
        public int getStrength(){
            return this.Strength;
        }

        // Accès en lecture pour la caractéristique de Dextérité
        public int getDexterity(){
            return this.Dexterity;
        }

        // Accès en lecture pour la caractéristique de Constitution
        public int getConstitution(){
            return this.Constitution;
        }

        // Accès en lecture pour la caractéristique de Sagesse
        public int getWisdom(){
            return this.Wisdom;
        }

        // Accès en lecture pour la caractéristique de Intelligence
        public int getIntelligence(){
            return this.Intelligence;
        }

        // Accès en lecture pour la caractéristique de Charisme
        public int getCharisma(){
            return this.Charisma;
        }

        // Accès en lecture de toutes les statistiques sous forme de tableau
        public int[] getStats(){
            int[] stats = new int[]{this.getStrength(),this.getDexterity(),this.getConstitution(),this.getWisdom(),this.getIntelligence(),this.getCharisma()};
            return stats;
        }


        // Met à jour tout.
        public void updateAll(){
            this.updateStatMods();
            this.updateST();
            this.updateSkillMods();
            this.updateInitiativeMod();
            this.updateInitialHPMax();
            this.updateAC();
        }

        // Affichage de la fiche de personnage.
        public void displayCharacterSheet()
        {
            string plusminus = "";
            Console.WriteLine($"Nom: {this.playerName}");
            Console.WriteLine($"Niveau: {this.playerLevel}");
            Console.WriteLine($"XP: {this.XP}/{this.XPthreshold}");
            Console.WriteLine($"Mastery Bonus: +{this.MasteryBonus}\n");

            Console.WriteLine($"HP: {this.HP}/{this.HPmax}");
            Console.WriteLine($"HP Temp: {this.HPtemp}");
            Console.WriteLine($"Distance de dép. : {this.MoveDistance}m");
            Console.WriteLine($"AC: {this.playerAC}\n");

            plusminus = this.StrengthMod < 0 ? "" : "+";
            Console.WriteLine($"Force: {this.Strength} ({plusminus}{this.StrengthMod})");
            plusminus = this.DexterityMod < 0 ? "" : "+";
            Console.WriteLine($"Dextérité: {this.Dexterity} ({plusminus}{this.DexterityMod})");
            plusminus = this.ConstitutionMod < 0 ? "" : "+";
            Console.WriteLine($"Constitution: {this.Constitution} ({plusminus}{this.ConstitutionMod})");
            plusminus = this.WisdomMod < 0 ? "" : "+";
            Console.WriteLine($"Sagesse: {this.Wisdom} ({plusminus}{this.WisdomMod})");
            plusminus = this.IntelligenceMod < 0 ? "" : "+";
            Console.WriteLine($"Intelligence: {this.Intelligence} ({plusminus}{this.IntelligenceMod})");
            plusminus = this.CharismaMod < 0 ? "" : "+";
            Console.WriteLine($"Charisme: {this.Charisma} ({plusminus}{this.CharismaMod})\n");

            plusminus = this.StrengthST < 0 ? "" : "+";
            Console.WriteLine($"JDS Force: {plusminus}{this.StrengthST} (Maitrisé: {this.isStrengthSTmastered})");
            plusminus = this.DexterityST < 0 ? "" : "+";
            Console.WriteLine($"JDS Dextérité: {plusminus}{this.DexterityST} (Maitrisé: {this.isDexteritySTmastered})");
            plusminus = this.ConstitutionST < 0 ? "" : "+";
            Console.WriteLine($"JDS Constitution: {plusminus}{this.ConstitutionST} (Maitrisé: {this.isConstitutionSTmastered})");
            plusminus = this.WisdomST < 0 ? "" : "+";
            Console.WriteLine($"JDS Sagesse: {plusminus}{this.WisdomST} (Maitrisé: {this.isWisdomSTmastered})");
            plusminus = this.IntelligenceST < 0 ? "" : "+";
            Console.WriteLine($"JDS Intelligence: {plusminus}{this.IntelligenceST} (Maitrisé: {this.isIntelligenceSTmastered})");
            plusminus = this.CharismaST < 0 ? "" : "+";
            Console.WriteLine($"JDS Charisme: {plusminus}{this.CharismaST} (Maitrisé: {this.isWisdomSTmastered})\n");
        }

        public int getPlayerXPos(){
            return this.playerXPos;
        }

        public int getPlayerYPos(){
            return this.playerYPos;
        }

        public void setPlayerXPos(int x){
            this.playerXPos = x;
        }

        public void setPlayerYPos(int y){
            this.playerYPos = y;
        }

        public void setPlayerPos(int x, int y){
            setPlayerXPos(x);
            setPlayerYPos(y);
        }

        public void setRandomPlayerPos(){
            int rndX = rnd.Next(1,DrawMap.getXsize());
            int rndY = rnd.Next(1,DrawMap.getYsize());
            while(DrawMap.getWallChars().Contains(DrawMap.GetMap()[rndX][rndY])){
                rndX = rnd.Next(1,DrawMap.getXsize());
                rndY = rnd.Next(1,DrawMap.getYsize());
            }
            this.setPlayerPos(rndX,rndY);
        }

        public void movePlayer(){
            DrawMap.setPreviousPlayerPos(this.playerXPos, this.playerYPos);

            char upChar = '/';
            char rightChar = '/';
            char leftChar = '/';
            char botChar = '/';

            try{
                upChar = DrawMap.GetMap()[this.playerXPos][this.playerYPos-1];
            }catch(Exception){

            }

            try{
                rightChar = DrawMap.GetMap()[this.playerXPos+1][this.playerYPos];
            }catch(Exception){

            }

            try{
                leftChar = DrawMap.GetMap()[this.playerXPos-1][this.playerYPos];
            }catch(Exception){

            }

            try{
                botChar = DrawMap.GetMap()[this.playerXPos][this.playerYPos+1];
            }catch(Exception){

            }
            Console.WriteLine($"Upchar: {upChar} Botchar: {botChar} LeftChar: {leftChar} RightChar: {rightChar}");
            
            switch(Console.ReadKey().Key){
                case ConsoleKey.UpArrow:
                if(!DrawMap.getWallChars().Contains(upChar) && this.playerYPos-1 > 0 && this.playerYPos-1 < DrawMap.getYsize()){
                        this.playerYPos -= 1;
                }
                break;
                case ConsoleKey.DownArrow:
                if(!DrawMap.getWallChars().Contains(botChar) && this.playerYPos+1 > 0 && this.playerYPos+1 < DrawMap.getYsize()){
                    this.playerYPos +=1;
                }
                break;
                case ConsoleKey.LeftArrow:
                if(!DrawMap.getWallChars().Contains(leftChar) && this.playerXPos-1 > 0 && this.playerXPos-1 < DrawMap.getXsize()){
                    this.playerXPos -=1;
                }
                break;
                case ConsoleKey.RightArrow:
                if(!DrawMap.getWallChars().Contains(rightChar) && this.playerXPos+1 > 0 && this.playerXPos+1 < DrawMap.getXsize()){
                    this.playerXPos +=1;
                }
                break;
            }
        }
    }
}