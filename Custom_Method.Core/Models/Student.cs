using Custom_Method.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom_Method.Core.Models
{
    public class Student : Person
    {
        public readonly int Id;
        public static int CountStudent = 0;
        public Student()
        {
            CountStudent++;
            Id = CountStudent;
        }
    }
}
