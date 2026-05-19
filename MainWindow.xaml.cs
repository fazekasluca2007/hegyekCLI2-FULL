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
using System.IO;

namespace hegyekWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public class hegycsucs
    {
        public string nev { get; private set; }
        public string hegyseg { get; private set; }
        public int magassag { get; private set; }

        public hegycsucs(string sor)
        {
            string[] adatok = sor.Split(";");
            nev = adatok[0];
            hegyseg = adatok[1];
            magassag = int.Parse(adatok[2]);
        }
    }

    public partial class MainWindow : Window
    {
        List<hegycsucs> hegyek = new List<hegycsucs>();
        public MainWindow()
        {
            InitializeComponent();

            var sorok = File.ReadAllLines("hegyek.csv").Skip(1);
            foreach (var sor in sorok)
            {
                hegyek.Add(new hegycsucs(sor));
            }

            datagrid.ItemsSource = hegyek;
        }

        private void Hozzaad(object sender, RoutedEventArgs e)
        {
            if (int.Parse(magassag.Text) > 0 && int.Parse(magassag.Text) <2000)
            {
                hegyek.Add(new hegycsucs($"{nev.Text};{hegyseg.Text};{magassag.Text}"));
                datagrid.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Nem megfelelő értékek");
            }
        }
        
        private void Mentes(object sender, RoutedEventArgs e)
        {
            string adatok = "";
            foreach (var hegy in hegyek)
            {
                adatok +=  $"{hegy.nev};{hegy.hegyseg};{hegy.magassag}\n";
            }
            File.WriteAllText("hegycsucsok2.csv", adatok);
            MessageBox.Show("A mentés sikeresen megtörtént!");
        }
    }
}