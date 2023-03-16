using Custom_Method.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Method.Core.Models
{
    public class Teacher:Person
    {
        public readonly int Id;
        public static int CountTeacher = 0;
        public Teacher()
        {
            CountTeacher++;
            Id = CountTeacher;
        }
    }
}
