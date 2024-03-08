using ClinicWPF.Models;
using ClinicWPF.Models.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ClinicWPF.ViewModel
{
    internal class AdminViewModel
    {
        public List<Doctor> Doctors = new List<Doctor>();
        public List<PatienDataGrid> Patients = new List<PatienDataGrid>();
        public List<MedicalProcedure> MedicalProcedures = new List<MedicalProcedure>();
        public List<Appointment> Appointments = new List<Appointment>();

        public AdminViewModel() {
            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                Doctors = db.Doctors.ToList();
                var ls = db.Patients.ToList();
                foreach (var pat in ls)
                {
                    var n = new PatienDataGrid()
                    {
                        Id = pat.Id,
                        FullName = db.Personals.Where(x => x.PatiendId == pat.Id).Select(x => x.Name + x.Surname).FirstOrDefault(),
                        Anamnesis = pat.Anamnesis,
                        Date = pat.DateStart.ToShortDateString(),
                        Note = pat.Note
                    };
                    Patients.Add(n);
                }
                MedicalProcedures = db.MedicalProcedures.ToList();
                Appointments = db.Appointments.Where(x => x.Date == DateTime.Now.Date).ToList();
            }
        }
    }
}
