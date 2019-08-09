using System;
using System.Linq;
namespace CsSnake
{
    public class Snake
    {
        public ConsoleColor Color = ConsoleColor.White;
        public Cords[] BlocksOccupied
        {
            get { return blocksOccupied; }
        }
        private Cords head;
        private Cords[] blocksOccupied;
        private Cords previousBlockOccupied;
        public ConsoleKey lastPressedKey;
        private Cords direction = Cords.right;
        public int Length
        {
            get { return blocksOccupied.Length; }
        }
        public void Start()
        {
            head = new Cords(5, 2);
            blocksOccupied = new Cords[3] { head, head + Cords.left, head + (Cords.left * 2) };
        }
        public void Update()
        {
            previousBlockOccupied = blocksOccupied[0];
            #region InputManagment
            switch (lastPressedKey)
            {
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    {
                        if (direction != Cords.up)
                        {
                            direction = Cords.down;
                        }
                    }
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    {
                        if (direction != Cords.down)
                        {
                            direction = Cords.up;
                        }
                    }
                    break;
                case ConsoleKey.A:
                case ConsoleKey.RightArrow:
                    {
                        if (direction != Cords.right)
                        {
                            direction = Cords.left;
                        }
                    }
                    break;
                case ConsoleKey.D:
                case ConsoleKey.LeftArrow:
                    {
                        if (direction != Cords.left)
                        {
                            direction = Cords.right;
                        }
                    }
                    break;
            }
            #endregion

            head += direction;
            for (int i = 0; i < Length - 1; i++)
            {
                blocksOccupied[i] = blocksOccupied[i + 1];
            }
            blocksOccupied[Length - 1] = this.head;
            #region CollitionDetecion
            //collition with the border
            if (head.x < 1 || head.y < 1 || head.x > Program.World.size.x || head.y > Program.World.size.y)
            {
                Loose();
            }
            //collition with the tail
            for (int i = 0; i < Length - 1; i++)//length-1 because blocksOccupied[Length] is the head itself
            {
                if (head == BlocksOccupied[i])
                {
                    Loose();
                }
            }
            //colition with the fruit
            if (head == Program.World.Fruit)
            {
                this.Grow();
                Program.World.CreateFruit();
            }
            #endregion
        }

        private void Grow()
        {
            Cords[] oldBlocksOccupied = blocksOccupied;
            blocksOccupied = new Cords[1]{previousBlockOccupied}.Concat(oldBlocksOccupied).ToArray();
        }

        private void Loose()
        {
            Console.SetCursorPosition(0, Program.World.size.y + 2);
            Console.Write("You lost.");
            this.Draw();
            Environment.Exit(0);
        }
        public void Draw()
        {
            Console.ForegroundColor = this.Color;

            Console.SetCursorPosition(previousBlockOccupied.x, previousBlockOccupied.y);
            Console.Write(" ");

            for (int i = 0; i < Length; i++)
            {
                Console.SetCursorPosition(blocksOccupied[i].x, blocksOccupied[i].y);
                Console.Write("●");
            }
            Console.SetCursorPosition(head.x, head.y);
            Console.Write("◎");

            //Console.SetCursorPosition(Console.WindowWidth + 1, 10);
            Console.SetCursorPosition(0, 10);
            Console.Write($"{head.x} ; {BlocksOccupied[0].x},{BlocksOccupied[1].x},{BlocksOccupied[2].x}");
        }
    }
}