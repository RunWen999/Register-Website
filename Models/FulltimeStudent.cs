using System;
using System.Collections.Generic;
using System.EnterpriseServices.CompensatingResourceManager;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class FulltimeStudent : Student
    {
        public static int MaxWeeklyHours { get; set; }

        public FulltimeStudent(string name) : base(name)
        {
            
        }

        public override string ToString()
        {
            return $"{Id} – {Name} (Full-time Student)";
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
                throw new Exception("can not exceed 16 hours per week");
            }
            else
            {
                base.RegisterCourses(selectedCourses);  
            }
        }

    }

}