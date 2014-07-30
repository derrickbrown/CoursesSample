using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesLibrary
{
    public class CourseCategory
    {
        public String Title { get; internal set; }

        public String Description { get; internal set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
