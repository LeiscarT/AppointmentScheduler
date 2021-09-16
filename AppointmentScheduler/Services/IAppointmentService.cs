using System.Collections.Generic;
using AppointmentScheduler.Models.ViewModels;

namespace AppointmentScheduler.Services
{
    public interface IAppointmentService
    {
         public List<DoctorViewModel> GetDoctorList();
         public List<PatientViewModel> GetPatientList();
    }
}