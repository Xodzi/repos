using ClinicWPF.Models;
using ClinicWPF.Views;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

namespace ClinicWPF.ViewModel
{
    internal class LoginPageViewModel
    {
        public ICommand LoginCommand { get; set; }

        //public RelayCommand<Window> CloseWindowCommand { get; private set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public List<string> Spec { get; set; }

        private Window _window { get; set; }

        public string Selected { get; set; }

        public LoginPageViewModel(Window window) {
            _window = window;
            LoginCommand = new RelayCommand(LoginCommandExecute, LoginCommandCanExecuted);
            //this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                //var ls = db.Doctors.Select(x => x.Specialization).Distinct().ToList();
                var ls = db.Roles.Select(x => x.Name).ToList();
                Spec = ls;
            }
        }

        private void LoginCommandExecute()
        {
            if(Selected == "Пациент")
            {
                using (ClinicSystemContext db = new ClinicSystemContext())
                {
                    //var doctor = db.Patients.Where(x => x.Name == Name && x.Surname == Surname && x.Specialization == Selected).FirstOrDefault();
                    int person = db.Personals.Where(x => x.Name == Name && x.Surname == Surname).Select(x => x.PatiendId).FirstOrDefault();
                    var patient = db.Patients.Where(x => x.Id == person).FirstOrDefault();
                    if (patient != null)
                    {
                        PatientWindow mv = new PatientWindow(patient.Id);
                        mv.Show();
                        this.CloseWindow(_window);
                        return;
                    }
                }
            }
            if(Selected == "Доктор")
            {
                using (ClinicSystemContext db = new ClinicSystemContext())
                {
                    var doctor = db.Doctors.Where(x => x.Name == Name && x.Surname == Surname).FirstOrDefault();
                    if (doctor != null)
                    {
                        MainWindow mv = new MainWindow(doctor.Id);
                        mv.Show();
                        this.CloseWindow(_window);
                    }
                }
            }
            else
            {
                AdminWindow aw = new AdminWindow();
                aw.Show();
                this.CloseWindow(_window);
            }
            
        }
        private bool LoginCommandCanExecuted()
        {
            if (Name != null && Surname != null && Selected != null) return true;
            return true;
        }
        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }

    }
}
