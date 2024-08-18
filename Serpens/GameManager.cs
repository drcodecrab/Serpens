using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serpens
{
    class GameManager
    {
        const int gameHeight = 18;
        const int gameWidth = 28;
        const float delayTime = 90.4f;
        int startX = 5, startY = 5, startSize = 8, maxFoodsNumber = 3;

        TimeSpan stepIntervall = TimeSpan.FromMilliseconds(delayTime);
        Map myMap;
        Snake anaconda;
        Stopwatch stopwatch;
        InputManager inputManager;
        List<Food> foods; 


        public void RunGame()
        {
            Initialize();

            while (true)
            {
                if (stopwatch.Elapsed >= stepIntervall) // zeit von der stoppuhr >= delay
                {
                    Input();
                    Update();
                    Draw();
                    stopwatch.Restart();
                }
            }
        }

        public void Initialize()
        {
            anaconda = new Snake(startX, startY, startSize);
            stopwatch = new Stopwatch();
            myMap = new Map(gameHeight, gameWidth);
            inputManager = new InputManager();
            foods = new List<Food>();

            GlobalVars.aktuelleRichtung = Bewegungsrichtung.rechts;
            stopwatch.Start();
            anaconda.Update();
            myMap.UpdateMapWithSnake(anaconda);

        }
        public void CreateFood()
        {
            Random rnd = new Random();
            List<Point> free_positions = myMap.GetFreePositions();
            int randomIndex = rnd.Next(free_positions.Count);

            if (foods.Count < maxFoodsNumber)
            {
               foods.Add(new Food(free_positions[randomIndex].x, free_positions[randomIndex].y));
            }
        }

        public void DeleteEatenFood()
        {
            foods.RemoveAll(food => food.eaten);
        }
        public void InteractSnakeAndFood()
        {
            foreach (var food in foods)
            {
                if (food.point.x == anaconda.points[anaconda.points.Count - 1].x && 
                    anaconda.points[anaconda.points.Count - 1].y == food.point.y)
                {
                    anaconda.isEating = true;
                    food.eaten = true;
                    Console.Beep(400, 80);
                }
            }
        }

        public void Input()
        {
            inputManager.GetUserInput();
        }
        public void Update()
        {
            inputManager.GetUserInput(); // Eingabe des Benutzers
            myMap.InitializeEmptyMap(); ; // Erstellt eine Leere Map
            myMap.UpdateMapWithSnake(anaconda); // Erstellt den Rahmen in der Map
            myMap.UpdateMapWithFood(foods); // Übergibt der Map die Spawnpunkte für das Essen
            CreateFood(); // Anhand der freien Flächen auf der Map wird Futter erstellt
            InteractSnakeAndFood(); // Wenn die Schlange eine Futterposition erreicht,
                                    // wird die Flag "isEating" auf true gesetzt
            if (anaconda.isAlive) // Wenn die Schlange lebt dann...
            {
                anaconda.Update(); // Bewegung immer durch ein neues Element vorne,
                                   // hintere Teil immer weglassen, außer bei "isEating" = true
                anaconda.isEating = false;
            }
            else
            {
                Console.Beep(180, 200);
                Console.Beep(140, 200);
                Console.Beep(120, 200);
                Initialize(); // wenn †, dann Initialisieren wir das Game neu, (Neustart)
            }

            DeleteEatenFood();

        }

        public void Draw()
        {
            myMap.Draw(); //Zeichnet die Gesamte Map
        }
    }
}