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
        public void Verify() 
        {
            bool vek = true;
            bool rok = true;
            bool den = true;
            bool mesic = true;
            int i = Vek;
            int x;
            char[] RC = RodneCislo.ToCharArray();
            DateTime DT = DatumNarozeni;
            if (DT.Year == 1) 
            {
                rok = false;
                DT = DT.AddYears(1000);
            }
            TimeSpan RealnyVek = DateTime.Now - DT;
            x = RealnyVek.Days / 365;
            if (i != x) vek = false;
            if (RC[0] != DT.Year.ToString().ToCharArray()[2] || RC[1] != DT.Year.ToString().ToCharArray()[3]) rok = false;
            if (DT.Month.ToString().Length == 2)
            {
                if (RC[2] != DT.Month.ToString().ToCharArray()[0] || RC[3] != DT.Month.ToString().ToCharArray()[1]) mesic = false;
            }
            else 
            {
                if (RC[2] != '0') mesic = false;
            }
            if (DT.Day.ToString().Length == 2)
            {
                if (RC[4] != DT.Day.ToString().ToCharArray()[0] || RC[5] != DT.Day.ToString().ToCharArray()[1]) den = false;
            }
            else
            {
                if (RC[4] != '0') den = false;
            }
            MessageBox.Show($"{(den == false ? "Špatně vybraný den!\n" : "Správný den!\n")}{(mesic == false ? "Špatně vybraný měsíc!\n" : "Správný měsíc!\n")}{(rok == false ? "Špatně vybraný rok!\n" : "Správný rok!\n")}{(vek == false ? "Věk nesedí s datem narození!" : "Správný věk!")}", "");
            if (den && mesic && rok && vek) MessageBox.Show(ToString(), "");
        }
        public void Input(Control C) 
        {
            TextBox TB;
            Label L;
            bool JmenoOK;
            bool VekOK;
            bool DatumOK;
            bool RCOK;
            DateTime date;
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
                    date = Convert.ToDateTime(L.Content.ToString());
                    if (L.Content.ToString().Length != 0)
                    {
                        if (JmenoOK = ValidatorDatum.IsOkay(date)) DatumNarozeni = date;
                    }
                    break;
            }
        }
        public override string ToString() => $"Jméno : {Jmeno}\nVěk : {Vek}\nDatum narození : {DatumNarozeni.ToString("dd/MM/yyyy")}\nRodné číslo : {RodneCislo}";
    }
}