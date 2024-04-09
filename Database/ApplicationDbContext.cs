using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using ModelsAndInterfaces;
namespace Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Define DbSet properties for the entities
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<DoctorSpecialization> DoctorSpecializations { get; set; }
        public DbSet<Medicine> Medicines { get; set; } // Add DbSet for Medicine

       /* protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define any additional configurations, such as relationships and constraints

            // Configure the relationship between Patient and Medicine
            modelBuilder.Entity<Patient>()
                .HasMany(p => p.Medications) // One patient can have many medications
                .WithOne() // Each medication belongs to one patient
                .HasForeignKey(m => m.Id) // Define foreign key property
                .OnDelete(DeleteBehavior.Cascade); // Define cascade delete behavior if necessary
        }*/
    }
}
