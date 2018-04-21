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
    /// Interaction logic for MembershipSales.xaml
    /// </summary>
    public partial class MembershipSales : Window
    {
        public MembershipSales()
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            txtQuoteDisplay.Text = "";
        }

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbiMembershipType = (ComboBoxItem)cobMembershipType.SelectedItem;
            ComboBoxItem cbiAdditionalFeatures = (ComboBoxItem)cobAdditionalFeatures.SelectedItem;
            DateTime dtpDatePicked = (DateTime)datStartDate.SelectedDate;

            string strMembershipType = cbiMembershipType.ToString();
            string strAdditionalFeatures = cbiAdditionalFeatures.ToString();
            string strStartDate = dtpDatePicked.ToString();

            txtQuoteDisplay.Text = strMembershipType + Environment.NewLine +
                    strAdditionalFeatures + Environment.NewLine +
                    strStartDate;


        }

        private void btnStartApplication_Click(object sender, RoutedEventArgs e)
        {
            MembershipSignup MembershipSignupWindow = new MembershipSignup();
            MembershipSignupWindow.Show();
            this.Close();
        }

        private void ClearScreen()
        {
            txtQuoteDisplay.Text = "";
            
        }
    }
}
