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

            this.moveMarkerX = this.playerXPos + 1;
            this.moveMarkerY = this.playerYPos;
            this.availableMovement = this.MoveDistance;
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
        public void updateStrengthMod()
        {
            this.StrengthMod = (this.Strength - 10) / 2;
        }

        // Met à jour le modificateur de dexterité
        public void updateDexterityMod()
        {
            this.DexterityMod = (this.Dexterity - 10) / 2;
        }

        // Met à jour le modificateur de constitution
        public void updateConstitutionMod()
        {
            this.ConstitutionMod = (this.Constitution - 10) / 2;
        }

        // Met à jour le modificateur de sagesse
        public void updateWisdomMod()
        {
            this.WisdomMod = (this.Wisdom - 10) / 2;
        }

        // Met à jour le modificateur d'intelligence
        public void updateIntelligenceMod()
        {
            this.IntelligenceMod = (this.Intelligence - 10) / 2;
        }

        // Met à jour le modificateur de charisme
        public void updateCharismaMod()
        {
            this.CharismaMod = (this.Charisma - 10) / 2;
        }

        // Met à jour les pv maximum au niveau 1
        public void updateInitialHPMax()
        {
            this.HPmax = 8 + this.ConstitutionMod;
            this.HP = this.HPmax;
        }

        // Met à jour la classe d'armure
        public void updateAC()
        {
            this.playerAC = 10 + this.DexterityMod;
        }

        // Met à jour le modificateur d'initiative
        public void updateInitiativeMod()
        {
            this.InitiativeMod = this.DexterityMod;
        }

        // Méthode en accès écriture pour toutes les caractéristiques et met tout à jour.
        public void setStats(int str, int dex, int con, int wis, int inte, int cha)
        {
            this.Strength = str;
            this.Dexterity = dex;
            this.Constitution = con;
            this.Wisdom = wis;
            this.Intelligence = inte;
            this.Charisma = cha;
            this.UpdateAll();
        }

        // Accès en écriture pour la caractéristique de Force
        public void setStrength(int value)
        {
            this.Strength = value;
        }

        // Accès en écriture pour la caractéristique de Dextérité
        public void setDexterity(int value)
        {
            this.Dexterity = value;
        }

        // Accès en écriture pour la caractéristique de Constitution
        public void setConstitution(int value)
        {
            this.Constitution = value;
        }

        // Accès en écriture pour la caractéristique de Sagesse
        public void setWisdom(int value)
        {
            this.Wisdom = value;
        }

        // Accès en écriture pour la caractéristique d'Intelligence
        public void setIntelligence(int value)
        {
            this.Intelligence = value;
        }

        // Accès en écriture pour la caractéristique de Charisme
        public void setCharisma(int value)
        {
            this.Charisma = value;
        }

        // Accès en lecture pour la caractéristique de Force
        public int getStrength()
        {
            return this.Strength;
        }

        // Accès en lecture pour la caractéristique de Dextérité
        public int getDexterity()
        {
            return this.Dexterity;
        }

        // Accès en lecture pour la caractéristique de Constitution
        public int getConstitution()
        {
            return this.Constitution;
        }

        // Accès en lecture pour la caractéristique de Sagesse
        public int getWisdom()
        {
            return this.Wisdom;
        }

        // Accès en lecture pour la caractéristique de Intelligence
        public int getIntelligence()
        {
            return this.Intelligence;
        }

        // Accès en lecture pour la caractéristique de Charisme
        public int GetCharisma()
        {
            return this.Charisma;
        }

        // Accès en lecture de toutes les statistiques sous forme de tableau
        public int[] GetStats()
        {
            int[] stats = new int[] { this.getStrength(), this.getDexterity(), this.getConstitution(), this.getWisdom(), this.getIntelligence(), this.GetCharisma() };
            return stats;
        }

        public int getInitiativeMod()
        {
            return this.InitiativeMod;
        }

        public string getName()
        {
            return this.playerName;
        }

        // Met à jour tout.
        public void UpdateAll()
        {
            this.updateStatMods();
            this.updateST();
            this.updateSkillMods();
            this.updateInitiativeMod();
            this.updateInitialHPMax();
            this.updateAC();
        }

        // Affichage de la fiche de personnage.
        public void DisplayCharacterSheet()
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

        // Accès en lecture pour la position X du joueur
        public int PlayerXPos => this.playerXPos;

        // Accès en lecture pour la position Y du joueur
        public int PlayerYPos => this.playerYPos;

        // Accès en ecriture pour la position X du joueur
        public void SetPlayerXPos(int x) => this.playerXPos = x;

        // Accès en ecriture pour la position y du joueur
        public void SetPlayerYPos(int y) => this.playerYPos = y;
        int moveMarkerX = 1;
        int moveMarkerY = 1;
        int availableMovement = 1;
        bool isPlayersTurn = true;
        bool canMove = true;

        // Accès en ecriture pour la position du joueur
        public void SetPlayerPos(int x, int y)
        {
            SetPlayerXPos(x);
            SetPlayerYPos(y);
        }

        // Permet de faire apparaitre le joueur à un point aléatoire sur la carte (ps encore au point)
        public void SetRandomPlayerPos()
        {
            int rndX = rnd.Next(1, DrawMap.getXsize());
            int rndY = rnd.Next(1, DrawMap.getYsize());
            while (DrawMap.getCollisionChars().Contains(DrawMap.GetMap()[rndX][rndY]))
            {
                rndX = rnd.Next(1, DrawMap.getXsize());
                rndY = rnd.Next(1, DrawMap.getYsize());
            }
            this.SetPlayerPos(rndX, rndY);
        }

        // Fonction traitant les actions du joueur
        public void PlayerAction()
        {
            DrawMap.setPreviousPlayerPos(this.playerXPos, this.playerYPos);
            Dictionary<string, char> surroundingChars = CheckPlayerSurroundings();
            List<Enemy> EnemiesInRoom = this.EnemyinRoom();

            // Lignes de debugging
            //Console.WriteLine($"XPOS: {this.PlayerXPos} YPOS: {this.PlayerYPos}");
            //Console.WriteLine($"Upchar: {surroundingChars["upChar"]} Botchar: {surroundingChars["botChar"]} LeftChar: {surroundingChars["leftChar"]} RightChar: {surroundingChars["rightChar"]}");

            // Affichage du menu d'action du joueur
            Console.WriteLine($"{EnemiesInRoom.Count()} ENEMY IN ROOM");
            PlayerActionMenu.DisplayActionMenu();

            // Lit les input du joueur
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Z: // Mouvement vers le haut
                    if (!DrawMap.getCollisionChars().Contains(surroundingChars["upChar"]) && this.playerYPos - 1 > 0 && this.playerYPos - 1 < DrawMap.getYsize())
                    {
                        this.playerYPos -= 1;
                        DrawMap.UpdateMapPlayerPos(this);
                    }
                    break;
                case ConsoleKey.S: // Mouvement vers le bas
                    if (!DrawMap.getCollisionChars().Contains(surroundingChars["botChar"]) && this.playerYPos + 1 > 0 && this.playerYPos + 1 < DrawMap.getYsize())
                    {
                        this.playerYPos += 1;
                        DrawMap.UpdateMapPlayerPos(this);
                    }
                    break;
                case ConsoleKey.Q: // Mouvement vers la gauche
                    if (!DrawMap.getCollisionChars().Contains(surroundingChars["leftChar"]) && this.playerXPos - 1 > 0 && this.playerXPos - 1 < DrawMap.getXsize())
                    {
                        this.playerXPos -= 1;
                        DrawMap.UpdateMapPlayerPos(this);
                    }
                    break;
                case ConsoleKey.D: // Mouvement vers la droite
                    if (!DrawMap.getCollisionChars().Contains(surroundingChars["rightChar"]) && this.playerXPos + 1 > 0 && this.playerXPos + 1 < DrawMap.getXsize())
                    {
                        this.playerXPos += 1;
                        DrawMap.UpdateMapPlayerPos(this);
                    }
                    break;

                case ConsoleKey.D0:
                    PlayerActionMenu.ActionMenu(0);
                    break;
                case ConsoleKey.D1:
                    PlayerActionMenu.ActionMenu(1);
                    break;
                case ConsoleKey.D2:
                    PlayerActionMenu.ActionMenu(2);
                    break;
                case ConsoleKey.D3:
                    PlayerActionMenu.ActionMenu(3);
                    break;
                case ConsoleKey.D4:
                    PlayerActionMenu.ActionMenu(4);
                    break;
                case ConsoleKey.D5:
                    PlayerActionMenu.ActionMenu(5);
                    break;
                case ConsoleKey.D6:
                    PlayerActionMenu.ActionMenu(6);
                    break;
                case ConsoleKey.D7:
                    PlayerActionMenu.ActionMenu(7);
                    break;
                case ConsoleKey.D8:
                    PlayerActionMenu.ActionMenu(8);
                    break;
                case ConsoleKey.D9:
                    PlayerActionMenu.ActionMenu(9);
                    break;
            }
            if (EnemiesInRoom.Count() != 0)
            {
                if (StateMachine.getCurrentState() is not Combat)
                {
                    Combat combat = new Combat(this, EnemiesInRoom);
                    StateMachine.addState(combat);
                }
            }
            else
            {
                if (StateMachine.getCurrentState() is Combat)
                {
                    StateMachine.removeLastState();
                }
            }
        }

        public void initMoveMarker()
        {
            this.moveMarkerX = this.PlayerXPos;
            this.moveMarkerY = this.PlayerYPos;
            if (this.availableMovement <= 0)
            {
                this.availableMovement = this.MoveDistance;
            }
        }

        public void setPlayersTurn(bool b)
        {
            this.isPlayersTurn = b;
        }
        public bool getIsPlayersTurn()
        {
            return this.isPlayersTurn;
        }

        public int getMoveDistance()
        {
            return this.MoveDistance;
        }

        public int getAvailableMovement()
        {
            return this.availableMovement;
        }

        public int getMoveMarkerPosX()
        {
            return this.moveMarkerX;
        }

        public int getMoveMarkerPosY()
        {
            return this.moveMarkerY;
        }

        public void PlayerCombatAction()
        {
            this.canMove = true;
            this.isPlayersTurn = true;
            int tempMaxMove = this.MoveDistance;
            do
            {
                int[] currentChunk = this.getPlayerCurrentChunk();
                DrawMap.DrawChunk(currentChunk[0], currentChunk[1]);
                DrawMap.setPreviousPlayerPos(this.playerXPos, this.playerYPos);
                DrawMap.setPreviousMoveMarkerPos(this.moveMarkerX, this.moveMarkerY);
                int nextavailablemovement;
                Dictionary<string, char> surroundingChars = new()
                {
                    { "upChar", DrawMap.GetMap()[this.moveMarkerX][this.moveMarkerY - 1] },
                    { "rightChar", DrawMap.GetMap()[this.moveMarkerX + 1][this.moveMarkerY] },
                    { "leftChar", DrawMap.GetMap()[this.moveMarkerX - 1][this.moveMarkerY] },
                    { "botChar", DrawMap.GetMap()[this.moveMarkerX][this.moveMarkerY + 1] }
                };

                PlayerActionMenu.DisplayCombatActionMenu(this);
                Console.WriteLine(StateMachine.getCurrentState());

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Z: // Mouvement vers le haut
                        nextavailablemovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX - this.playerXPos, 2) + Math.Pow(this.moveMarkerY - 1 - this.PlayerYPos, 2)));
                        if (!DrawMap.getCollisionChars().Contains(surroundingChars["upChar"]) && this.moveMarkerY - 1 > 0 && this.moveMarkerY - 1 < DrawMap.getYsize() && PlayerActionMenu.getCurrentCombatState() == "deplacement" && nextavailablemovement >= 0 && this.canMove)
                        {
                            this.moveMarkerY -= 1;
                            this.availableMovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX - this.playerXPos, 2) + Math.Pow(this.moveMarkerY - this.PlayerYPos, 2)));
                            DrawMap.UpdateMapMoveMarkerPos(this);
                            DrawMap.UpdateMapPlayerPos(this);
                        }
                        break;
                    case ConsoleKey.S: // Mouvement vers le bas
                        nextavailablemovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX - this.playerXPos, 2) + Math.Pow(this.moveMarkerY + 1 - this.PlayerYPos, 2)));
                        if (!DrawMap.getCollisionChars().Contains(surroundingChars["botChar"]) && this.moveMarkerY + 1 > 0 && this.moveMarkerY + 1 < DrawMap.getYsize() && PlayerActionMenu.getCurrentCombatState() == "deplacement" && nextavailablemovement >= 0 && this.canMove)
                        {
                            this.moveMarkerY += 1;
                            this.availableMovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX - this.playerXPos, 2) + Math.Pow(this.moveMarkerY - this.PlayerYPos, 2)));
                            DrawMap.UpdateMapMoveMarkerPos(this);
                            DrawMap.UpdateMapPlayerPos(this);
                        }
                        break;
                    case ConsoleKey.Q: // Mouvement vers la gauche
                        nextavailablemovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX - 1 - this.playerXPos, 2) + Math.Pow(this.moveMarkerY - this.PlayerYPos, 2)));
                        if (!DrawMap.getCollisionChars().Contains(surroundingChars["leftChar"]) && this.moveMarkerX - 1 > 0 && this.moveMarkerX - 1 < DrawMap.getXsize() && PlayerActionMenu.getCurrentCombatState() == "deplacement" && nextavailablemovement >= 0 && this.canMove)
                        {
                            this.moveMarkerX -= 1;
                            this.availableMovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX - this.playerXPos, 2) + Math.Pow(this.moveMarkerY - this.PlayerYPos, 2)));
                            DrawMap.UpdateMapMoveMarkerPos(this);
                            DrawMap.UpdateMapPlayerPos(this);
                        }
                        break;
                    case ConsoleKey.D: // Mouvement vers la droite
                        nextavailablemovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX + 1 - this.playerXPos, 2) + Math.Pow(this.moveMarkerY - this.PlayerYPos, 2)));
                        if (!DrawMap.getCollisionChars().Contains(surroundingChars["rightChar"]) && this.moveMarkerX + 1 > 0 && this.moveMarkerX + 1 < DrawMap.getXsize() && PlayerActionMenu.getCurrentCombatState() == "deplacement" && nextavailablemovement >= 0 && this.canMove)
                        {
                            this.moveMarkerX += 1;
                            this.availableMovement = tempMaxMove - Convert.ToInt32(Math.Sqrt(Math.Pow(this.moveMarkerX - this.playerXPos, 2) + Math.Pow(this.moveMarkerY - this.PlayerYPos, 2)));
                            DrawMap.UpdateMapMoveMarkerPos(this);
                            DrawMap.UpdateMapPlayerPos(this);
                        }
                        break;

                    case ConsoleKey.E:
                        if (PlayerActionMenu.getCurrentCombatState() == "deplacement")
                        {
                            if(this.availableMovement <= 0){
                                this.canMove = false;
                                tempMaxMove = this.availableMovement;
                            }else{
                                tempMaxMove = this.availableMovement;
                            }
                            this.playerXPos = this.moveMarkerX;
                            this.playerYPos = this.moveMarkerY;
                            DrawMap.UpdateMapPlayerPos(this);
                            PlayerActionMenu.removeLastCombatState();
                        }
                        break;


                    case ConsoleKey.D0:
                        PlayerActionMenu.CombatActionMenu(0, this);
                        break;
                    case ConsoleKey.D1:
                        PlayerActionMenu.CombatActionMenu(1, this);
                        break;
                    case ConsoleKey.D2:
                        PlayerActionMenu.CombatActionMenu(2, this);
                        break;
                    case ConsoleKey.D3:
                        PlayerActionMenu.CombatActionMenu(3, this);
                        break;
                    case ConsoleKey.D4:
                        PlayerActionMenu.CombatActionMenu(4, this);
                        break;
                    case ConsoleKey.D5:
                        PlayerActionMenu.CombatActionMenu(5, this);
                        break;
                    case ConsoleKey.D6:
                        PlayerActionMenu.CombatActionMenu(6, this);
                        break;
                    case ConsoleKey.D7:
                        PlayerActionMenu.CombatActionMenu(7, this);
                        break;
                    case ConsoleKey.D8:
                        PlayerActionMenu.CombatActionMenu(8, this);
                        break;
                    case ConsoleKey.D9:
                        PlayerActionMenu.CombatActionMenu(9, this);
                        break;
                }
            } while (isPlayersTurn);
        }

        // Renvoie la liste des ennemies dans la même salle que le joueur
        public List<Enemy> EnemyinRoom()
        {
            List<Enemy> enemyInRoom = new List<Enemy>();
            int[] playercurrentchunk = this.getPlayerCurrentChunk();
            foreach (Enemy enemy in Program.enemies!)
            {
                int[] enemyCurrentChunk = { enemy.getXpos() / 26, enemy.getYpos() / 9 };
                if (enemyCurrentChunk[0] == playercurrentchunk[0] && enemyCurrentChunk[1] == playercurrentchunk[1])
                {
                    enemyInRoom.Add(enemy);
                }
            }
            return enemyInRoom;
        }

        // Renvoie sous forme de tableau le chunk courant du joueur
        public int[] getPlayerCurrentChunk()
        {
            int[] playerChunk = new int[] { this.PlayerXPos / 26, this.PlayerYPos / 9 };
            return playerChunk;
        }

        // Renvoie sous forme de dictionnaire, les caractères autour du joueur
        public Dictionary<string, char> CheckPlayerSurroundings()
        {
            Dictionary<string, char> surroundingChars = new()
            {
                { "upChar", DrawMap.GetMap()[this.playerXPos][this.playerYPos - 1] },
                { "rightChar", DrawMap.GetMap()[this.playerXPos + 1][this.playerYPos] },
                { "leftChar", DrawMap.GetMap()[this.playerXPos - 1][this.playerYPos] },
                { "botChar", DrawMap.GetMap()[this.playerXPos][this.playerYPos + 1] }
            };
            return surroundingChars;
        }
    }
}