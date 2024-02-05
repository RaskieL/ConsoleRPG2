using System.Runtime.ConstrainedExecution;

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

        private const int XSIZE = MAPCHUNKSIZE * 24;
        private const int YSIZE = MAPCHUNKSIZE * 9;

        public static void generateMap(){
            for(int x = 0; x < MAPCHUNKSIZE; x++){
                for(int y = 0; y < MAPCHUNKSIZE; y++){
                    int[] chunkCoordinates = new int[2]{x,y};
                    if(mapChunks.Count() == 0){
                        mapChunks.Add(chunkCoordinates,"lhbr");
                    }else{
                        mapChunks.Add(chunkCoordinates,modularChunks[rnd.Next(0,9)][rnd.Next(0,9)]);
                    }
                }
            }
        }
    }
}