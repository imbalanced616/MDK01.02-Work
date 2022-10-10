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
using ApplicationForTesting.Classes;

namespace ApplicationForTesting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ClassFrame.frmObj = FrmCalc;
            FrmCalc.Navigate(new Pages.PageCalc());
        }

        private void btnMoveCalc_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageCalc());
            btnMoveCalc.IsEnabled = false;
            btnMoveOrder.IsEnabled = true;
        }

        private void btnMoveOrder_Click(object sender, RoutedEventArgs e)
        {
            Classes.ClassFrame.frmObj.Navigate(new Pages.PageOrder());
            btnMoveOrder.IsEnabled = false;
            btnMoveCalc.IsEnabled = true;
        }
    }
}
