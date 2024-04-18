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
using System.Windows.Shapes;

using Wpf.Ui.Controls;

using WpfApp3.config;
using WpfApp3.data.entity;

namespace WpfApp3.pages
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Adding : FluentWindow
    {
        public Adding()
        {
            InitializeComponent();
            this.DataContext = this;
            Product = new();
        }
        public Product Product { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainContext.Instance.Products.Add(Product);
                MainContext.Instance.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
