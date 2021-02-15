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
using Validace.Validators;

namespace Validace.Views
{
    /// <summary>
    /// Interakční logika pro ValidaceView.xaml
    /// </summary>
    public partial class ValidaceView : Window
    {
        Osoba Prvni;
        public ValidaceView()
        {
            InitializeComponent();
            DPAgeDate.SelectedDate = DateTime.Today;
        }
        private void DPAgeDate_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            LBAgeDate.Content = Convert.ToDateTime(DPAgeDate.Text).ToString("dd/MM/yyyy");
        }

        private void BTNValidateNow_Click(object sender, RoutedEventArgs e)
        {
            Prvni = new Osoba(new NameValidator(), new AgeValidator(), new DateValidator(), new PINValidator());
            Prvni.Input(TBValidateName);
            Prvni.Input(TBValidateAge);
            Prvni.Input(TBValidatePIN);
            Prvni.Input(LBAgeDate);
            //MessageBox.Show(Prvni.ToString(), "");
            Prvni.Verify();
        }
    }
}
