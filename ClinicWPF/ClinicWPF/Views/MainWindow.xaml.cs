using ClinicWPF.Models;
using ClinicWPF.Models.View;
using ClinicWPF.ViewModel;
using ClinicWPF.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClinicWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int doctor_id;
        public MainWindow(int id)
        {
            InitializeComponent();
            doctor_id = id;
            MainWindowViewModel VM = new MainWindowViewModel(id);
            this.DataContext = VM;
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
        }

        private void DataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            PatienDataGrid row = (PatienDataGrid)DataGrid1.SelectedItem;
            DetailsWindow window = new DetailsWindow(row.Id, doctor_id);
            window.Show();
        }
    }
}
