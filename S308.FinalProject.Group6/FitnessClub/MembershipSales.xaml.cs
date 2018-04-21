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

            //convert selected items in the input to string
            ComboBoxItem cbiMembershipType = (ComboBoxItem)cobMembershipType.SelectedItem;
            ComboBoxItem cbiAdditionalFeatures = (ComboBoxItem)cobAdditionalFeatures.SelectedItem;
            DateTime dtpDatePicked = (DateTime)datStartDate.SelectedDate;

            string strMembershipType = cbiMembershipType.Content.ToString();
            string strAdditionalFeatures = cbiAdditionalFeatures.Content.ToString();
            string strStartDate = dtpDatePicked.ToString();


            //validate inputs
            if (strMembershipType == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (strAdditionalFeatures == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (dtpDatePicked < DateTime.Now)
            { MessageBox.Show("Please select a Starting Date Greater than or Equal to Current Date."); return; }

            //Lookup Pricing in Json Data


            //use if statement to help find the pricing
            double dblMembershipPrice, dblAdditionalPrice, dblTotoalPrice, dblMembershipSubtotal;
            string strTotalPrice, strMemberPrice, strAdditionalPrice, strEndDate, strMembershipSubtotal;


            //Membership Type
            if (strMembershipType == "Individual 1 Month")
            {
                dblMembershipPrice = 9.99;
                dblMembershipSubtotal = 9.99;
            }

            else if (strMembershipType == "Individual 12 Months")
            {
                dblMembershipPrice = 100.00 / 12;
                dblMembershipSubtotal = 100.00;
            }

            else if (strMembershipType == "Two Person 1 Month")
            {
                dblMembershipPrice = 14.99;
                dblMembershipSubtotal = 14.99;
            }

            else if (strMembershipType == "Two Person 12 Months")
            {
                dblMembershipPrice = 150.00 / 12;
                dblMembershipSubtotal = 150.00;
            }

            else if (strMembershipType == "Family 1 Month")
            {
                dblMembershipPrice = 19.99;
                dblMembershipSubtotal = 19.99;
            }

            else if (strMembershipType == "Family 12 Months")
            {
                dblMembershipPrice = 200.00 / 12;
                dblMembershipSubtotal = 200.00;
            }
            else
                dblMembershipPrice = 0;
                dblMembershipSubtotal = 0;


            strMemberPrice = dblMembershipPrice.ToString();
            strMembershipSubtotal = dblMembershipSubtotal.ToString();


            //Additional Price
            if (strAdditionalFeatures == "Personal Training Plan" && (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month"))
            {
                dblAdditionalPrice = 5.00;
            }

            else if (strAdditionalFeatures == "Personal Training Plan" && (strMembershipType == "Individual 12 Months" || strMembershipType == "Two Person 12 Months" || strMembershipType == "Family 12 Months"))
            {
                dblAdditionalPrice = 5.00 * 12;
            }

            else if (strAdditionalFeatures == "Locker Rental" && (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month"))
            {
                dblAdditionalPrice = 1.00;
            }

            else if (strAdditionalFeatures == "Locker Rental" && (strMembershipType == "Individual 12 Months" || strMembershipType == "Two Person 12 Months" || strMembershipType == "Family 12 Months"))
            {
                dblAdditionalPrice = 1.00 * 12;
            }

            else if (strAdditionalFeatures == "Personal Training + Locker Rental" && (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month"))
            {
                dblAdditionalPrice = 6.00;
            }

            else if (strAdditionalFeatures == "Personal Training + Locker Rental" && (strMembershipType == "Individual 12 Months" || strMembershipType == "Two Person 12 Months" || strMembershipType == "Family 12 Months"))
            {
                dblAdditionalPrice = 6.00 * 12;
            }

            else
                dblAdditionalPrice = 0;

            strAdditionalPrice = dblAdditionalPrice.ToString();

            //Calculate the total price
            dblTotoalPrice = dblAdditionalPrice + dblMembershipPrice;
            strTotalPrice = dblTotoalPrice.ToString();

            //Change End Date
            DateTime EndDate;

            if (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month")
                EndDate = dtpDatePicked.AddMonths(1);
            else
                EndDate = dtpDatePicked.AddYears(1);

            strEndDate = EndDate.ToString();

            //display result in textbox
            txtQuoteDisplay.Text = "Membership Type: " + strMembershipType + Environment.NewLine +
                "Start Date: " + strStartDate + Environment.NewLine +
                "End Date: " + strEndDate + Environment.NewLine +
                "Membership Cost Per Month: " + strMemberPrice + Environment.NewLine +
                "SubTotal (Membership Price): " + strMembershipSubtotal + Environment.NewLine +
                    "Additional Feature(s): " + strAdditionalFeatures + Environment.NewLine +
                    "Additional Price Per Month: " + strAdditionalPrice + Environment.NewLine +
                    "Total Price: " + strTotalPrice;


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
