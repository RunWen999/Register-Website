﻿using lab6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace lab6
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            FulltimeStudent.MaxWeeklyHours = 16;
            ParttimeStudent.MaxNumOfCourses = 3;
            CoopStudent.MaxNumOfCourses = 2;
            CoopStudent.MaxWeeklyHours = 4;
        }
    }
}