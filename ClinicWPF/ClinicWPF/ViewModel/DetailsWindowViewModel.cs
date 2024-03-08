using ClinicWPF.Models.View;
using ClinicWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Data;
using System.Windows.Input;

namespace ClinicWPF.ViewModel
{
    internal class DetailsWindowViewModel
    {
        public ICommand CreatePrescription;
        public string FullName { get; set; }
        public string TestsResults { get; set; }
        public string MoreInfo { get; set; }
        private int _id { get; set; }
        public DetailsWindowViewModel(int patientId) { 

            _id = patientId;

            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                var patient = db.Patients.Where(x => x.Id == _id).First();

                var personal = db.Personals.Where(x => x.PatiendId == _id).First();

                FullName = personal.Name+ " " + personal.Surname + " " + personal.Patronimic;

                var res = db.TestResults.Where(x => x.PatientId == _id).ToList();
                StringBuilder sb = new StringBuilder();
                foreach (var result in res)
                {
                    var name = db.MedicalTests.Where(x => x.Id == result.TestId).Select(x => x.Name).First();
                    sb.Append(name);
                    sb.Append(" : ");
                    sb.Append(result.Result);
                    sb.Append("\n");
                }
                TestsResults = sb.ToString();

                MoreInfo = patient.Anamnesis + "\n" + patient.Note;

            }
        }
        private void CreatePrescriptionExecute()
        {

        }
        private bool CreatePrescriptionCanExecuted()
        {
            return true;
        }
    }
}
