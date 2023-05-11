using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lab6.Models;
using Lab6.Models;


namespace lab6
{
    public partial class RegisterCourse : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (Course c in Helper.GetAvailableCourses())
                {
                    chklst.Items.Add(new ListItem(c.Title + " -" + c.WeeklyHours + " hours/week", c.Code));
                }
                var studentList = (List<Student>)Session["StudentList"];
                if (studentList != null)
                {
                    foreach (var student in studentList)
                    {
                        var listItem = new ListItem(student.ToString());
                        studentName.Items.Add(listItem);
                    }
                }

           
            }
        }


        protected void studentName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var studentList = (List<Student>)Session["StudentList"];
            Student selectedStudent = null;
            if (studentList != null)
            {
                selectedStudent = studentList.FirstOrDefault(student => student.ToString() == studentName.SelectedItem.Text);
            }

            if (selectedStudent != null)
            {
                int totalCourses = selectedStudent.RegisteredCourses.Count;
                int totalWeeklyHours = selectedStudent.TotalWeeklyHours();
                success.Text = $"This student has {totalCourses} courses, {totalWeeklyHours} hours weekly.";
                error.Text = "";
            }
        }



        protected void submitClick(object sender, System.EventArgs e)
        {
            // Get the selected student from the dropdown list
            var studentList = (List<Student>)Session["StudentList"];
            Student selectedStudent = null;
            if (studentList != null)
            {
                selectedStudent = studentList.FirstOrDefault(student => student.ToString() == studentName.SelectedItem.Text);
               
            }
            
           

            // Get the selected courses
            List<Course> selectedCourses = new List<Course>();
            foreach (ListItem lstItem in chklst.Items)
            {
                if (lstItem.Selected)
                {
                    Course selectedCourse = Helper.GetCourseByCode(lstItem.Value);
                    selectedCourses.Add(selectedCourse);
                }
            }

            // Check if the selected student is a full-time, part-time, or coop student, and enforce the corresponding business rules
            bool isValid = true;
            string errorMessage = "";
            if (selectedStudent is FulltimeStudent fulltimeStudent)
            {
                int totalWeeklyHours = selectedCourses.Sum(course => course.WeeklyHours);
                if (totalWeeklyHours > FulltimeStudent.MaxWeeklyHours)
                {
                    isValid = false;
                    errorMessage = $"You have exceeded the maximum weekly hours: {FulltimeStudent.MaxWeeklyHours}.";
                }
                if (totalWeeklyHours == 0)
                {
                    isValid = false;
                    errorMessage = "You have to select at least one course";
                }
            }
            else if (selectedStudent is ParttimeStudent parttimeStudent)
            {
                if (selectedCourses.Count > ParttimeStudent.MaxNumOfCourses)
                {
                    isValid = false;
                    errorMessage = $"You have exceeded the maximum number of courses: {ParttimeStudent.MaxNumOfCourses}.";
                }
                if (selectedCourses.Count == 0)
                {
                    isValid = false;
                    errorMessage = "You have to select at least one course";
                }
            }
            else if (selectedStudent is CoopStudent coopStudent)
            {
                int totalWeeklyHours = selectedCourses.Sum(course => course.WeeklyHours);
                if (totalWeeklyHours > CoopStudent.MaxWeeklyHours)
                {
                    isValid = false;
                    errorMessage = $"You have exceeded the maximum weekly hours: {CoopStudent.MaxWeeklyHours}.";
                }
                else if (selectedCourses.Count > CoopStudent.MaxNumOfCourses)
                {
                    isValid = false;
                    errorMessage = $"You have exceeded the maximum number of courses: {CoopStudent.MaxNumOfCourses}.";
                }
                if (totalWeeklyHours == 0)
                {
                    isValid = false;
                    errorMessage = "You have to select at least one course";
                }
            }

            if (isValid)
            {
                selectedStudent.RegisterCourses(selectedCourses);
                int totalCourses = selectedCourses.Count;
                int totalWeeklyHours = selectedStudent.TotalWeeklyHours();
                success.Text = $"This student has registered {totalCourses} courses, {totalWeeklyHours} hours weekly.";
                error.Text = "";
                foreach (ListItem lstItem in chklst.Items)
                {
                    if (lstItem.Selected)
                    {
                       lstItem.Selected = false;
                    }
                }
            }
            else
            {
                success.Text = "";
                error.Text = errorMessage;
            }
        }

    }
        }