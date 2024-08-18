using System;

namespace Serpens
{
    class InputManager
    {
        ConsoleKeyInfo key;
        public void GetUserInput()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.W:
                        if (GlobalVars.aktuelleRichtung != Bewegungsrichtung.unten)
                        {
                            GlobalVars.aktuelleRichtung = Bewegungsrichtung.oben;
                        }
                        break;
                    case ConsoleKey.A:
                        if (GlobalVars.aktuelleRichtung != Bewegungsrichtung.rechts)
                        {
                            GlobalVars.aktuelleRichtung = Bewegungsrichtung.links;
                        }
                        break;
                    case ConsoleKey.S:
                        if (GlobalVars.aktuelleRichtung != Bewegungsrichtung.oben)
                        {
                            GlobalVars.aktuelleRichtung = Bewegungsrichtung.unten;
                        }
                        break;
                    case ConsoleKey.D:
                        if (GlobalVars.aktuelleRichtung != Bewegungsrichtung.links)
                        {
                            GlobalVars.aktuelleRichtung = Bewegungsrichtung.rechts;
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
