using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses { get; set; }

        public ParttimeStudent(string name) : base(name)
        {
            
        }
        public override string ToString()
        {
            return $"{Id} – {Name} (Part-time Student)";
        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new InvalidOperationException($"Part-time students cannot register for more than {MaxNumOfCourses} courses.");
            }

            base.RegisterCourses(selectedCourses);
        }
    }

}