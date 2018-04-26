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
        List<Members> MemberIndex;
        //Declare the strings from MembershipSales to call in MembershiSignup Window
        public string MembershipType { get; set; }
        public string StartDate { get; set; }
        public string AdditionalFeature { get; set; }
        public string ExpirationDate { get; set; }
        public string Subtotal { get; set; }
        public string Total { get; set; }

        enum TrainingType
        {
            Casual = 0,
            Regular = 1,
            Intense = 2,
            Professional = 3
        };

        //SlideBar Value Declaration
        enum OverallHealth
        {
            Poor = 0,
            LessWell = 1,
            Good = 2,
            VeryGood = 3,
            Excellent = 4
        };
        public MembershipSignup()
        {
            InitializeComponent();
            MemberIndex = GetMemberDataSetFromFile();

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
            string strWeightLoss = txtWeightLoss.Text.Trim();
            string strWeightManagement = txtWeightManagement.Text.Trim();
            Members memNew;

            //SlideBar Declaration
            double dblTrainingType = slbTrainingType.Value;
            string strTrainingType = "";

            if (dblTrainingType == (double)TrainingType.Casual)
                strTrainingType = TrainingType.Casual.ToString();
            else if (dblTrainingType == (double)TrainingType.Regular)
                strTrainingType = TrainingType.Regular.ToString();
            else if (dblTrainingType == (double)TrainingType.Intense)
                strTrainingType = TrainingType.Intense.ToString();
            else if (dblTrainingType == (double)TrainingType.Professional)
                strTrainingType = TrainingType.Professional.ToString();

            double dblOverallHealth = slbOverallHealth.Value;
            string strOverallHealth = "";

            if (dblOverallHealth == (double)OverallHealth.Poor)
                strOverallHealth = OverallHealth.Poor.ToString();
            else if (dblOverallHealth == (double)OverallHealth.LessWell)
                strOverallHealth = OverallHealth.LessWell.ToString();
            else if (dblOverallHealth == (double)OverallHealth.Good)
                strOverallHealth = OverallHealth.Good.ToString();
            else if (dblOverallHealth == (double)OverallHealth.VeryGood)
                strOverallHealth = OverallHealth.VeryGood.ToString();
            else if (dblOverallHealth == (double)OverallHealth.Excellent)
                strOverallHealth = OverallHealth.Excellent.ToString();


            //Still need to valid the remaining fields - need work


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
            memNew.AthleticPerformance = strTrainingType;
            memNew.OverallHealth = strOverallHealth;
            memNew.StrengthTrainingWeightLoss = strWeightLoss;
            memNew.WeightManagement = strWeightManagement;
            memNew.MembershipType = MembershipType;

            //inputs preload from MembershipSales Window
            memNew.StartDate = StartDate;
            memNew.ExpirationDate = ExpirationDate;
            memNew.AdditionalFeature = AdditionalFeature;
            memNew.Subtotal = Subtotal;
            memNew.Total = Total;

            MemberIndex.Add(memNew);
            
            //Write inputs into Json Data
            string strFilePath = @"../../../Data/Members.json";

            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, false);
                string jsonData = JsonConvert.SerializeObject(MemberIndex);
                writer.Write(jsonData);
                writer.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in export process: " + ex.Message);
            }
            MessageBox.Show("Export Completed!" + Environment.NewLine + strFilePath);
        }

       


        private void btnReturnSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales MembershipSalesWindow = new MembershipSales();
            MembershipSalesWindow.Show();
            this.Close();
        }


        //load AdditionalPricing from Json Data
        private List<Members> GetMemberDataSetFromFile()
        {
            List<Members> lstMembers = new List<Members>();
            string strFilePath = @"../../../Data/Members.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
                lstMembers = JsonConvert.DeserializeObject<List<Members>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Members from file: " + ex.Message);
            }
            return lstMembers;
        }
    }
}
