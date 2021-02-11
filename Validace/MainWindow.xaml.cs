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
using Validace.Interfaces;
using Validace.Views;
using Validace.Validators;

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
        }

        private void BTNValidate_Click(object sender, RoutedEventArgs e)
        {
            ValidaceView p = new ValidaceView();
            this.Content = p.Content;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
    class Osoba
    {
        readonly INameValidator ValidatorJmeno;
        readonly IAgeValidator ValidatorVek;
        readonly IDateValidator ValidatorDatum;
        readonly IPINValidator ValidatorRodneCislo;
        public string Jmeno { get; set; }
        public int Vek { get; set; }
        public DateTime DatumNarozeni { get; set; }
        public string RodneCislo { get; set; }
        public Osoba(INameValidator INV, IAgeValidator IAV, IDateValidator IDV, IPINValidator IPINV) 
        {
            ValidatorJmeno = INV;
            ValidatorVek = IAV;
            ValidatorDatum = IDV;
            ValidatorRodneCislo = IPINV;
        }
        public Osoba() //V případě, že vytvoříme bezparametrickou osobu
        {
            ValidatorJmeno = null;
            ValidatorVek = null;
            ValidatorDatum = null;
            ValidatorRodneCislo = null;
        }
        public void Input(Control C) 
        {
            TextBox TB;
            Label L;
            bool JmenoOK;
            bool VekOK;
            bool DatumOK;
            bool RCOK;
            switch (C.Name)
            {
                case "TBValidateName":
                    TB = C as TextBox;
                    if (!String.IsNullOrEmpty(TB.Text))
                    {
                        if (JmenoOK = ValidatorJmeno.IsOkay(TB.Text)) Jmeno = TB.Text;
                    }
                    else return;
                    break;
                case "TBValidateAge":
                    TB = C as TextBox;
                    if (!String.IsNullOrEmpty(TB.Text))
                    {
                        if (JmenoOK = ValidatorVek.IsOkay(TB.Text, out int vek)) Vek = vek;
                    }
                    break;
                case "TBValidatePIN":
                    TB = C as TextBox;
                    if (!String.IsNullOrEmpty(TB.Text))
                    {
                        if (JmenoOK = ValidatorRodneCislo.IsOkay(TB.Text)) RodneCislo = TB.Text;
                    }
                    break;
                case "LBAgeDate":
                    L = C as Label;
                    if (L.Content.ToString().Length != 0)
                    {
                        if (JmenoOK = ValidatorDatum.IsOkay(Convert.ToDateTime(L))) DatumNarozeni = Convert.ToDateTime(L.Content);
                    }
                    break;
            }
        }
        public override string ToString() => $"Jméno : {Jmeno}\nVěk : {Vek}\nDatum narození : {DatumNarozeni}\nRodné číslo : {RodneCislo}";
    }
}
