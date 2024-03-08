using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Optimization4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Item> items= new ObservableCollection<Item>();
            items.Add(new Item { Post = "A1", B1 = 5, B2 = 8, B3 = 3, B4 = 6, Zapas = 300});
            items.Add(new Item { Post = "A2", B1 = 4, B2 = 6, B3 = 8, B4 = 2, Zapas = 700});
            items.Add(new Item { Post = "A3", B1 = 6, B2 = 9, B3 = 7, B4 = 2, Zapas = 600});
            items.Add(new Item { Post = "A4", B1 = 1, B2 = 3, B3 = 4, B4 = 7, Zapas = 900});
            items.Add(new Item { Post = "A5", B1 = 5, B2 = 3, B3 = 9, B4 = 1, Zapas = 500});
            items.Add(new Item { Post = "Потребность", B1 = 5, B2 = 3, B3 = 8, B4 = 1, Zapas = 0 });
            DataGrid.ItemsSource = items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}