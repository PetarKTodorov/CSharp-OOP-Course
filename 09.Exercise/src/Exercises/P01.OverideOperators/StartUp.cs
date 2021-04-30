namespace P01.OverideOperators
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var pointA = new Point(2, 2);
            var pointB = new Point(2, 2);

            var pointC = pointA == pointB;

            pointA.GetHashCode();
            pointB.GetHashCode();

            var isEquals = pointA.Equals(pointB);

            Console.WriteLine(isEquals);
        }
    }
}
