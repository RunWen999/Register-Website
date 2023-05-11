using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }
        public static int MaxNumOfCourses { get; set; }

        public CoopStudent(string name) : base(name)
        {
             
        }

        public override string ToString()
        {
            return $"{Id} – {Name} (Coop Student)";
        }
        public override void RegisterCourses(List<Course> selectedCourses)
        {

            int totalHour = 0;
            foreach (Course course in selectedCourses)
            {
                totalHour += course.WeeklyHours;
            }

            if (totalHour > MaxWeeklyHours)
            {
                throw new Exception("can not exceed 4 hours per week");
            }

            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new InvalidOperationException($"Part-time students cannot register for more than {MaxNumOfCourses} courses.");
            }
            else
            {
                base.RegisterCourses(selectedCourses);
            }
        }
    }
}