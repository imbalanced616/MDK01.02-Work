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
using Microsoft.Win32;

namespace ApplicationForTesting.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageOrder.xaml
    /// </summary>
    public partial class PageOrder : Page
    {
        bool flag1 = false;
        bool flag2 = false;
        bool flag3 = false;
        bool flag4 = false;
        public PageOrder()
        {
            InitializeComponent();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            Check.Items.Clear();
            Check2.Items.Clear();
            Check3.Items.Clear();

            if (int.Parse(txtCheese.Text) > 0 && CbxCheeseBurger.IsChecked == false) CbxCheeseBurger.IsChecked = true;
            if (int.Parse(txtHam.Text) > 0 && CbxHamBurger.IsChecked == false) CbxHamBurger.IsChecked = true;
            if (int.Parse(txtCola.Text) > 0 && CbxCola.IsChecked == false) CbxCola.IsChecked = true;
            if (int.Parse(txtNuggets.Text) > 0 && CbxNuggets.IsChecked == false) CbxNuggets.IsChecked = true;

            if (CbxCheeseBurger.IsChecked == true && int.Parse(txtCheese.Text) > 0)
            {
                string CheeseBurger = Convert.ToString(CbxCheeseBurger.Content);
                Check.Items.Add(CheeseBurger);
                Check2.Items.Add(txtCheese.Text);
                Check3.Items.Add(3 * Convert.ToInt32(txtCheese.Text));
            }
            if (CbxHamBurger.IsChecked == true && int.Parse(txtHam.Text) > 0)
            {
                string HamBurger = Convert.ToString(CbxHamBurger.Content);
                Check.Items.Add(HamBurger);
                Check2.Items.Add(txtHam.Text);
                Check3.Items.Add(4 * Convert.ToInt32(txtHam.Text));
            }
            if (CbxCola.IsChecked == true && int.Parse(txtCola.Text) > 0)
            {
                string Cola = Convert.ToString(CbxCola.Content);
                Check.Items.Add(Cola);
                Check2.Items.Add(txtCola.Text);
                Check3.Items.Add(1 * Convert.ToInt32(txtCola.Text));
            }
            if (CbxNuggets.IsChecked == true && int.Parse(txtNuggets.Text) > 0)
            {
                string Nuggets = Convert.ToString(CbxNuggets.Content);
                Check.Items.Add(Nuggets);
                Check2.Items.Add(txtNuggets.Text);
                Check3.Items.Add(2 * Convert.ToInt32(txtNuggets.Text));
            }

            if (int.Parse(txtCheese.Text) < 0 && CbxCheeseBurger.IsChecked == true)
            {
                txtCheese.Text = Convert.ToString(1);
                MessageBox.Show("Кол-во чизбургеров не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (int.Parse(txtHam.Text) < 0 && CbxHamBurger.IsChecked == true)
            {
                txtHam.Text = Convert.ToString(1);
                MessageBox.Show("Кол-во гамбургеров не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (int.Parse(txtCola.Text) < 0 && CbxCola.IsChecked == true)
            {
                txtCola.Text = Convert.ToString(1);
                MessageBox.Show("Кол-во колы не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (int.Parse(txtNuggets.Text) < 0 && CbxNuggets.IsChecked == true)
            {
                txtNuggets.Text = Convert.ToString(1);
                MessageBox.Show("Кол-во наггетсов не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (int.Parse(txtCheese.Text) < 0 && CbxCheeseBurger.IsChecked == false)
            {
                txtCheese.Text = Convert.ToString(0);
                MessageBox.Show("Кол-во чизбургеров не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (int.Parse(txtHam.Text) < 0 && CbxHamBurger.IsChecked == false)
            {
                txtHam.Text = Convert.ToString(0);
                MessageBox.Show("Кол-во гамбургеров не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (int.Parse(txtCola.Text) < 0 && CbxCola.IsChecked == false)
            {
                txtCola.Text = Convert.ToString(0);
                MessageBox.Show("Кол-во колы не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (int.Parse(txtNuggets.Text) < 0 && CbxNuggets.IsChecked == false)
            {
                txtNuggets.Text = Convert.ToString(0);
                MessageBox.Show("Кол-во наггетсов не может быть отрицательным!", "Ошибка!", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            if (int.Parse(txtCheese.Text) == 0) CbxCheeseBurger.IsChecked = false;
            if (int.Parse(txtHam.Text) == 0) CbxHamBurger.IsChecked = false;
            if (int.Parse(txtCola.Text) == 0) CbxCola.IsChecked = false;
            if (int.Parse(txtNuggets.Text) == 0) CbxNuggets.IsChecked = false;
            if (Check2.Items.Count != 0)
            {
                int count = 0;
                for (int i = 0; i < Check2.Items.Count; i++) count += int.Parse(Check2.Items[i].ToString());
                Check2.Items.Add("--------------------");
                Check2.Items.Add($"Итого: {count}");
            }
            if (Check3.Items.Count != 0)
            {
                int summa = 0;
                for (int i = 0; i < Check3.Items.Count; i++) summa += int.Parse(Check3.Items[i].ToString());
                Check3.Items.Add("--------------------");
                Check3.Items.Add($"Итого: {summa}$");
            }

            StreamWriter sw = new StreamWriter("Order.txt", false, Encoding.UTF8);
            string[] check;
            string[] check2;
            string[] check3;
            check = new string[Check.Items.Count];
            for (int i = 0; i < Check.Items.Count; i++)
            {
                check[i] = Check.Items[i].ToString();
            }
            check2 = new string[Check2.Items.Count];
            for (int i = 0; i < Check2.Items.Count; i++)
            {
                check2[i] = Check2.Items[i].ToString();
            }
            check3 = new string[Check3.Items.Count];
            for (int i = 0; i < Check3.Items.Count; i++)
            {
                check3[i] = Check3.Items[i].ToString();
            }

            for (int i = 0; i < Check.Items.Count; i++)
            {
                sw.WriteLine($"Наименование продукта: {check[i]} - Кол-во: {check2[i]}шт. - Цена: {check3[i]}$"); ;
            }
            sw.Close();
        }

        private void CbxCheeseBurger_Click(object sender, RoutedEventArgs e)
        {
            if (flag1 == false)
            {
                flag1 = true;
                txtCheese.Text = Convert.ToString(1);
            }
            else
            {
                flag1 = false;
                txtCheese.Text = Convert.ToString(0);
            }
        }

        private void CbxHamBurger_Click(object sender, RoutedEventArgs e)
        {
            if (flag2 == false)
            {
                flag2 = true;
                txtHam.Text = Convert.ToString(1);
            }
            else
            {
                flag2 = false;
                txtHam.Text = Convert.ToString(0);
            }
        }

        private void CbxCola_Click(object sender, RoutedEventArgs e)
        {
            if (flag3 == false)
            {
                flag3 = true;
                txtCola.Text = Convert.ToString(1);
            }
            else
            {
                flag3 = false;
                txtCola.Text = Convert.ToString(0);
            }
        }

        private void CbxNuggets_Click(object sender, RoutedEventArgs e)
        {
            if (flag4 == false)
            {
                flag4 = true;
                txtNuggets.Text = Convert.ToString(1);
            }
            else
            {
                flag4 = false;
                txtNuggets.Text = Convert.ToString(0);
            }
        }
    }
}
