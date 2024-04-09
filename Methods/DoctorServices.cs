using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; // Required for async methods
using Database; // Assuming ApplicationDbContext is defined here
using Microsoft.EntityFrameworkCore; // Required for Entity Framework Core async methods
using ModelsAndInterfaces;

namespace Methods
{
    public class DoctorServices : IDoctorService
    {
        private readonly ApplicationDbContext _context;

        //private readonly ManagementServices _managementServices;
       
        public DoctorServices(ApplicationDbContext context)
        {
            _context = context;
            //_managementServices = managementServices;
        }

        /*public  async Task<List<Appointment>> GetAllAppointmentsAsync()
        {
            return await _managementServices.GetAllAppointmentsAsync();
        }*/
        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetPatientByIdAsync(int id)
        {
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddMedicationAsync(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            await _context.SaveChangesAsync();
        }

        public async Task<List<DoctorSpecialization>> GetAllSpecializationsAsync()
        {
            return await _context.DoctorSpecializations.ToListAsync();
        }

        public async Task<int> CountDoctorsInSpecializationAsync(string specializationName)
        {
            return await _context.Doctors.CountAsync(d => d.Specialization == specializationName);
        }

        public async Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specializationName)
        {
            return await _context.Doctors.Where(d => d.Specialization == specializationName).ToListAsync();
        }

        public async Task<Doctor> GetDoctorByIdAsync(int id)
        {
            return await _context.Doctors.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task UpdateDoctorByDoctorIdAsync(int doctorId, Doctor doctor)
        {
            var existingDoctor = await _context.Doctors.FirstOrDefaultAsync(d => d.Id == doctorId);
            if (existingDoctor != null)
            {
                existingDoctor.Name = doctor.Name;
                existingDoctor.Specialization = doctor.Specialization;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Appointment>> GetAllAppointmentsByDoctorIdAsync(int doctorId)
        {
            return await _context.Appointments.Where(a => a.DoctorId == doctorId).ToListAsync();
        }

        public async Task<List<string>> GetDoctorNamesAsync()
        {
            return await _context.Doctors.Select(d => d.Name).ToListAsync();
        }
    }
}
