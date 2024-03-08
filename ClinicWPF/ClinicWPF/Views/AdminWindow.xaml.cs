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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private AdminViewModel _adminViewModel;
        public AdminWindow()
        {
            InitializeComponent();
            AdminViewModel VM = new AdminViewModel();
            _adminViewModel = VM;
            this.DataContext = VM;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _adminViewModel.Doctors;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _adminViewModel.Patients;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataGrid.ItemsSource = _adminViewModel.MedicalProcedures;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
