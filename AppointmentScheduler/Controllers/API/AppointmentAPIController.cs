using AppointmentScheduler.Models.ViewModels;
using AppointmentScheduler.Services;
using AppointmentScheduler.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AppointmentScheduler.Controllers.API
{
    [Route("api/Appointment")]
    [ApiController]
    public class AppointmentAPIController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContext;
        private readonly string loginUserId;
        private readonly string role;


        public AppointmentAPIController(IAppointmentService appointmentService, IHttpContextAccessor httpContext)
        {
            _appointmentService = appointmentService;
            _httpContext = httpContext;
            loginUserId =  _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        [HttpPost]
        [Route("SaveCalendarData")]

        public IActionResult SaveCalendarData(AppointmentViewModel model)
        {
            CommonResponse<int> response = new CommonResponse<int>();
            try
            {
                response.Status = _appointmentService.AddUpdate(model).Result;
                if(response.Status == 1)
                {
                    response.Message = Helper.AppoinmentUpdated;
                }
                if(response.Status == 2)
                {
                    response.Message = Helper.AppoinmentAdded;
                }
            }
            catch(Exception e)
            {
                response.Message = e.Message;
                response.Status = Helper.Failure_Code;
            }
            return Ok(response);
        }

        
    }
}