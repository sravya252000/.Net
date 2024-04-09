using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database; // Assuming this namespace contains your DbContext
using Microsoft.EntityFrameworkCore;
using ModelsAndInterfaces;

namespace Methods
{
    public class ManagementServices : IManagementService
    {
        private readonly ApplicationDbContext _context;

        private readonly EmailServices _emailService;
        public ManagementServices(EmailServices emailService)
        {
            _emailService = emailService;
        }
        public ManagementServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<DoctorSpecialization>> GetAllSpecializationsAsync()
        {
            return await _context.DoctorSpecializations.ToListAsync();
        }

        public async Task AddSpecializationAsync(DoctorSpecialization specialization)
        {
            _context.DoctorSpecializations.Add(specialization);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpecializationByIdAsync(int specializationId)
        {
            var specializationToRemove = await _context.DoctorSpecializations.FirstOrDefaultAsync(s => s.Id == specializationId);
            if (specializationToRemove != null)
            {
                _context.DoctorSpecializations.Remove(specializationToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddDoctorAsync(Doctor doctor)
        {
            _context.Doctors.Add(doctor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDoctorByIdAsync(int doctorId)
        {
            var doctorToRemove = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
            if (doctorToRemove != null)
            {
                _context.Doctors.Remove(doctorToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAppointmentByAppointmentIdAsync(int appointmentId, Appointment appointment)
        {
            var existingAppointment = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
            if (existingAppointment != null)
            {
                existingAppointment.AppointmentDateAndTime = appointment.AppointmentDateAndTime;
                existingAppointment.PatientId = appointment.PatientId;
                existingAppointment.DoctorId = appointment.DoctorId;
                await _emailService.SendEmailAsync("sravya252000@gmail.com", "Email of updation", "Appointment updated successfully");
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _context.Appointments.ToListAsync();
        }

        public async Task DeleteAppointmentByAppointmentIdAsync(int appointmentId)
        {
            var appointmentToRemove = await _context.Appointments.FirstOrDefaultAsync(a => a.Id == appointmentId);
            if (appointmentToRemove != null)
            {
                _context.Appointments.Remove(appointmentToRemove);
                await _context.SaveChangesAsync();
            }
        }
    }
}
