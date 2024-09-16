using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClasses
{
    public class Rectangle: GeometryClass
    {
		private int _height;

		public int Height
		{
			get { return _height; }
			set {
				if (value > 0)
				{
					_height = value;
				}
			
			}
		}

		private int _width;

		public int Width
		{
			get { return _width; }
			set {
				if (value > 0)
				{
					_width = value;
				}
			}
		}

		//Overrides
        public override string? ToString()
        {
            return base.ToString() + " Height: " +Height + " Width: " +Width;
        }

		//Hides
        public string izdruka()
        {
            return " Height: " + Height + " Width: " + Width;
        }

		public override int Perimeter()
		{
			return 2 * Height + 2 * Width;
		}

		public override int Area => Height * Width;
	}
}
