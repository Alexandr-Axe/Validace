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

namespace Validace
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DPAgeDate.SelectedDate = DateTime.Today;
        }
        private void DPAgeDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LBAgeDate.Content = Convert.ToDateTime(DPAgeDate.Text).ToString("dd/MM/yyyy");
        }
    }
}
