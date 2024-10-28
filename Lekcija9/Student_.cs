using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lekcija9
{
    public partial class Student
    {
        public override string? ToString()
        {
            return $"StudentID: {StudentId}, Name: {Name}, Surname: {Surname}";

        }
    }
}
