using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClasses
{
    public class Polygon: GeometryClass
    {
        public Polygon()
        {
            _pointList = new List<Point>();
        }

        private List<Point> _pointList;

        public List<Point> Points
        {
            get { return _pointList; }
            set { _pointList = value; }
        }

        public void AddPoint(Point point) { _pointList.Add(point); }

        public override string? ToString()
        {
            var text = base.ToString() + " Points: ";
            foreach (Point p in Points)
            {
               // text += $"(x:{p.x}, y:{p.y})";
                text += $"({p})";
            }
            return text;
        }
    }
}
