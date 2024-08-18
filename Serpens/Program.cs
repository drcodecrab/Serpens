using System;

namespace Serpens
{
    class Program
    {
        GameManager gameManager;
        static void Main()
        {
            Program program = new Program();
            program.gameManager = new GameManager();
            program.gameManager.RunGame();
        }
    }
}