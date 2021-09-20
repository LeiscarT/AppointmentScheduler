using System.Collections.Generic;
using System.Threading.Tasks;
using AppointmentScheduler.Models.ViewModels;

namespace AppointmentScheduler.Services
{
    public interface IAppointmentService
    {
         public List<DoctorViewModel> GetDoctorList();
         public List<PatientViewModel> GetPatientList();

         public Task<int> AddUpdate(AppointmentViewModel model);
    }
}