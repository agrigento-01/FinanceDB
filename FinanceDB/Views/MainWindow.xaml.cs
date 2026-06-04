using FinanceDB.ViewModels;
using Microsoft.Extensions.Primitives;
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

namespace FinanceDB.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is MainWindowViewModel vm)
            {
                await vm.LoadFunds();
            }
        }

        /// <summary>
        /// Handles query search from a textbox to the viewmodel dbo handler
        /// </summary>
        public async void Query_Search(object sender, TextChangedEventArgs e)
        {
            var query = sender as TextBox;
            if (this.DataContext is MainWindowViewModel vm)
            {
                await vm.SearchFunds(query.Text.ToString());
            }
        }
    }
}