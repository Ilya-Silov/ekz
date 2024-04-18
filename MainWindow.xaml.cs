using Microsoft.EntityFrameworkCore;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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

using Wpf.Ui.Controls;

using WpfApp3.config;
using WpfApp3.data.entity;
using WpfApp3.pages;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FluentWindow, INotifyPropertyChanged
    {
        private ObservableCollection<Product> products;

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            Products = new(MainContext.Instance.Products.OrderByDescending(x => x.Id));
        }

        public ObservableCollection<Product> Products
        {
            get => products;
            set { 
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Product removableProduct = (Product)((Wpf.Ui.Controls.Button)sender).DataContext;
            MainContext.Instance.Products.Remove(removableProduct);
            MainContext.Instance.SaveChanges();
            Products.Remove(removableProduct);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Adding adding = new Adding();
            adding.ShowDialog();
            Products = new(MainContext.Instance.Products.OrderByDescending(x => x.Id));
            Products.;
        }
    }
}