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
            cobMembershipType.SelectedItem = "";

            //set date picker null

            cobAdditionalFeatures.SelectedItem = "";
            txtQuoteDisplay.Text = "";
        }

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {   //Convert ComboBox selected item into string
            ComboBoxItem cbiSelectedItem = (ComboBoxItem)cobMembershipType.SelectedItem;
            string strMembershipType = cbiSelectedItem.Content.ToString();

            //Convert selected date into string
            DatePicker datBegin = (DatePicker)datStartDate;
            string strStartDate = datBegin.ToString();

            //Get the period of the Membership term
            int intMonth;
            intMonth = strStartDate.IndexOf("1");

            string strMonths;
            strMonths = strStartDate.Substring(intMonth, 2);

            int intMembershipMonths;
            intMembershipMonths = Convert.ToInt16(strMonths.Trim());

            //Write in End Date
            string strEndDate;

            //Membership cost from database
            double dblMembershipTypePrice;
            string strMembershipTypePrice = dblMembershipTypePrice.ToString();

            //SubTotal
            double dblSubtotal;

            //pull the membership type price from database
            dblSubtotal = dblMembershipTypePrice * intMembershipMonths;

            string strSubtotal = dblSubtotal.ToString();

            //Additional Feature
            ComboBoxItem cbiSelectedItem2 = (ComboBoxItem)cobAdditionalFeatures.SelectedItem;
            string strAdditionalFeatures = cbiSelectedItem2.Content.ToString();

            //Additional Features Price
            double dblFeaturePrice;
            switch (strAdditionalFeatures)
            {
                case "Personal Training Plan":
                    dblFeaturePrice = 5; break;
                case " Locker Rental":
                    dblFeaturePrice = 1; break;
                case "Personal Trainig + Locker Rental":
                    dblFeaturePrice = 6; break;
                default:
                    dblFeaturePrice = 0; break;
            }

            //Total Cost
            double dblTotalCost;
            dblTotalCost = dblSubtotal + dblFeaturePrice;

            string strTotalCost = dblTotalCost.ToString("C2");

            //Display Quote Result
            txtQuoteDisplay.Text = "Membership Type: " + strMembershipType + Environment.NewLine +
                                   "Start Date: " +strStartDate +Environment.NewLine +
                                   "End Date: " + strEndDate +Environment.NewLine +
                                   "Membership Cost per Month: " + strMembershipTypePrice +Environment.NewLine +
                                   "Subtotal: " + strSubtotal +Environment.NewLine +
                                   "AdditionalFeatures: " +strAdditionalFeatures +Environment.NewLine +
                                   "Total Cost: " + strTotalCost;

        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }


        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cobMembershipType.SelectedItem = "";

            //set date picker null

            cobAdditionalFeatures.SelectedItem = "";
            txtQuoteDisplay.Text = "";
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MembershipSignup MembershipSignupWindow = new MembershipSignup();
            MembershipSignupWindow.Show();
            this.Close();
        }
    }
}
