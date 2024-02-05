using System.Runtime.ConstrainedExecution;
using System.IO;
using System.Net.Mail;

namespace ConsoleRPG2{

    public static class DrawMap{

        private static string[] rightConnectors = new string[8]{"r","lr","blr","hlr","bhlr","hr","bhr","br"};
        private static string[] topConnectors = new string[8]{"h","hl","hlr","bhl","bhlr","hr","bhr","bh"};
        private static string[] bottomConnectors = new string[8]{"b","bl","blr","bhl","bhlr","bhr","br","bh"};
        private static string[] leftConnectors = new string[8]{"l","bl","lr","blr","hlr","hl","bhl","bhlr"};

        private static string[][] modularChunks = new string[4][]{rightConnectors, topConnectors, bottomConnectors, leftConnectors};
        private static Dictionary<int[],string> mapChunks = new Dictionary<int[],string>();
        private static char[][] map = new char[XSIZE][];

        private const string playerToken = "o";

        private static Random rnd = new Random();

        private const int MAPCHUNKSIZE = 8;

        private const int XSIZE = MAPCHUNKSIZE * 26+1;
        private const int YSIZE = MAPCHUNKSIZE * 9;


        public static void generateMap(){
            int[][][] allChunkCoordinates = new int[MAPCHUNKSIZE][][];

            for(int x = 0; x < MAPCHUNKSIZE; x++){

                allChunkCoordinates[x] = new int[MAPCHUNKSIZE][];
                for(int y = 0; y < MAPCHUNKSIZE; y++){

                    int[] chunkCoordinates = new int[]{x,y};
                    allChunkCoordinates[x][y] = chunkCoordinates;

                    if(mapChunks.Count == 0){
                        mapChunks.Add(chunkCoordinates,"r");

                    }else{
                        int rndvalue1 = rnd.Next(0,4);
                        int rndvalue2 = rnd.Next(0,8);
                        string chunk = modularChunks[rndvalue1][rndvalue2];
                        if(x > 0 && mapChunks[allChunkCoordinates[x-1][y]].Contains('r') && !chunk.Contains('l')){
                            Console.WriteLine($"Raccordement de {x},{y} et {x-1},{y} avec un l");
                            chunk += "l";
                        }
                        if(y > 0 && mapChunks[allChunkCoordinates[x][y-1]].Contains('b') && !chunk.Contains('h')){
                            Console.WriteLine($"Raccordement de {x},{y} et {x},{y-1} avec un h");
                            chunk += "h";
                        }

                        if(y == 0 && chunk.Contains('h')){
                            chunk = chunk.Replace("h", "");
                        }
                        if(y == MAPCHUNKSIZE-1 && chunk.Contains('b')){
                            chunk =chunk.Replace("b", "");
                        }
                        if(x == 0 && chunk.Contains('l')){
                            chunk =chunk.Replace("l", "");
                        }
                        if(x == MAPCHUNKSIZE-1 && chunk.Contains('r')){
                            chunk =chunk.Replace("r", "");
                        }
                        chunk = string.Concat(chunk.OrderBy(c => c));

                        mapChunks.Add(chunkCoordinates,chunk);
                    }
                }
            }

            for(int x = 0; x < MAPCHUNKSIZE; x++){
                for(int y = 0; y < MAPCHUNKSIZE; y++){
                    if(x < MAPCHUNKSIZE-1 && mapChunks[allChunkCoordinates[x+1][y]].Contains('l') && !mapChunks[allChunkCoordinates[x][y]].Contains('r')){
                            Console.WriteLine($"Raccordement de {x},{y} et {x+1},{y} avec un r");
                            mapChunks[allChunkCoordinates[x][y]] = string.Concat((mapChunks[allChunkCoordinates[x][y]]+"r").OrderBy(c => c));
                        }
                    if(y < MAPCHUNKSIZE-1 && mapChunks[allChunkCoordinates[x][y+1]].Contains('h') && !mapChunks[allChunkCoordinates[x][y]].Contains('b')){
                        Console.WriteLine($"Raccordement de {x},{y} et {x},{y+1} avec un b");
                        mapChunks[allChunkCoordinates[x][y]] = string.Concat((mapChunks[allChunkCoordinates[x][y]]+"b").OrderBy(c => c));
                    }
                    if(mapChunks[allChunkCoordinates[x][y]].Equals("")){
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
                        string line = File.ReadLines("mapTemplates\\" + mapChunks[clef] + ".txt").Skip(i).Take(1).First();
                        outputFile.Write(line);
                    }
                    outputFile.Write("\n");
                }
            }

        }

        public static void ReadMap(){
            StreamReader reader = new("map.txt");
            for(int x = 0; x < XSIZE; x++){
                map[x] = new char[XSIZE];
                for(int y = 0; y < YSIZE; y++){
                    map[x][y] = (char)reader.Read();
                }
            }
        }

        public static void DisplayMap(){
            for(int x = 0; x < XSIZE; x++){
                for(int y = 0; y < YSIZE; y++){
                    Console.Write(map[x][y]);
                }
            }
        }
    }
}