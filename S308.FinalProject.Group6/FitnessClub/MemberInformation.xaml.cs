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
using Newtonsoft.Json;
using System.IO;

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MemberInformation.xaml
    /// </summary>
    public partial class MemberInformation : Window
    {
        public MemberInformation()
        {
            InitializeComponent();
            ClearScreen();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDisplayReport_Click(object sender, RoutedEventArgs e)
        {
            DisplayReport DisplayReportWindow = new DisplayReport();
            DisplayReportWindow.Show();
            this.Close();
        }

        private void ClearScreen()
        {
            txtEmail.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
        }
    }
}
