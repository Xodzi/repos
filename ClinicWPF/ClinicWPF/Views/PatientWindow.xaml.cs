using ClinicWPF.Models;
using ClinicWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ClinicWPF.Views
{
    /// <summary>
    /// Логика взаимодействия для PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        private PatientWindowViewModel _viewModel;
        public PatientWindow(int id)
        {
            InitializeComponent();
            PatientWindowViewModel VM = new PatientWindowViewModel(id, this);
            _viewModel = VM;
            this.DataContext = VM;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (ClinicSystemContext db = new ClinicSystemContext())
            {

                Doctors_Box.ItemsSource = db.Doctors.Where(x => x.Specialization == Spec_box.SelectedItem.ToString()).Select(x => x.Surname).ToList();
                _viewModel.SelectedSpec = Spec_box.SelectedItem.ToString();
            }
        }
    }
}
