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
        List<Pricing> PricingIndex;
        string strMembershipType;
        string strAdditionalFeatures;
        string strStartDate;
        public MembershipSales()
        {
            InitializeComponent();
            ClearScreen();

            PricingIndex = GetDataSetFromFile();

            foreach (Pricing p in PricingIndex)
                {
                if (p.CurrentAvailability == "Yes")
                {
                    cobMembershipType.Items.Add(p.MembershipTpe);

                    //additional feature new json file and class
                }
            }

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
            string strStartDate = dtpDatePicked.ToString("MM/dd/yyyy");




            //validate inputs
            if (strMembershipType == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (strAdditionalFeatures == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (dtpDatePicked < DateTime.Today)
            { MessageBox.Show("Please select a Starting Date Greater than or Equal to Current Date."); return; }


            //Search Data 
            Pricing MembershipSearch;
            MembershipSearch = PricingIndex.Where(p => p.MembershipTpe == strMembershipType).FirstOrDefault();

            
             txtQuoteDisplay.Text = "Membership Type: " + strMembershipType + Environment.NewLine + "Pricing: " + MembershipSearch.CurrentPrice;
              

            //use if statement to help find the pricing
            double dblMembershipPrice, dblAdditionalPrice, dblTotoalPrice, dblMembershipSubtotal;
            string strTotalPrice, strMemberPrice, strAdditionalPrice, strEndDate, strMembershipSubtotal;


            //Membership Type
            //need to update the result according to the new stored price


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
            {
                dblMembershipPrice = 0;
                dblMembershipSubtotal = 0;
            }

            strMemberPrice = dblMembershipPrice.ToString("C2");
            strMembershipSubtotal = dblMembershipSubtotal.ToString("C2");


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

            strAdditionalPrice = dblAdditionalPrice.ToString("C2");

            //Calculate the total price
            dblTotoalPrice = dblAdditionalPrice + dblMembershipSubtotal;
            strTotalPrice = dblTotoalPrice.ToString("C2");

            //Change End Date
            DateTime EndDate;

            if (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month")
                EndDate = dtpDatePicked.AddMonths(1);
            else
                EndDate = dtpDatePicked.AddYears(1);

            strEndDate = EndDate.ToString("MM/dd/yyyy");

            //display result in textbox
            txtQuoteDisplay.Text = "Membership Type: " + strMembershipType + Environment.NewLine +
                "Start Date: " + strStartDate + Environment.NewLine +
                "End Date: " + strEndDate + Environment.NewLine +
                "Membership Cost Per Month: " + strMemberPrice + Environment.NewLine +
                "SubTotal (Membership Price): " + strMembershipSubtotal + Environment.NewLine +
                    "Additional Feature(s): " + strAdditionalFeatures + Environment.NewLine +
                    "Additional Price Subtotal: " + strAdditionalPrice + Environment.NewLine +
                    "Total Price: " + strTotalPrice;


        }

        private void btnStartApplication_Click(object sender, RoutedEventArgs e)
        {
            MembershipSignup MembershipSignupWindow = new MembershipSignup();

            //preload info
            MembershipSignupWindow.MembershipType = strMembershipType;
            MembershipSignupWindow.StartDate = strStartDate;
            MembershipSignupWindow.AdditionalFeature = strAdditionalFeatures;
            MembershipSignupWindow.DisplayQuote();

            MembershipSignupWindow.Show();
            this.Close();
        }

        private void ClearScreen()
        {
            txtQuoteDisplay.Text = "";
            txtQuoteDisplay.Text = "";
            cobAdditionalFeatures.SelectedIndex = 0;
            cobMembershipType.SelectedIndex = 0;
            datStartDate.SelectedDate = DateTime.Today;

        }

   //load MemberPricing from Json Data
   private List<Pricing> GetDataSetFromFile()
        {
            List<Pricing> lstPricing = new List<Pricing>();
            string strFilePath = @"../../../Data/MembershipPricing.json";

            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                lstPricing = JsonConvert.DeserializeObject<List<Pricing>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Membership Pricing from file: " + ex.Message);
            }
            return lstPricing;
        }
    }
}
