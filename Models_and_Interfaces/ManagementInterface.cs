using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAndInterfaces
{
    public interface IManagementService
    {
        //List<Medicine> GetAllMedicationsAsync();
        //Task UpdateMedicationByMedicineIdAsync(int medicineId, Medicine medication);
        //Task RemoveMedicationByIdAsync(int medicationId);
        Task<List<DoctorSpecialization>> GetAllSpecializationsAsync();
        Task AddSpecializationAsync(DoctorSpecialization specialization);
        Task DeleteSpecializationByIdAsync(int specializationId);
        Task AddDoctorAsync(Doctor doctor);
        Task DeleteDoctorByIdAsync(int doctorId);
        Task UpdateAppointmentByAppointmentIdAsync(int appointmentId, Appointment appointment);
        Task<List<Appointment>> GetAllAppointmentsAsync();
        Task DeleteAppointmentByAppointmentIdAsync(int appointmentId);
    }
}
