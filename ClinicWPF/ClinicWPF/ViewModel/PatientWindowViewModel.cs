using ClinicWPF.Models;
using ClinicWPF.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ClinicWPF.ViewModel
{
    class PatientWindowViewModel
    {
        public ICommand CreateAppoimentCommand { get; set; }
        public ICommand ExitCommand { get; set; }
        public DateTime date { get; set; }
        public string Anamnesis { get; set; }
        public string Tests { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        private int _id { get; set; }

        private Window _window;

        public List<string> Spec { get; set; }
        public string SelectedSpec { get; set; }

        private string _selectedSpec = "";
     //   public string SelectedSpec { get { return _selectedSpec; } set { this._selectedSpec = value; SpecializationSelectExecute(); } }
        public List<string> Doctors { get { return _doctors; } }

        private List<string> _doctors = new List<string>();
        public string SelectedDoc { get; set; }

        public PatientWindowViewModel(int _id, Window window)
        {
            _window = window;
            CreateAppoimentCommand = new RelayCommand(CreateAppoimentCommandExecute, CreateAppoimentCommandExecuted);
            ExitCommand = new RelayCommand(ExitCommandExecute, ExitCommandExecuted);
            date = DateTime.Now.Date;
            this._id = _id;
            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                Personal person = db.Personals.Where(x => x.PatiendId == _id).First();
                Surname = person.Surname + " " + person.Name;
                Name = person.Name;
                var ls = db.Doctors.Select(x => x.Specialization).Distinct().ToList();
                Spec= ls;
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
                Tests = sb.ToString();
            }
            //this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        }
        #region
        private void CreateAppoimentCommandExecute()
        {
            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                //var ls = db.Doctors.Select(x => x.Specialization).Distinct().ToList();
                Appointment appointment = new Appointment();
                appointment.Date = date;
                appointment.PatiendId = _id;
                appointment.Status = "Назначено";
                appointment.DoctorId= 3; //////важно исправить

               db.Appointments.Add(appointment);
               db.SaveChanges();
            }
        }
        private bool CreateAppoimentCommandExecuted()
        {
            return true;
        }

        private void ExitCommandExecute()
        {
            LoginPage page = new LoginPage();
            page.Show();
            this.CloseWindow(_window);
        }
        private bool ExitCommandExecuted()
        {
            return true;
        }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

        //public void SpecializationSelectExecute()
        //{
        //    using (ClinicSystemContext db = new ClinicSystemContext())
        //    {
        //        _doctors.Clear();
        //        var doctors = db.Doctors.Where(x => x.Specialization == SelectedSpec).Select(x => x.Surname).ToList();
        //        foreach (var doctor in doctors)
        //        {
        //            _doctors.Add(doctor);
        //        }
        //    }
        //}
        //private bool SpecializationSelectExecuted() {
        //    return true;
        //}

        #endregion
    }
}
