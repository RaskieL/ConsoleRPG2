using System.Runtime.ConstrainedExecution;
using System.IO;
using System.Net.Mail;

namespace ConsoleRPG2
{

    public static class DrawMap
    {

        private static string[] rightConnectors = ["r", "lr", "blr", "hlr", "bhlr", "hr", "bhr", "br"];
        private static string[] topConnectors = ["h", "hl", "hlr", "bhl", "bhlr", "hr", "bhr", "bh"];
        private static string[] bottomConnectors = ["b", "bl", "blr", "bhl", "bhlr", "bhr", "br", "bh"];
        private static string[] leftConnectors = ["l", "bl", "lr", "blr", "hlr", "hl", "bhl", "bhlr"];

        private static string[][] modularChunks = [rightConnectors, topConnectors, bottomConnectors, leftConnectors];
        private static Dictionary<int[], string> mapChunks = [];
        private static char[][] map = new char[XSIZE][];

        private const char playerToken = 'O';
        private static int[] previousPlayerPosition = [0, 0];

        private static Random rnd = new Random();

        private const int MAPCHUNKSIZE = 3;

        private const int XSIZE = MAPCHUNKSIZE * 26 + 1;
        private const int YSIZE = MAPCHUNKSIZE * 9;

        private static char[] wallChars = ['|', '_', '‾', '/', '\\'];


        public static void generateMap()
        {
            int[][][] allChunkCoordinates = new int[MAPCHUNKSIZE][][];

            for (int x = 0; x < MAPCHUNKSIZE; x++)
            {

                allChunkCoordinates[x] = new int[MAPCHUNKSIZE][];
                for (int y = 0; y < MAPCHUNKSIZE; y++)
                {

                    int[] chunkCoordinates = [x, y];
                    allChunkCoordinates[x][y] = chunkCoordinates;

                    if (mapChunks.Count == 0)
                    {
                        mapChunks.Add(chunkCoordinates, "r");

                    }
                    else
                    {
                        int rndvalue1 = rnd.Next(0, 4);
                        int rndvalue2 = rnd.Next(0, 8);
                        string chunk = modularChunks[rndvalue1][rndvalue2];
                        if (x > 0 && mapChunks[allChunkCoordinates[x - 1][y]].Contains('r') && !chunk.Contains('l'))
                        {
                            chunk += "l";
                        }
                        if (y > 0 && mapChunks[allChunkCoordinates[x][y - 1]].Contains('b') && !chunk.Contains('h'))
                        {
                            chunk += "h";
                        }

                        if (y == 0 && chunk.Contains('h'))
                        {
                            chunk = chunk.Replace("h", "");
                        }
                        if (y == MAPCHUNKSIZE - 1 && chunk.Contains('b'))
                        {
                            chunk = chunk.Replace("b", "");
                        }
                        if (x == 0 && chunk.Contains('l'))
                        {
                            chunk = chunk.Replace("l", "");
                        }
                        if (x == MAPCHUNKSIZE - 1 && chunk.Contains('r'))
                        {
                            chunk = chunk.Replace("r", "");
                        }
                        chunk = string.Concat(chunk.OrderBy(c => c));

                        mapChunks.Add(chunkCoordinates, chunk);
                    }
                }
            }

            for (int x = 1; x < MAPCHUNKSIZE; x++)
            {
                for (int y = 0; y < MAPCHUNKSIZE; y++)
                {
                    if (rnd.NextDouble() > 0.8)
                    {
                        mapChunks[allChunkCoordinates[x][y]] = "void";
                        if (x < MAPCHUNKSIZE - 1 && mapChunks[allChunkCoordinates[x + 1][y]].Contains('l') && !mapChunks[allChunkCoordinates[x + 1][y]].Equals("void"))
                        {
                            mapChunks[allChunkCoordinates[x + 1][y]] = string.Concat(mapChunks[allChunkCoordinates[x + 1][y]].Replace("l", "").OrderBy(c => c));
                        }
                        if (x > 0 && mapChunks[allChunkCoordinates[x - 1][y]].Contains('r') && !mapChunks[allChunkCoordinates[x - 1][y]].Equals("void"))
                        {
                            mapChunks[allChunkCoordinates[x - 1][y]] = string.Concat(mapChunks[allChunkCoordinates[x - 1][y]].Replace("r", "").OrderBy(c => c));
                        }
                        if (y < MAPCHUNKSIZE - 1 && mapChunks[allChunkCoordinates[x][y + 1]].Contains('h') && !mapChunks[allChunkCoordinates[x][y + 1]].Equals("void"))
                        {
                            mapChunks[allChunkCoordinates[x][y + 1]] = string.Concat(mapChunks[allChunkCoordinates[x][y + 1]].Replace("h", "").OrderBy(c => c));
                        }
                        if (y > 0 && mapChunks[allChunkCoordinates[x][y - 1]].Contains('b') && !mapChunks[allChunkCoordinates[x][y - 1]].Equals("void"))
                        {
                            mapChunks[allChunkCoordinates[x][y - 1]] = string.Concat(mapChunks[allChunkCoordinates[x][y - 1]].Replace("b", "").OrderBy(c => c));
                        }
                    }
                }
            }

            for (int x = 0; x < MAPCHUNKSIZE; x++)
            {
                for (int y = 0; y < MAPCHUNKSIZE; y++)
                {
                    if (x < MAPCHUNKSIZE - 1 && mapChunks[allChunkCoordinates[x + 1][y]].Contains('l') && !mapChunks[allChunkCoordinates[x][y]].Contains('r'))
                    {
                        mapChunks[allChunkCoordinates[x][y]] = string.Concat((mapChunks[allChunkCoordinates[x][y]] + "r").OrderBy(c => c));
                    }
                    if (y < MAPCHUNKSIZE - 1 && mapChunks[allChunkCoordinates[x][y + 1]].Contains('h') && !mapChunks[allChunkCoordinates[x][y]].Contains('b'))
                    {
                        mapChunks[allChunkCoordinates[x][y]] = string.Concat((mapChunks[allChunkCoordinates[x][y]] + "b").OrderBy(c => c));
                    }
                    if (mapChunks[allChunkCoordinates[x][y]].Equals(""))
                    {
                        mapChunks[allChunkCoordinates[x][y]] = "o";
                    }
                }
            }
            using StreamWriter outputFile = new StreamWriter("map.txt");
            for (int y = 0; y < MAPCHUNKSIZE; y++)
            {
                for (int i = 0; i < 9; i++)
                {
                    for (int x = 0; x < MAPCHUNKSIZE; x++)
                    {
                        int[] clef = allChunkCoordinates[x][y];
                        string line = File.ReadLines("mapTemplates/" + mapChunks[clef] + ".txt").Skip(i).Take(1).First();
                        outputFile.Write(line);
                    }
                    outputFile.Write("\n");
                }
            }
            outputFile.Flush();
            outputFile.Close();
        }

