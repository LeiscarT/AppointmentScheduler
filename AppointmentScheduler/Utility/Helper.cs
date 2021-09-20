using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentScheduler.Utility
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string Patient = "Patient";
        public static string Doctor = "Doctor";
        public static string AppoinmentAdded = "Appointment added Succesfully.";
        public static string AppoinmentUpdated = "Appointment updated Succesfully.";
        public static string AppoinmentDeleted = "Appointment deleted Succesfully.";
        public static string AppoinmentExist = "Appointment for selected date and time already exist.";
        public static string AppoinmentError = "Something went wrong, Please try again.";
        public static int Success_Code = 1;
        public static int Failure_Code = 0;

       

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem {Value = Helper.Admin, Text = Helper.Admin },
                new SelectListItem {Value= Helper.Patient, Text = Helper.Patient},
                new SelectListItem {Value = Helper.Doctor, Text = Helper.Doctor}
            };
        }

        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;

            List<SelectListItem> duration = new List<SelectListItem>();
            for(int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " hr" });
                minute = minute + 30;
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " hr 30 min" });
                minute = minute + 30;
            }
            return duration;

        }
    }
}
