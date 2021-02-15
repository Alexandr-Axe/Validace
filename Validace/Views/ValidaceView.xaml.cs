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
            TBValidateName.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_GotKeyboardFocus);
            TBValidateName.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_LostKeyboardFocus);
            TBValidateAge.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_GotKeyboardFocus);
            TBValidateAge.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_LostKeyboardFocus);
            TBValidatePIN.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_GotKeyboardFocus);
            TBValidatePIN.LostKeyboardFocus += new KeyboardFocusChangedEventHandler(tb_LostKeyboardFocus);
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
            Prvni.Verify();
        }
        private void tb_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (sender is TextBox)
            {
                if (((TextBox)sender).Foreground == Brushes.Gray)
                {
                    ((TextBox)sender).Text = "";
                    ((TextBox)sender).Foreground = Brushes.Black;
                }
            }
        }
        private void tb_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string Fraze = string.Empty;
            if (sender is TextBox)
            {
                if (((TextBox)sender).Text.Trim().Equals(""))
                {
                    ((TextBox)sender).Foreground = Brushes.Gray;
                    if (((TextBox)sender).Name == "TBValidateName") Fraze = "Zadejte své jméno";
                    else if (((TextBox)sender).Name == "TBValidateAge") Fraze = "Zadejte svůj věk";
                    else if (((TextBox)sender).Name == "TBValidatePIN") Fraze = "Rodné číslo (xxxxxx/xxxx)";
                    ((TextBox)sender).Text = Fraze;
                }
            }
        }
    }
}