        public static void ReadMap()
        {
            StreamReader reader = new("map.txt");
            for (int y = 0; y < YSIZE; y++)
            {
                for (int x = 0; x < XSIZE; x++)
                {
                    if (map[x] == null)
                    {
                        map[x] = new char[XSIZE];
                    }
                    map[x][y] = (char)reader.Read();
                }
            }
            reader.Close();
        }

        public static char[][] GetMap()
        {
            return map;
        }

        public static void EditMap(int x, int y, char val)
        {
            map[x][y] = val;
        }

        public static void DisplayMap()
        {
            Console.Clear();
            for (int y = 0; y < YSIZE; y++)
            {
                for (int x = 0; x < XSIZE; x++)
                {
                    Console.Write(map[x][y]);
                }
            }
        }

        public static void UpdateMapPlayerPos(Player player)
        {
            if (!wallChars.Contains(map[previousPlayerPosition[0]][previousPlayerPosition[1]]))
            {
                map[previousPlayerPosition[0]][previousPlayerPosition[1]] = ' ';
            }

            map[player.getPlayerXPos()][player.getPlayerYPos()] = playerToken;
        }

        public static int getXsize()
        {
            return XSIZE;
        }

        public static int getYsize()
        {
            return YSIZE;
        }

        public static char[] getWallChars()
        {
            return wallChars;
        }

        public static void setPreviousPlayerPos(int x, int y)
        {
            previousPlayerPosition[0] = x;
            previousPlayerPosition[1] = y;
        }

        public static bool isMapOk()
        {
            Console.WriteLine("Cette map vous convient-elle ? (O/N)");
            return Console.ReadLine()!.ToLower() switch
            {
                "o" => true,
                "oui" => true,
                "n" => false,
                "non" => false,
                _ => false,
            };
        }
    }
}