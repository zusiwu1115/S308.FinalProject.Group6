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

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for DisplayReport.xaml
    /// </summary>
    public partial class DisplayReport : Window
    {
        public DisplayReport()
        {
            InitializeComponent();
            ClearScreen();
        }

        private void btnNewSearch_Click(object sender, RoutedEventArgs e)
        {
            MemberInformation MemberInformationWindow = new MemberInformation();
            MemberInformationWindow.Show();
            this.Close();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void ClearScreen()
        {
            lblAgeResult.Content = "";
            lblAdditionalFeaturesResult.Content = "";
            lblEmailResult.Content = "";
            lblExpirationDateResult.Content = "";
            lblFirstNameResult.Content = "";
            lblGenderResult.Content = "";
            lblLastNameResult.Content = "";
            lblMembershipCostResult.Content = "";
            lblMembershipTypeResult1.Content = "";
            lblPerformanceResult.Content = "";
            lblPhoneResult.Content = "";
            lblStartDateResult.Content = "";
            lblSubtotalResult.Content = "";
            lblTotalResult.Content = "";
            lblWeightLossResult.Content = "";
            lblWeightManagementResult.Content = "";
            lblWeightResult.Content = "";
        }
            
    }
}
