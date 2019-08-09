using System;
using System.Threading;

namespace CsSnake
{
    public static class InputManager
    {
        private static Thread inputManagmentThread;
        public static void Start(Snake snake)
        {
            inputManagmentThread = new Thread(() =>
            {
                while (true)
                {
                    snake.lastPressedKey = Console.ReadKey(true).Key;
                }
            });
            inputManagmentThread.Start();
        }
    }
}