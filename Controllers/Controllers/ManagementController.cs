using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsAndInterfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Controllers.Controllers
{
    [Route("[action]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private readonly IManagementService _managementService;

        public ManagementController(IManagementService managementService)
        {
            _managementService = managementService;
        }

        [HttpPost]
        public async Task<string> AddSpecialization([FromBody] DoctorSpecialization specialization)
        {
            await _managementService.AddSpecializationAsync(specialization);
            return "Specialization added successfully";
        }

        [HttpDelete]
        public async Task<string> DeleteSpecializationById(int specializationId)
        {
            await _managementService.DeleteSpecializationByIdAsync(specializationId);
            return "Specialization deleted successfully";
        }

        [HttpPost]
        public async Task<string> AddDoctor([FromBody] Doctor doctor)
        {
            await _managementService.AddDoctorAsync(doctor);
            return "Doctor Added Successfully";
        }

        [HttpDelete]
        public async Task<string> DeleteDoctorById(int doctorId)
        {
            await _managementService.DeleteDoctorByIdAsync(doctorId);
            return "Doctor Deleted Successfully";
        }

        [HttpPut]
        public async Task<string> UpdateAppointmentByAppointmentId(int appointmentId, [FromBody] Appointment appointment)
        {
            await _managementService.UpdateAppointmentByAppointmentIdAsync(appointmentId, appointment);
            return "Appointment Updated Successfully";
        }

        [HttpGet]
        public async Task<List<Appointment>> GetAllAppointments()
        {
            return await _managementService.GetAllAppointmentsAsync();
        }

        [HttpDelete]
        public async Task<string> DeleteAppointmentByAppointmentId(int appointmentId)
        {
            await _managementService.DeleteAppointmentByAppointmentIdAsync(appointmentId);
            return "Appointment Deleted Successfully";
        }
    }
}
