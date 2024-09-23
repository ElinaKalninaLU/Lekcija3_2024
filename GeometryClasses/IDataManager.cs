using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryClasses
{
    public interface IDataManager
    {
        public string Print();

        public bool Save(string path);

        public bool Load(string path);

        public bool CreateTestData();

        public bool Reset();

    }
}
