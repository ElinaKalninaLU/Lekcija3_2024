using GeometryClasses.GeometryClasses;
using System.Xml.Serialization;

namespace GeometryClasses
{
    [XmlInclude(typeof(Square))]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Polygon))]
    public abstract class GeometryClass
    {
        public string Name { get; set; }

        public override string? ToString()
        {
            //  return base.ToString() + " " + Name;
            return "Name: " + Name + " Perimeter: " + Perimeter().ToString() + " Area: " + Area.ToString() + " Colour: " + figureColour.ToString();
        }

        public string izdruka()
        {
            return  " Name " + Name;
        }

        public virtual int Perimeter()
        {
            return 0;
        }

        public virtual int Area { get; }

         public Colour figureColour { get; set; } = Colour.Black;
    }
}
