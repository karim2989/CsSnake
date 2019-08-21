using System;
using System.Numerics;
using System.Threading;

namespace CsSnake
{
    public static class Program
    {
        private static Vector2 minimumConsoleSize = new Vector2(30, 10);
        private static World world;
        public static World World{
            get{return world;}
        }
        public static Snake Snake{
            get{return snake;}
        }
        private static Snake snake;
        private static int tickRate = 5;
        static void Main(string[] args)
        {
            Console.Clear();
            Init();
            Start();
            while (true)
            {
                Update();
                Draw();
                //while (true)
                //{
                //    ConsoleKey input = Console.ReadKey().Key;
                //    if (input == ConsoleKey.Spacebar)
                //    {
                //        break;
                //    }
                //}
                Thread.Sleep(1000/tickRate);
            }
        }

        private static void Init()
        {
            //check console size
            Vector2 consoleSize = new Vector2(Console.WindowWidth, Console.WindowHeight);
            if (consoleSize.X < minimumConsoleSize.X || consoleSize.Y < minimumConsoleSize.Y)//consoleSize smaller than minimumConsoleSize
            {
                Console.WriteLine("Console is way too small to complete this operation.");
                Environment.Exit(-1);
            }
        }
        private static void Start()
        {
            Console.CursorVisible = false;
            world = new World(28, 8);
            snake = new Snake();
            world.RenderBorder();
            snake.Start();
            world.CreateFruit();
            InputManager.Start(snake);
        }
        private static void Update()
        {
            snake.Update();
        }
        private static void Draw()
        {
            world.Draw();
            snake.Draw();
        }
    }
}
