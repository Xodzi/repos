using ClinicWPF.Models;
using ClinicWPF.Models.View;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClinicWPF.ViewModel
{
    internal class MainWindowViewModel
    {
        private int _id;
        public ICommand DetailsCommand { get; set; }
        public ObservableCollection<PatienDataGrid> data { get; set; }
        public MainWindowViewModel(int id)
        {
            DetailsCommand = new RelayCommand(DetailsCommandExecute, DetailsCommandCanExecuted);
            data = new ObservableCollection<PatienDataGrid>();
            _id = id;
            Get();
        }

        private async Task Get()
        {
            using (ClinicSystemContext db = new ClinicSystemContext())
            {
                //var ls = db.Patients.ToList();
                var ls = db.Appointments.Where(x => x.DoctorId == _id).ToList();
                foreach (var pat in ls)
                {
                    var p = db.Patients.Where(x => x.Id == pat.PatiendId).FirstOrDefault();
                    var n = new PatienDataGrid() {
                        Id = p.Id,
                        FullName = db.Personals.Where(x => x.PatiendId == p.Id).Select(x => x.Name + x.Surname).FirstOrDefault(),
                        Anamnesis = p.Anamnesis, 
                        Date = p.DateStart.ToShortDateString(), 
                        Note = p.Note };
                    var res = db.TestResults.Where(x => x.PatientId == p.Id).ToList();
                    StringBuilder sb = new StringBuilder();
                    foreach (var result in res)
                    {
                        var name = db.MedicalTests.Where(x => x.Id == result.TestId).Select(x => x.Name).First();
                        sb.Append(name);
                        sb.Append(" : ");
                        sb.Append(result.Result);
                        sb.Append("\n");
                    }
                    n.Tests = sb.ToString();
                    data.Add(n);
                }

            }
        }
        private void DetailsCommandExecute()
        {
            MessageBox.Show("GDS");
        }
        private bool DetailsCommandCanExecuted()
        {
            return true;
        }
    }
}
