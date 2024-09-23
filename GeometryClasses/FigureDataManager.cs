using GeometryClasses.GeometryClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GeometryClasses
{
    public class FigureDataManager : IDataManager
    {
        private List<GeometryClass> _figureList = new List<GeometryClass>();
        private string _path = "C:\\Test\\figures.xml";

        public List<GeometryClass> FigureList
        {
            get { return _figureList; }
            set { _figureList = value; }
        }

       public bool AddFigure(GeometryClass f)
        {
            _figureList.Add(f);
            return true;
        }


        public bool CreateTestData()
        {
            var sq = new Square() { Edge = 0 };
            AddFigure(sq);
         //   var rec = new GeometryClasses.Rectangle();
        //    AddFigure(rec);
            return true;
        }

        public bool Load(string path)
        {
            if (File.Exists(_path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<GeometryClass>));
                using (TextReader reader = new StreamReader(_path))
                {
                    var f = (List<GeometryClass>)serializer.Deserialize(reader);
                    if (f != null && f is List<GeometryClass>) { _figureList = f; }
                }
            }
            return true;
        }

        public string Print()
        {
            throw new NotImplementedException();
        }

        public bool Reset()
        {
            throw new NotImplementedException();
        }

        public bool Save(string path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<GeometryClass>));
            using (TextWriter writer = new StreamWriter(_path))
            {
                serializer.Serialize(writer, _figureList);
            }
            return true;
        }
    }
}
