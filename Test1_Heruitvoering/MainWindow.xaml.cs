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
//using System.Windows.Shapes;
using System.IO;

namespace Test1_Heruitvoering
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        string folderPath = @"D:\BACHELOR\2018-2019\AD 2\test1 opgave\";
        string folderPakbonnen = "pakbonnen";

        public MainWindow()
        {
            InitializeComponent();
            MIExporteren.IsEnabled = false;
        }

        public void AfsluitenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);

        }

        public void ImporterenMenuItem_Click(object sender, RoutedEventArgs e)
        {
            string lokatie = Path.Combine(folderPath, folderPakbonnen);
            var filenames = Directory.GetFiles(lokatie).Select(System.IO.Path.GetFileName);
            foreach (var item in filenames)
            {
                lstBestandslijst.Items.Add(item);
            }

        }

        public void ExporterenMenuItem_Click(object sender, RoutedEventArgs e)
        {


        }

        private void LstBestandslijst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string lokatie = Path.Combine(folderPath, folderPakbonnen);
            string bestanden = Path.Combine(lokatie, Convert.ToString(lstBestandslijst.SelectedItem).Trim());


            using (StreamReader inputstream = File.OpenText(lokatie))
            {
                string line;
                while ((line = inputstream.ReadLine()) != null)
                {
                    txtInhoudBestand.AppendText(line);
                    txtInhoudBestand.AppendText(Environment.NewLine);

                }

            }
            btnVerwerk.IsEnabled = true;
        }
    }
}
