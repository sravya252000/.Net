using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ModelsAndInterfaces
{
    public interface IPatientService
    {
        Task<List<Medicine>> GetMedicinesByPatientIdAsync(int patientId);
        Task AddPatientAsync(Patient patient);
        Task<List<DoctorSpecialization>> GetAllSpecializationsAsync();
        Task<List<Doctor>> GetDoctorsBySpecializationAsync(string specializationName);
        Task<int> CountDoctorsInSpecializationAsync(string specializationName);
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task AddAppointmentAsync(Appointment appointment);
        Task<List<Appointment>> SortAppointmentsByDateAndTimeAsync(List<Appointment> appointments);
        Task<List<Appointment>> GetAllAppointmentsByPatientIdAsync(int patientId);
    }
}
