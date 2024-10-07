using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace GeometryClasses
    {
        public class Square : GeometryClass
        {
            private int edge;

            public int Edge
            {
                get { return edge; }
                set
                {
                    if (value > 0)
                    { edge = value; }
                    else
                    {  throw new ArgumentOutOfRangeException(); }
                }
            }

            public Square(int _edge)
            {
                Edge = _edge;
            }

            public Square()
            {
                Edge = 5;
            }

            public override int Perimeter()
            {
                return 4 * Edge;
            }

            public override int Area => Edge * Edge;

            public override string? ToString()
            {
                return "Square; Edge: " + Edge + " " + base.ToString();
            }

        
        }
    }