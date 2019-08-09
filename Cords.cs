namespace CsSnake
{
    public struct Cords
    {
        public Cords(int width, int height)
        {
            x = width;
            y = height;
        }
        public int x;
        public int y;

        //Operator Override

        public static Cords operator +(Cords a, Cords b)
    => new Cords(a.x + b.x, a.y + b.y);
        public static Cords operator -(Cords a, Cords b)
    => new Cords(a.x - b.x, a.y - b.y);
        public static Cords operator *(Cords a, Cords b)
    => new Cords(a.x * b.x, a.y * b.y);
        public static Cords operator *(Cords a, int b)
    => new Cords(a.x * b, a.y * b);
        public static bool operator ==(Cords a, Cords b)
    => a.x == b.x && a.y == b.y;
        public static bool operator !=(Cords a, Cords b)
    => a.x != b.x || a.y != b.y;

        public override bool Equals(object obj)
        {
            if (obj.GetType() == this.GetType())
            {
                if ((Cords)obj == this)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return -1;
        }

        //Static Propreties

        public static Cords right
        {
            get { return new Cords(1, 0); }
        }
        public static Cords left
        {
            get { return new Cords(-1, 0); }
        }
        public static Cords up
        {
            get { return new Cords(0, 1); }
        }
        public static Cords down
        {
            get { return new Cords(0, -1); }
        }
    }
}