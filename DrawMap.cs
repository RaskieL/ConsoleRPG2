using System.Runtime.ConstrainedExecution;
using System.IO;

namespace ConsoleRPG2{

    public static class DrawMap{

        private static string[] rightConnectors = new string[8]{"r","lr","lrb","lrh","lhbr","rh","rhb","rb"};
        private static string[] topConnectors = new string[8]{"h","lh","lrh","lhb","lhbr","rh","rhb","hb"};
        private static string[] bottomConnectors = new string[8]{"b","lb","lrb","lhb","lhbr","rhb","rb","hb"};
        private static string[] leftConnectors = new string[8]{"l","lb","lr","lrb","lrh","lh","lhb","lhbr"};

        private static string[][] modularChunks = new string[4][]{rightConnectors, topConnectors, bottomConnectors, leftConnectors};

        private static Dictionary<int[],string> mapChunks = new Dictionary<int[],string>();

        private static string playerToken = "o";

        private static Random rnd = new Random();

        private const int MAPCHUNKSIZE = 16;

        private const int XSIZE = MAPCHUNKSIZE * 28;
        private const int YSIZE = MAPCHUNKSIZE * 9;


        public static void generateMap(){
            int[][][] allChunkCoordinates = new int[MAPCHUNKSIZE][][];
            for(int x = 0; x < MAPCHUNKSIZE; x++){
                allChunkCoordinates[x] = new int[MAPCHUNKSIZE][];
                for(int y = 0; y < MAPCHUNKSIZE; y++){
                    int[] chunkCoordinates = new int[]{x,y};
                    allChunkCoordinates[x][y] = chunkCoordinates;
                    if(mapChunks.Count() == 0){
                        mapChunks.Add(chunkCoordinates,"lhbr");
                    }else{
                        int rndvalue1 = rnd.Next(0,4);
                        int rndvalue2 = rnd.Next(0,8);
                        mapChunks.Add(chunkCoordinates,modularChunks[rndvalue1][rndvalue2]);
                    }
                }
            }

            using (StreamWriter outputFile = new StreamWriter("map.txt"))
            {
                for(int y = 0; y < MAPCHUNKSIZE; y++){
                    for(int i = 0; i < 9; i++){
                        for(int x = 0; x < MAPCHUNKSIZE; x++){
                            int[] clef = allChunkCoordinates[x][y];
                            string line = File.ReadLines("mapTemplates\\" + mapChunks[clef]+".txt").Skip(i).Take(1).First();
                            outputFile.Write(line);

                        }
                        outputFile.Write("\n");
                    }
                    
                }

            }
        }


    }
}