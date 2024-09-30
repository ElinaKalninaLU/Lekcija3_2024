using GeometryClasses.GeometryClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GeometryClasses
{
    public class GeometryDataManager : IDataManager, IAddFigure
    {
        public List<GeometryClass> figures { get; set; } 
            = new List<GeometryClass>();
        //private string _path = "C:\\Temp\\figures.xml";
        private string _path = @"C:\Temp\figures.xml";

        public bool CreateTestData()
        {
            var sq1 = new Square(5);
            var sq2 = new Square() { Edge = 6 };
            var rt1 = new Rectangle() { Width = 2, Height = 3 };
            figures.Add(sq1);
            figures.Add(sq2);
            figures.Add(rt1);
            figures.Add(new Rectangle() { Width = 5, Height = 6 });
            //          figures = new List<GeometryClass>() { sq1, sq2 , rt1, new Rectangle() { Width = 5, Height = 6 } };
            var po = new Polygon();
            po.AddPoint(new Point() { x = 3, y = 5 });
            po.AddPoint(new Point() { x = 4, y = 1 });
            po.AddPoint(new Point() { x = 1, y = 1 });
            po.AddPoint(new Point() { x = 0, y = 0 });
            figures.Add(po);
            return true;
        }

        public bool Load()
        {
            if (File.Exists(_path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<GeometryClass>));
                using (TextReader reader = new StreamReader(_path))
                {
                    var f = (List<GeometryClass>)serializer.Deserialize(reader);
                    if (f != null && f is List<GeometryClass>) { figures = f; }
                }
                return true;
            }
            return false;
        }

        public string Print()
        {
            string text = "";
            foreach (var f in figures)
            {
                text += f.ToString() + Environment.NewLine;
            }
            return text;
        }

        public bool Reset()
        {
           // figures = new List<GeometryClass>();
            figures.Clear();
            return true;
        }

        public bool Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<GeometryClass>));
            using (TextWriter writer = new StreamWriter(_path))
            {
                serializer.Serialize(writer, figures);
            }
            return true;
        }

        public bool AddFigure(GeometryClass f)
        {
            if (f != null)
            {
                figures.Add(f);
                return true;
            }
            else return false;
            
        }
    }
}
