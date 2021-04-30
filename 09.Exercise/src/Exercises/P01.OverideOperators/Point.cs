namespace P01.OverideOperators
{
    public struct Point
    {
        public Point(decimal x, decimal y)
        {
            this.X = x;
            this.Y = y;
        }

        public decimal X { get; private set; }

        public decimal Y { get; private set; }

        public static Point operator +(Point a, Point b)
        {
            decimal x = a.X + b.X;
            decimal y = a.Y + b.Y;

            var point = new Point(x, y);

            return point;
        }

        public static Point operator -(Point a, Point b)
        {
            decimal x = a.X - b.X;
            decimal y = a.Y - b.Y;

            var point = new Point(x, y);

            return point;
        }

        public static bool operator ==(Point a, Point b)
        {
            bool isEquals = a.X == b.X && a.Y == b.Y;

            return isEquals;
        }

        public static bool operator !=(Point a, Point b)
        {
            bool isEquals = a.X != b.X && a.Y != b.Y;

            return isEquals;
        }

        public override int GetHashCode()
        {
            int hash = ((int)this.X << 2) ^ (int)this.Y;

            return hash;
        }

        public override bool Equals(object obj)
        {
            bool isInvalid = obj == null || this.GetType().Name != obj.GetType().Name; ;

            if (isInvalid)
            {
                return false;
            }

            var point = (Point)obj;

            bool isEquals = this.X == point.X && this.Y == point.Y;

            return isEquals;
        }

        public override string ToString()
        {
            string pointAsString = $"({this.X}, {this.Y})";

            return pointAsString;
        }
    }
}
