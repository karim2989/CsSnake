using System;
namespace CsSnake
{
    public class World
    {
        public Cords Fruit;
        private ConsoleColor fruitColor = ConsoleColor.DarkRed;
        public World(int width, int height)
        {
            size = new Cords(width, height);
        }
        public Cords size;

        public void RenderBorder()
        {
            string topBorder = "┏";
            for (int i = 0; i < size.x; i++)
            {
                topBorder += "━";
            }
            topBorder += "┓";

            Console.SetCursorPosition(0, 0);
            Console.Write(topBorder);
            string bottomBorder = "┗";
            for (int i = 0; i < size.x; i++)
            {
                bottomBorder += "━";
            }
            bottomBorder += "┛";
            Console.SetCursorPosition(0, size.y + 1);
            Console.Write(bottomBorder);
            string verticalBorder = "┃";
            for (int i = 1; i < size.y + 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write(verticalBorder);
                Console.SetCursorPosition(size.x + 1, i);
                Console.Write(verticalBorder);
            }

        }
        public void Draw()
        {
            Console.SetCursorPosition(Fruit.x, Fruit.y);
            Console.ForegroundColor = fruitColor;
            Console.Write('$');
            Console.SetCursorPosition(0, 11);
            Console.Write($" fruit : {Fruit.x},{Fruit.y}");
        }
        public void CreateFruit()
        {
            Cords chosenCords;
            while (true)
            {
                Random rngGenerator = new Random();
                chosenCords.x = rngGenerator.Next(1, size.x);
                chosenCords.y = rngGenerator.Next(1, size.y);

                foreach (Cords C in Program.Snake.BlocksOccupied)
                {
                    if (C == chosenCords)
                    {
                        continue;
                    }
                }
                break;
            }
            Fruit = chosenCords;
        }
    }
}