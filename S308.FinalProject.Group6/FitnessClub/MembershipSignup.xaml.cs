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
    /// Interaction logic for MembershipSignup.xaml
    /// </summary>
    public partial class MembershipSignup : Window
    {
        List<Pricing> PricingIndex;
        List<AdditionalFeaturesPricing> AdditionalPricingIndex;
        string strMembershipType;
        string strAdditionalFeatures;
        string strStartDate;
        double dblTotoalPrice, dblMembershipSubtotal, dblMembershipPrice, dblAdditionalPrice;
        string strTotalPrice, strMemberPrice, strAdditionalPrice, strEndDate, strMembershipSubtotal;

        public string MembershipType { get; set; }
        public string StartDate { get; set; }
        public string AdditionalFeature { get; set; }

        //need to add in more - need work

        public MembershipSignup()
        {
            InitializeComponent();

           
        }
        public void DisplayQuote()
        {
            txtAge.Text = MembershipType;
        }


       private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void btnSignUp_Click(object sender, RoutedEventArgs e)
        {   //Declare Variables
            string strFirstName = txtFirstName.Text.Trim();
            string strLastName = txtLastName.Text.Trim();
            ComboBoxItem cbiCreditCardType = (ComboBoxItem)cobCreditCardType.SelectedItem;
            string strCreditCardType = cbiCreditCardType.Content.ToString();
            string strCardNumber = txtCardNumber.Text.Trim();
            string strPhone = txtPhone.Text.Trim();
            string strEmail = txtEmail.Text.Trim();
            ComboBoxItem cbiGender = (ComboBoxItem)cobGender.SelectedItem;
            string strGender = cbiGender.Content.ToString();
            string strAge = txtAge.Text.Trim();
            string strWeight = txtWeight.Text.Trim();
            ComboBoxItem cbiAthleticPerformance = (ComboBoxItem)cobAthleticPerformance.SelectedItem;
            string strAthlecticPerformance = cbiAthleticPerformance.Content.ToString();
            ComboBoxItem cbiOverallHealth = (ComboBoxItem)cobOverallHealth.SelectedItem;
            string strOverallHealth = cbiOverallHealth.Content.ToString();
            string strWeightLoss = txtWeightLoss.Text.Trim();
            string strWeightManagement = txtWeightManagement.Text.Trim();
            DateTime dtpDatePicked = (DateTime)datStartDate.SelectedDate;
            string strMembershipType = lblMembershipTypePreload.Content.ToString();
            string strAdditionalFeatures = lblAdditionalFeaturePreload.Content.ToString();
            string strStartDate = dtpDatePicked.ToString("MM/dd/yyyy");

            //Variables Declared from MembershipSales
            
            double dblTotoalPrice, dblMembershipSubtotal, dblMembershipPrice, dblAdditionalPrice;
            string strTotalPrice, strMemberPrice, strAdditionalPrice, strMembershipSubtotal;

            //Change End Date
            string strEndDate;
            DateTime EndDate;

            if (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month")
                EndDate = dtpDatePicked.AddMonths(1);
            else
                EndDate = dtpDatePicked.AddYears(1);

            strEndDate = EndDate.ToString("MM/dd/yyyy");
            Members memNew;




            //Still need to valid the remaining fields - need work

            //Preload - need work
            //Search Data 
            Pricing MembershipSearch;
            MembershipSearch = PricingIndex.Where(p => p.MembershipTpe == strMembershipType).FirstOrDefault();
            double dblMembershipTypePrice = Convert.ToDouble(MembershipSearch);


            AdditionalFeaturesPricing AdditionalFeatureSearch;
            AdditionalFeatureSearch = AdditionalPricingIndex.Where(a => a.MembershipTpe == strAdditionalFeatures).FirstOrDefault();
            double dblAdditionalFeaturesPrice = Convert.ToDouble(AdditionalFeatureSearch);

            //use if statement to help find the pricing
            //Membership Type
            if (strMembershipType == "Individual 1 Month")
            {

                dblMembershipPrice = dblMembershipTypePrice;
                dblMembershipSubtotal = dblMembershipTypePrice;
            }

            else if (strMembershipType == "Individual 12 Months")
            {
                dblMembershipPrice = dblMembershipTypePrice / 12;
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



            //instantiate a new member with user input
            memNew = new Members();
            memNew.FirstName = strFirstName;
            memNew.LastName = strLastName;
            memNew.CreditCardType = strCreditCardType;
            memNew.CardNumber = strCardNumber;
            memNew.PhoneNumber = strPhone;
            memNew.Email = strEmail;
            memNew.Gender = strGender;
            memNew.Age = strAge;
            memNew.Weight = strWeight;
            memNew.AthleticPerformance = strAthlecticPerformance;
            memNew.OverallHealth = strOverallHealth;
            memNew.StrengthTrainingWeightLoss = strWeightLoss;
            memNew.WeightManagement = strWeightManagement;
            memNew.MembershipType = strMembershipType;
            memNew.StartDate = strStartDate;
            memNew.ExpirationDate = strEndDate;
            memNew.AdditionalFeature = strAdditionalFeatures;

            //Add in iputs that are loaded from pervious page - need work
            memNew.Subtotal = strMembershipSubtotal;
        }




        private void btnReturnSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales MembershipSalesWindow = new MembershipSales();
            MembershipSalesWindow.Show();
            this.Close();
        }

        private List<Pricing> GetDataSetFromFile()
        {
            List<Pricing> lstPricing = new List<Pricing>();
            string strFilePath = @"../../../Data/MembershipPricing.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string strJsonData = reader.ReadToEnd();
                reader.Close();
                lstPricing = JsonConvert.DeserializeObject<List<Pricing>>(strJsonData);
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
                string strJsonData = reader.ReadToEnd();
                reader.Close();
                lstAdditionalPricing = JsonConvert.DeserializeObject<List<AdditionalFeaturesPricing>>(strJsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Membership Pricing from file: " + ex.Message);
            }
            return lstAdditionalPricing;
        }
    }
}
