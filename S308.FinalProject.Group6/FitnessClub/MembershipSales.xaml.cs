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
        List<AdditionalFeaturesPricing> AdditionalPricingIndex;
        string strMembershipType;
        string strAdditionalFeatures;
        string strStartDate;
        double dblTotoalPrice, dblMembershipSubtotal, dblMembershipPrice, dblAdditionalPrice;
        string strTotalPrice, strMemberPrice, strAdditionalPrice, strEndDate, strMembershipSubtotal;


        public MembershipSales()
        {
            InitializeComponent();
            ClearScreen();

            PricingIndex = GetDataSetFromFile();
            AdditionalPricingIndex = GetAdditionalDataSetFromFile();

            foreach (Pricing p in PricingIndex)
            {
                if (p.CurrentAvailability == "Yes")
                {
                    cobMembershipType.Items.Add(p.MembershipTpe);
                }
                //additional feature new json file and class
            }
            foreach (AdditionalFeaturesPricing a in AdditionalPricingIndex)
            {
                if (a.CurrentAvailability == "Yes")
                {
                    cobAdditionalFeatures.Items.Add(a.MembershipTpe);
                 }

            }
        }
    





        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
       //convert selected items in the input to string
           // ComboBoxItem cbiMembershipType = (ComboBoxItem)cobMembershipType.SelectedItem;
            //ComboBoxItem cbiAdditionalFeatures = (ComboBoxItem)cobAdditionalFeatures.SelectedItem;
            DateTime dtpDatePicked = (DateTime)datStartDate.SelectedDate;

            strMembershipType = cobMembershipType.SelectedItem.ToString();
            strAdditionalFeatures = cobAdditionalFeatures.SelectedItem.ToString();
            strStartDate = dtpDatePicked.ToString("MM/dd/yyyy");

            //validate inputs of Membership type, startdate and Additional Features
            if (strMembershipType == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (strAdditionalFeatures == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (dtpDatePicked < DateTime.Today)
            { MessageBox.Show("Please select a Starting Date Greater than or Equal to Current Date."); return; }

            //Search Data 
            Pricing MembershipSearch;
            MembershipSearch = PricingIndex.Where(p => p.MembershipTpe == strMembershipType).FirstOrDefault();
            double dblMembershipTypePrice = Convert.ToDouble(MembershipSearch.CurrentPrice);


            AdditionalFeaturesPricing AdditionalFeatureSearch;
            AdditionalFeatureSearch = AdditionalPricingIndex.Where(a => a.MembershipTpe == strAdditionalFeatures).FirstOrDefault();
            double dblAdditionalFeaturesPrice = Convert.ToDouble(AdditionalFeatureSearch.CurrentPrice);

            //Change End Date
            DateTime EndDate;

            if (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month")
                EndDate = dtpDatePicked.AddMonths(1);
            else
                EndDate = dtpDatePicked.AddYears(1);

            strEndDate = EndDate.ToString("MM/dd/yyyy");

            //use if statement to help find the pricing
            //Membership Type
            if (strMembershipType == "Individual 1 Month")
            {

                dblMembershipPrice = dblMembershipTypePrice;
                dblMembershipSubtotal = dblMembershipTypePrice;
            }

            else if (strMembershipType == "Individual 12 Months")
            {
                dblMembershipPrice = dblMembershipTypePrice/12;
                dblMembershipSubtotal = dblMembershipTypePrice;
            }

            else if (strMembershipType == "Two Person 1 Month")
            {
                dblMembershipPrice = dblMembershipTypePrice;
                dblMembershipSubtotal = dblMembershipTypePrice;
            }

            else if (strMembershipType == "Two Person 12 Months")
            {
                dblMembershipPrice = dblMembershipTypePrice / 12;
                dblMembershipSubtotal = dblMembershipTypePrice;
            }

            else if (strMembershipType == "Family 1 Month")
            {
                dblMembershipPrice = dblMembershipTypePrice;
                dblMembershipSubtotal = dblMembershipTypePrice;
            }

            else if (strMembershipType == "Family 12 Months")
            {
                dblMembershipPrice = dblMembershipTypePrice / 12;
                dblMembershipSubtotal = dblMembershipTypePrice;
            }
            else
            {
                dblMembershipTypePrice = 0;
                dblMembershipSubtotal = 0;
                dblMembershipPrice = 0;
            }

            strMemberPrice = dblMembershipPrice.ToString("C2");
            strMembershipSubtotal = dblMembershipTypePrice.ToString("C2");


            //Additional Price
            if (strAdditionalFeatures == "Personal Training Plan" && (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month"))
            {
                dblAdditionalPrice = dblAdditionalFeaturesPrice;
            }

            else if (strAdditionalFeatures == "Personal Training Plan" && (strMembershipType == "Individual 12 Months" || strMembershipType == "Two Person 12 Months" || strMembershipType == "Family 12 Months"))
            {
                dblAdditionalPrice = dblAdditionalFeaturesPrice * 12;
            }

            else if (strAdditionalFeatures == "Locker Rental" && (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month"))
            {
                dblAdditionalPrice = dblAdditionalFeaturesPrice;
            }

            else if (strAdditionalFeatures == "Locker Rental" && (strMembershipType == "Individual 12 Months" || strMembershipType == "Two Person 12 Months" || strMembershipType == "Family 12 Months"))
            {
                dblAdditionalPrice = dblAdditionalFeaturesPrice * 12;
            }

            else if (strAdditionalFeatures == "Personal Training + Locker Rental" && (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month"))
            {
                dblAdditionalPrice = dblAdditionalFeaturesPrice;
            }

            else if (strAdditionalFeatures == "Personal Training + Locker Rental" && (strMembershipType == "Individual 12 Months" || strMembershipType == "Two Person 12 Months" || strMembershipType == "Family 12 Months"))
            {
                dblAdditionalPrice = dblAdditionalFeaturesPrice * 12;
            }

            else
                dblAdditionalPrice = 0;

            strAdditionalPrice = dblAdditionalPrice.ToString("C2");

            //Calculate the total price
            dblTotoalPrice = dblAdditionalPrice + dblMembershipSubtotal;
            strTotalPrice = dblTotoalPrice.ToString("C2");


            //display result in textbox
            txtQuoteDisplay.Text = "Membership Type: " + strMembershipType + Environment.NewLine +
                "Start Date: " + strStartDate + Environment.NewLine +
                "End Date: " + strEndDate + Environment.NewLine +
                "Membership Cost Per Month: " + strMemberPrice + Environment.NewLine +
                "SubTotal (Membership Price): " + strMembershipSubtotal + Environment.NewLine +
                    "Additional Feature(s): " + strAdditionalFeatures + Environment.NewLine +
                    "Additional Price Subtotal: " + strAdditionalPrice + Environment.NewLine +
                    "Total Price: " + strTotalPrice;

            btnStartApplication.Visibility = Visibility.Visible;
        }


        private void btnStartApplication_Click(object sender, RoutedEventArgs e)
        {
            MembershipSignup MembershipSignupWindow = new MembershipSignup();

            //preload info - need work
            MembershipSignupWindow.MembershipType = strMembershipType;
            MembershipSignupWindow.StartDate = strStartDate;
            MembershipSignupWindow.AdditionalFeature = strAdditionalFeatures;
            MembershipSignupWindow.DisplayQuote();
            
            //If it is not displaying should i still include this part?
            MembershipSignupWindow.ExpirationDate = strEndDate;
            MembershipSignupWindow.Subtotal = strMembershipSubtotal;
            MembershipSignupWindow.Total = strTotalPrice;
            MembershipSignupWindow.Show();
            this.Close();
        }

        private void ClearScreen()
        {
            txtQuoteDisplay.Text = "";
            cobAdditionalFeatures.SelectedIndex = 0;
            cobMembershipType.SelectedIndex = 0;
            datStartDate.SelectedDate = DateTime.Today;
            btnStartApplication.Visibility = Visibility.Hidden;

        }

   //load MemberPricing from Json Data
   private List<Pricing> GetDataSetFromFile()
        {
            List<Pricing> lstPricing = new List<Pricing>();
            string strFilePath = @"../../../Data/MembershipPricing.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
                lstPricing = JsonConvert.DeserializeObject<List<Pricing>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Membership Pricing from file: " + ex.Message);
            }
            return lstPricing;
        }


        //load AdditionalPricing from Json Data
        private List<AdditionalFeaturesPricing> GetAdditionalDataSetFromFile()
        {
            List<AdditionalFeaturesPricing> lstAdditionalPricing = new List<AdditionalFeaturesPricing>();
            string strFilePath = @"../../../Data/AdditionalPricing.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
                lstAdditionalPricing = JsonConvert.DeserializeObject<List<AdditionalFeaturesPricing>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Membership Pricing from file: " + ex.Message);
            }
            return lstAdditionalPricing;
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearScreen();
        }
    }
}
