
using Accord.Math.Optimization;
using System.Windows;
using Microsoft.SolverFoundation.Common;
using Microsoft.SolverFoundation.Services;

namespace OptimizationLab1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<double> X = new List<double>();
        List<double> Y = new List<double>();
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int hat = Convert.ToInt32(TextBox1.Text);
            int pod = Convert.ToInt32(TextBox4.Text);

            int zapas1 = Convert.ToInt32(TextBox7.Text);

            int zapas2 = Convert.ToInt32(TextBox8.Text);
            double hat_cost2 = Convert.ToDouble(TextBox2.Text);
            int pod_cost2 = Convert.ToInt32(TextBox5.Text);

            int hat_price = Convert.ToInt32(TextBox3.Text);
            int pod_price = Convert.ToInt32(TextBox6.Text);

            double[] coefficients = { hat_price, pod_price };

            // Максимальные значения для шапок и подстежек
            int maxHats = 600;
            int maxLinings = 400;

            double maxfurcost = 0;
            double maxfabriccost = 0;

            // Лучшие значения переменных и максимальное значение функции цели
            double[] bestValues = { 0, 0 };
            double maxObjectiveValue = 0;

            // Перебор всех возможных значений переменных
            for (int hats = 0; hats <= maxHats; hats++)
            {
                for (int linings = 0; linings <= maxLinings; linings++)
                {
                    // Проверка ограничений по меху и ткани
                    double furCost = hat * hats + pod * linings;
                    double fabricCost = hat_cost2 * hats + pod_cost2 * linings;
                    double objectiveValue = 0;

                    if (furCost <= zapas1 || fabricCost <= zapas2)
                    {
                        if(furCost <= zapas1 && fabricCost <= zapas2)
                        {
                            // Вычисление значения функции цели
                            objectiveValue = coefficients[0] * hats + coefficients[1] * linings;

                            // Обновление лучшего решения, если текущее лучше
                            if (objectiveValue > maxObjectiveValue)
                            {
                                maxObjectiveValue = objectiveValue;
                                bestValues[0] = hats;
                                bestValues[1] = linings;
                                maxfurcost = furCost;
                                maxfabriccost = fabricCost;
                            }
                        }
                    }
                }
            }
            Graph graph = new Graph();
            TextBoxResult.Text = $"Шапок {bestValues[0]} Подтяжек {bestValues[1]} Сумма {maxObjectiveValue} \nПотрачено меха {maxfurcost} Потрачено ткани {maxfabriccost}";
            graph.Show();
        }

    }

}