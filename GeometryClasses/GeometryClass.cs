using GeometryClasses.GeometryClasses;
using System.Xml.Serialization;

namespace GeometryClasses
{
    [XmlInclude(typeof(Square))]
    public abstract class GeometryClass
    {
        public string Name { get; set; }

        public override string? ToString()
        {
           //  return base.ToString() + " " + Name;
            return "Name: " + Name + " Perimeter: " + Perimeter().ToString() + " Area: " + Area.ToString();
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
    }
}
