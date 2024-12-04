using System.ComponentModel.DataAnnotations;

namespace GeometryClasses
{
    //public struct Point
    //{
    //    public int x, y;
    //}

    //    public record struct Point(int x, int y);

    public class Point
    {
        [Key]
        public int ID { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public Point()
        { }

        public Point(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public override string ToString()
        {
            return $"Point: x:{x}, y:{y}";
        }
    }

}