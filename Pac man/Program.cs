using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_man
{
    class Program
    {
        static void Main(string[] args)
        {
            int mapY = 15;
            int mapX = 10;
            string[,] map = new string[0, 0];
            int zmogausX = 0;
            int zmogausY = 0;
            int taskai = 0;
            int saldainiai = 0;


            map = MapSukurimas(mapX, mapY);
            saldainiai = IsVisoSaldainiu(mapX, mapY, map);

            while (taskai < saldainiai)
            {
                Console.Clear();

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine("Jusu siuo metu surinkti saldainiukai: " + taskai);
                Console.WriteLine("Is viso saldainiu yra: " + saldainiai);
                Console.WriteLine("---------------------------------------------");

                MapAtspausdinimas(mapX, mapY, map, zmogausX, zmogausY);

                int[] naujaZmogausPozicija = ZmogausJudinimas(zmogausX, zmogausY, mapX, mapY);

                zmogausX = naujaZmogausPozicija[0]; //grizta X
                zmogausY = naujaZmogausPozicija[1]; //grizta Y

                taskai = TaskuSkaiciavimas(taskai,zmogausX,zmogausY,map);
                map = SaldainioIstrinimas(zmogausX,zmogausY,map);

            }
            Console.Clear();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Jusu siuo metu surinkti saldainiukai: " + taskai);
            Console.WriteLine("Is viso saldainiu yra: " + saldainiai);
            Console.WriteLine("---------------------------------------------");

            MapAtspausdinimas(mapX, mapY, map, zmogausX, zmogausY);


            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Saldainiu nebera :( Zaidimas baigtas");
            Console.ReadLine();
            
        }
        public static int IsVisoSaldainiu(int mapX, int mapY, string [,] map)
        {
            int saldainiai = 0;

            for (int i = 0; i < mapY; i++)
            {
                for (int j = 0; j < mapX; j++)
                {
                    if (map[i, j] == " o ")
                    {
                        saldainiai++;
                    }
                }
            }    

                return saldainiai;
        }
        public static string [,] SaldainioIstrinimas(int zmogausX, int zmogausY, string[,] map)
        {
            if (arYraSaldainis(zmogausX, zmogausY, map))
            {
                map[zmogausY, zmogausX] = " _ ";  
            }

            return map;
        }
        public static int TaskuSkaiciavimas(int taskai, int zmogausX, int zmogausY, string[,] map)
        {

            if (arYraSaldainis(zmogausX, zmogausY, map))
            {
                taskai++;
            }
            return taskai;
        }

        public static bool arYraSaldainis(int zmogausX, int zmogausY, string[,] map)
        {
            if (map[zmogausY, zmogausX] == " o ")
              return true;
            else
                return false;
        }
    
        public static int[] ZmogausJudinimas(int zmogausX, int zmogausY, int mapX, int mapY)
        {
            
                ConsoleKeyInfo btn = Console.ReadKey();

            if (btn.Key.ToString() == "RightArrow")
            {
                if (zmogausX + 1 < mapX)
                {
                    zmogausX++;
                }

            }
            else if (btn.Key.ToString() == "LeftArrow")
            {
                if (zmogausX - 1 >= 0)
                {
                    zmogausX--;
                }
            }
            else if (btn.Key.ToString() == "DownArrow")
            {
                if (zmogausY + 1 < mapY)
                {
                    zmogausY++;
                }
            }
            else if (btn.Key.ToString() == "UpArrow")
            {
                if (zmogausY - 1 >= 0)
                {
                    zmogausY--;
                }
            }

            int[] naujaZmogausPozicija = new int[2];
            naujaZmogausPozicija[0] = zmogausX;
            naujaZmogausPozicija[1] = zmogausY;
            
            return naujaZmogausPozicija;
               
            
        }

        public static string [,] MapSukurimas(int mapX, int mapY)
        {
            string[,] map = new string[mapY, mapX]; //[eilutes(zemyn), stulpeliai(i sona)]

            Random rnd = new Random();

            for (int i = 0; i < mapY; i++)
            {
                for (int j = 0; j < mapX; j++)
                {
                    int sk = rnd.Next(0, 2);
                    if (sk == 0 || (i == 0 && j == 0))
                        map[i, j] = " _ ";

                    else if (sk == 1)
                        map[i, j] = " o ";
                }
            }
            return map;
        }

        public static void MapAtspausdinimas(int mapX, int mapY, string [,] map, int zmogausX, int zmogausY)
        {
         //Atspausdiname
          for (int i = 0; i < mapY; i++)
          {
              for (int j = 0; j < mapX; j++)
              {
                    if (j == zmogausX && i == zmogausY)
                        Console.Write(" X ");   
                    else
                        Console.Write(map[i, j]);
              }
               Console.WriteLine();
          }
            
        }

    }

}
