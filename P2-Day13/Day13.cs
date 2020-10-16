using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle
{
    /*
        The "Point" Class for creating a problem specific structure.
    */
    class Point
    {
        private double _x;
        private double _y;
        
        public Point(){} // Default Constructor
        /*
            X and Y variables in this contructor
        */
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }
        /*
            This utility function to find square of distance from point 'p1' to point 'p2' 
        */
        public static double calculateDistance(Point p1, Point p2)
        {
            double x = (p2._x - p1._x);
            double y = (p2._y - p1._y);
            return Math.Pow(x, 2) + Math.Pow(y, 2);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            // Points
            Point p1 = new Point(10, 20);
            Point p2 = new Point(20, 10);
            Point p3 = new Point(10, 10);
            Point p4 = new Point(20, 20);

            /* Array of Point Class Type */
            Point[] pointArr = { p1, p2, p3, p4 };
            Console.WriteLine(isSquare(pointArr));
            
            Console.ReadKey();
        }

        static string isSquare(Point[] pointArr)
        {
            bool flag = false;
            // distances
            double distance2 = Point.calculateDistance(pointArr[0], pointArr[1]); // from p1 to p2
            double distance3 = Point.calculateDistance(pointArr[0], pointArr[2]); // from p1 to p3
            double distance4 = Point.calculateDistance(pointArr[0], pointArr[3]); // from p1 to p4

            // eğer mesafeler arası fark 0 ise iki nokta aynı yerdedir
            // bu yüzden kare oluşmaz
            if (distance2 == 0 || distance3 == 0 || distance4 == 0)
            {
                flag = false;
            }
            // If lengths if (p1, p2) and (p1, p3) are same, then 
            // following conditions must met to form a square. 
            // 1) Square of length of (p1, p4) is same as twice 
            // the square of (p1, p2) 
            // 2) Square of length of (p2, p3) is same 
            // as twice the square of (p2, p4) 
            if (distance2 == distance3 && 2 * distance2 == distance4
                && 2 * Point.calculateDistance(pointArr[1], pointArr[3]) ==
                Point.calculateDistance(pointArr[1], pointArr[3]))
            {
                flag = true;
            }
            if (distance3 == distance4 && 2 * distance3 == distance2
                && 2 * Point.calculateDistance(pointArr[2], pointArr[1]) ==
                Point.calculateDistance(pointArr[2], pointArr[3]))
            {
                flag = true;
            }
            if (distance2 == distance4 && 2 * distance2 == distance3
                && 2 * Point.calculateDistance(pointArr[1], pointArr[2]) ==
                Point.calculateDistance(pointArr[1], pointArr[3]))
            {
                flag = true;
            }
            return flag == true ? "Yes is square." : "Not Square";
        }

        static bool isCircle(Point[] pointArr)
        {
            // continues..
            Point center = new Point(0, 0);
            return false;
        }
    }
}
