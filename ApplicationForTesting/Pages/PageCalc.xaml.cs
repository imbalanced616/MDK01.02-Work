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
using System.IO;

namespace ApplicationForTesting.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageCalc.xaml
    /// </summary>
    public partial class PageCalc : Page
    {
        public PageCalc()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int number1 = int.Parse(txtOne.Text);
                int number2 = int.Parse(txtTwo.Text);
                if (number2 != 0)
                {
                    txtSumma.Text = Convert.ToString(number1 + number2);
                    txtRazn.Text = Convert.ToString(number1 - number2);
                    txtProiz.Text = Convert.ToString(number1 * number2);
                    txtChast.Text = Convert.ToString(number1 / number2);
                }
                else
                {
                    txtTwo.Clear();
                    txtTwo.Focus();
                    MessageBox.Show("Второе число не может быть равно нулю, т.к. делить на ноль нельзя!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                txtOne.Clear();
                txtTwo.Clear();
                txtOne.Focus();
                MessageBox.Show($"{ex}", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            StreamWriter sw = new StreamWriter("Calc.txt", true, Encoding.UTF8);
            sw.WriteLine($"Первое число: {txtOne.Text}, второе число: {txtTwo.Text} - Сумма чисел: {txtSumma.Text}, Разность чисел: {txtRazn.Text}, Произведение чисел: {txtProiz.Text}, Частное чисел: {txtChast.Text}.");
            sw.Close();
        }
    }
}
