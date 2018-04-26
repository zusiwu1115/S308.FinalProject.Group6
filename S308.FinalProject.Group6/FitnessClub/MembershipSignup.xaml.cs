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
        string strTotalPrice, strMemberPrice, strAdditionalPrice, strEndDate, strMembershipSubtotal;


        //Declare the strings from MembershipSales to call in MembershiSignup Window
        public string MembershipType { get; set; }
        public string StartDate { get; set; }
        public string AdditionalFeature { get; set; }
        public string ExpirationDate { get; set; }
        public string Subtotal { get; set; }
        public string Total { get; set; }


        public MembershipSignup()
        {
            InitializeComponent();

          
        }

        //
        public void DisplayQuote()
        {
            lblMembershipTypePreload.Content = MembershipType;
            lblStartDatePreload.Content = StartDate;
            lblAdditionalFeaturePreload.Content = AdditionalFeature;
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

            //Stil need this declaration if the contents are preloaded and declared in the top?
            string strMembershipType = lblMembershipTypePreload.Content.ToString();
            string strAdditionalFeatures = lblAdditionalFeaturePreload.Content.ToString();
  

          
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

            //inputs preload from MembershipSales Window
            memNew.StartDate = strStartDate;
            memNew.ExpirationDate = strEndDate;
            memNew.AdditionalFeature = strAdditionalFeatures;
            memNew.Subtotal = strMembershipSubtotal;
            memNew.Total = strTotalPrice;
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
    }
}
