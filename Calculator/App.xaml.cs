using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void App_Startup(object sender, StartupEventArgs e)
        {
            MainWindow window = new MainWindow();

            CalculatorModel calculator = new CalculatorModel();
            CalculatorViewModel viewModel = new CalculatorViewModel(calculator);
            window.DataContext = viewModel;

            window.Show();
        }
    }
}
