
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Accord.Math.Optimization;
using Accord.Math.Optimization.Losses;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using ScottPlot;

namespace OptimizationLab1
{
    /// <summary>
    /// Логика взаимодействия для Graph.xaml
    /// </summary>
    public partial class Graph : Window
    {
        public Graph()
        {
            InitializeComponent();

            WpfPlot1.Plot.Add.Line(0,500,5000,0).Label = "первое ограничение";
            WpfPlot1.Plot.Add.Line(0, 440, 2800, 0).Label = "второе ограничение";
            WpfPlot1.Plot.Add.Line(0, 400, 1000, 400).Label = "x =< 400";
            WpfPlot1.Plot.Add.Line(600, 0, 600, 500).Label = "x =< 600";
            WpfPlot1.Plot.Add.Marker(600,345).Label = "Точка максимума";
            WpfPlot1.Plot.Legend.IsVisible = true;
            //  WpfPlot1.Plot.Add.Line(new Coordinates(x,y));

            WpfPlot1.Refresh();

          
        }

    }
}
