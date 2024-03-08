using System.Collections.ObjectModel;
using System.Data.Common;
using System.Linq;
using System.Net;
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

namespace Opt4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int StartPoints = 5;
        int EndPoints = 4;
        List<int> Potrebnost = new List<int>();
        List<int> Zapas = new List<int>();
        public MainWindow()
        {
            InitializeComponent();
            ObservableCollection<Data> data = new ObservableCollection<Data>();
            data.Add(new Data { Post = "A1", B1 = "5", B2 = "8", B3 = "3", B4 = "6", Ost = "300" });
            data.Add(new Data { Post = "A2", B1 = "4", B2 = "6", B3 = "8", B4 = "2", Ost = "700" });
            data.Add(new Data { Post = "A3", B1 = "6", B2 = "9", B3 = "7", B4 = "2", Ost = "600" });
            data.Add(new Data { Post = "A4", B1 = "1", B2 = "3", B3 = "4", B4 = "7", Ost = "900" });
            data.Add(new Data { Post = "A5", B1 = "5", B2 = "3", B3 = "8", B4 = "1", Ost = "500" });
            data.Add(new Data { Post = "Потребность", B1 = "600", B2 = "800", B3 = "700", B4 = "900", Ost = "" });
            Table.ItemsSource = data;
            Potrebnost.Add(Int32.Parse(data.Last().B1));
            Potrebnost.Add(Int32.Parse(data.Last().B2));
            Potrebnost.Add(Int32.Parse(data.Last().B3));
            Potrebnost.Add(Int32.Parse(data.Last().B4));
            foreach (var elem in data.SkipLast(1))
            {
                Zapas.Add(Int32.Parse(elem.Ost));
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int[,] matrix = new int[,] { {5,8,3,6 }, {4,6,8,2 }, {6,9,7,2 }, {1,3,4,7 }, {5,3,8,1 } }; 
            var test = LowCostMethod(matrix);
            var stop = 5;
        }
        private double CornerMethod()
        {
            double costs = 0;

            int row = 0, column = 0;

            while (row < Zapas.Count && column < Potrebnost.Count)
            {

                if (Potrebnost[column] < Zapas[row])
                {
                    Zapas[row] -= Potrebnost[column];
                    row++;
                    costs += Potrebnost[column];
                    continue;
                }
                if (Potrebnost[column] > Zapas[row])
                {
                    Potrebnost[column] -= Zapas[row];
                    column++;
                    costs += Zapas[row];
                    continue;
                }
                else
                {

                }
            }
            return costs;
        }
        private int LowCostMethod(int[,] matrix)
        {
            int costs = 0;
            int min = matrix[0, 0];
            int row = 0, column = 0;
            while (!LowCostFinished(matrix))
            {
                min = Int32.MaxValue;
                for(int i=0; i < matrix.GetLength(0); i++)
                {
                    for(int j=0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, j] < min)
                        {
                            min = matrix[i, j];
                            row = i;
                            column = j;
                        }
                    }
                }
                if (Potrebnost[column] < Zapas[row])
                {
                    Zapas[row] -= Potrebnost[column];
                    for(int k=0; k < matrix.GetLength(0); k++)
                    {
                        matrix[k, column] = Int32.MaxValue;
                    }
                    costs += Potrebnost[column];
                    continue;
                }
                if (Potrebnost[column] > Zapas[row])
                {
                    Potrebnost[column] -= Zapas[row];
                    for (int k = 0; k < matrix.GetLength(1); k++)
                    {
                        matrix[row, k] = Int32.MaxValue;
                    }
                    costs += Zapas[row];
                    continue;
                }
            }

            return costs;
        }
        private bool LowCostFinished(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] != Int32.MaxValue) return false;
                }
            }
            return true;
        }
    }
}