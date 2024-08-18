using System;
using System.Collections.Generic;

namespace Serpens
{
    class Map
    {
        private int height;
        private int width;

        int[,] logicMap;

        List<Point> freePositions;
        public Map(int _height, int _width)
        {
            height = _height;
            width = _width;
            logicMap = new int[height,width];
            InitializeEmptyMap();
        }

        public void InitializeMatrix()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    logicMap[y, x] = 0;
                }
            }
        }

        public void InitializeMapBorder()
        {

            for (int j = 1; j < width - 1; j++) // der obere Rand, die Ecken werden ausgelassen
            {
                logicMap[0, j] = 21;
            }
            for (int i = 1; i < height - 1; i++) //der linke Rand, die Ecken werden ausgelassen
            {
                logicMap[i, 0] = 23;
            }
            for (int i = 1; i < height - 1; i++) //reihe rechts, wir lassen die ecken aus
            {
                logicMap[i, width - 1] = 23;
            }
            for (int i = 1; i < width - 1; i++) //der rahmen unten, ohne die ecken
            {
                logicMap[height - 1, i] = 21;
            }


            logicMap[0, 0] = 20; // oben links
            logicMap[0, width - 1] = 22; // oben rechts
            logicMap[height - 1, 0] = 24; // unten links
            logicMap[height - 1, width - 1] = 25; // unten rechts
        }

        public void InitializeEmptyMap()
        {
            InitializeMatrix();
            InitializeMapBorder();
        }

        public void UpdateMapWithFood(List<Food> _foods)
        {
            foreach (var item in _foods)
            {
                logicMap[item.point.y, item.point.x] = 40;
            }
        }

        public void UpdateMapWithSnake(Snake mySnake)
        {
            foreach (var item in mySnake.points)
            {
                if (item.x < width - 1 && item.x > 0 && item.y < height - 1 && item.y > 0)
                {
                    SetSnakeData(item);
                }
                else
                {
                    mySnake.isAlive = false;
                }
            }
        }
        public void SetSnakeData(Point snakePoint)
        {
                logicMap[snakePoint.y, snakePoint.x] = 30;
        }

        public List<Point> GetFreePositions()
        {
            List<Point> free_positions = new List<Point>();

            for (int y = 1; y < height-1; y++)
            {
                for (int x = 1; x < width-1; x++)
                {
                    if (logicMap[y, x] == 0)
                    {
                        free_positions.Add(new Point(x, y));
                    }
                }
            }
            return free_positions;
        }

        public void Draw()
        {
            
            
            for (int y = 0; y < height; y++) // in die Nächste Zeile Wechseln
            {
                for (int x = 0; x < width; x++) // einmal die Zeile durchlaufen
                {
                    
                    Console.SetCursorPosition(x, y); 
                    if (logicMap[y, x] == 0)
                    {
                        Console.Write("\x1b[48;2;173;216;230m \x1b[0m");
                     //   Console.Write("\x1b[0m\n");
                    }
                    if (logicMap[y, x] == 21)
                    {
                        Console.Write("\x1b[31m═\x1b[0m");
                    }
                    if (logicMap[y, x] == 23)
                    {
                        Console.Write("\x1b[31m║\x1b[0m");
                    }
                    if (logicMap[y, x] == 20) // oben links, die Ecke
                    {
                        Console.Write("\x1b[31m╔\x1b[0m");
                       
                    }
                    if (logicMap[y, x] == 22) // oben rechts, die Ecke
                    {
                        Console.Write("\x1b[31m╗\x1b[0m");
                    }
                    if (logicMap[y, x] == 24) // unten links, die Ecke
                    {
                        Console.Write("╚");
                        Console.Write("\x1b[31m╚\x1b[0m"); // für rote Farbe
                    }
                    if (logicMap[y, x] == 25) // unten rechts, die Ecke
                    {
                        Console.Write("\x1b[31m╝\x1b[0m");
                    }
                    if (logicMap[y,x] == 30)
                    {
                        Console.Write("\x1b[93m█\x1b[0m");
                    }
                    if (logicMap[y, x] == 40)
                    {
                        Console.Write("\x1b[48;2;173;216;230m\x1b[38;5;17m@\x1b[0m");
                        //    Console.Write("\x1b[32m@");
                    }

                }
                Console.Write("\n"); // einen Absatz machen
            }
        }
    }
}
