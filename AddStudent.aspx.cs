using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using lab6.Models;

namespace lab6
{
    public partial class Addstudent : Page
    {

        public List<Student> StudentList
        {
            get
            {
                if (Session["StudentList"] == null)
                {
                    Session["StudentList"] = new List<Student>();
                }
                return (List<Student>)Session["StudentList"];
            }
            set
            {
                Session["StudentList"] = value;
            }
        }


        public partial class RequiredFieldValidation : System.Web.UI.Page
        {

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Clear();
                TableRow rowTotal = new TableRow();
                studentInfo.Rows.Add(rowTotal);

            }
            else { 
                submitClick(); 
            }
           
        }

        private void submitClick()
        {
            string studentTypes = studentType.SelectedValue;
            string StudentName = studentName.Text;
            Student student;
            switch (studentTypes)
            {
                case "1":
                    student = new FulltimeStudent(StudentName);
                    break;
                case "2":
                    student = new ParttimeStudent(StudentName);
                    break;
                case "3":
                    student = new CoopStudent(StudentName);
                    break;
                default: return;
            }


            StudentList.Add(student);
            UpdateStudentTable();
           
        }
   

        private void UpdateStudentTable()
        {
            studentName.Text = "";
            studentType.SelectedIndex = 0;
            foreach (Student student in StudentList)
            {
                if (!string.IsNullOrEmpty(student.Name)) {
                    TableRow rowTotal = new TableRow();
                    studentInfo.Rows.Add(rowTotal);

                    TableCell idCell = new TableCell();
                    rowTotal.Cells.Add(idCell);
                    idCell.Text = student.Id.ToString();

                    TableCell nameCell = new TableCell();
                    rowTotal.Cells.Add(nameCell);
                    nameCell.Text = student.Name;
                }
                else
                {
                    continue;
                }
                
            }

            
        }
    }
}
