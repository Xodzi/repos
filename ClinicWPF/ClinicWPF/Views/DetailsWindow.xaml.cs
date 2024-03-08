using ClinicWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Логика взаимодействия для DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        int id { get; set; }
        public DetailsWindow(int id, int doctor_id)
        {
            InitializeComponent();
            DetailsWindowViewModel vm = new DetailsWindowViewModel(id);
            this.id = doctor_id;
            this.DataContext = vm;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("C:\\Users\\ivank\\source\\repos\\ClinicWPF\\ClinicWPF\\справка.chm");
            //System.Windows.Forms.Help.ShowHelp
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            DocumentView window = new DocumentView(NameTextBlock.Text, id);
            window.Show();
        }
    }
}
