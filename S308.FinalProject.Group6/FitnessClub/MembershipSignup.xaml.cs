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
            Casual = 1,
            Regular = 2,
            Intense = 3,
            Professional = 4
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

        string strTrainingType = "";
        public MembershipSignup()
        {
            InitializeComponent();
            MemberIndex = GetMemberDataSetFromFile();
            slbTrainingType.Value = 1;
            slbOverallHealth.Value = 2;

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
            int intAge = Convert.ToInt32(txtAge.Text);
            string strAge = intAge.ToString();
            double dblWeight = Convert.ToDouble(txtWeight.Text);
            string strWeight = dblWeight.ToString();
            double dblWeightLoss = Convert.ToDouble(txtWeightLoss.Text);
            string strWeightLoss = dblWeightLoss.ToString();
            double dblWeightManagement = Convert.ToDouble(txtWeightManagement.Text);
            string strWeightManagement = dblWeightManagement.ToString();
            Members memNew;

            //SlideBar Declaration
            double dblTrainingType = slbTrainingType.Value;


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


            //input validation
            if(strFirstName == null)
            { MessageBox.Show("Please enter a first name."); return; }
            if (strLastName == null)
            { MessageBox.Show("Please enter a last name."); return; }
            if (strCreditCardType == null)
            { MessageBox.Show("Please select a credit card type."); return; }
            if (strCardNumber == null)
            { MessageBox.Show("Please enter a credit card number."); return; }
            if (strPhone == null)
            { MessageBox.Show("Please enter a phone number."); return; }
            if (strEmail == null)
            { MessageBox.Show("Please enter an Email address."); return; }
            if (strGender == null)
            { MessageBox.Show("Please select a gender."); return; }
            if (intAge < 0 || intAge > 130)
            { MessageBox.Show("Please enter a viald Age range."); return; }
            if (dblWeight < 0 || dblWeight > 600)
            { MessageBox.Show("Please enter a viald Weight range."); return; }
            if (dblWeightLoss < 0 || dblWeight > 250)
            { MessageBox.Show("Please enter a viald Strength Training Weight Loss range."); return; }
            if (dblWeightManagement < 0 || dblWeightManagement > 400)
            { MessageBox.Show("Please enter a viald Weight Management range."); return; }

            //Declaration for email and phone validation
            bool bolＰarenthesesLeft, bolDash, bolParenthesesRight, bolEmptySpace;
            bool bolAt, bolPeriod;
            int intAt, intPeriod;
            string strBeforeAt, strAfterAt, strAfterPeriod;

            //Search character in strPhone
            bolＰarenthesesLeft = strPhone.Contains("(");
            bolParenthesesRight = strPhone.Contains(")");
            bolDash = strPhone.Contains("-");
            bolEmptySpace = strPhone.Contains(" ");


            //valid phone number
            if (strPhone.Length != 10 || bolDash == true || bolEmptySpace == true || bolParenthesesRight == true || bolＰarenthesesLeft == true)
            { MessageBox.Show("Please enter your phone number in as 10 digit without any formatting."); return; }

            //Search Character in strEmail
            bolAt = strEmail.Contains("@");
            bolPeriod = strEmail.Contains(".");

            //Valid Email to see if there is a @ and .
            if (bolAt == false || bolPeriod == false)
            { MessageBox.Show("Please enter a valid email address."); return; }


            //Search Character in strEmail
            intAt = strEmail.IndexOf("@");
            strBeforeAt = strEmail.Substring(0, intAt);
            intPeriod = strEmail.IndexOf(".");
            strAfterAt = strEmail.Substring((intAt + 1), intPeriod - (intAt + 1));
            strAfterPeriod = strEmail.Substring((intPeriod + 1));

            //Vaild Email to make sure the formating is correct
            if (intPeriod < intAt)
            { MessageBox.Show("Please enter a valid email address."); return; }
            if (strBeforeAt.Length < 1)
            { MessageBox.Show("Please enter a valid email address."); return; }
            if (strAfterAt.Length < 1)
            { MessageBox.Show("Please enter a valid email address."); return; }
            if (strAfterPeriod.Length < 2)
            { MessageBox.Show("Please enter a valid email address."); return; }

            //valid credit card number

           


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
            MessageBox.Show("Export Completed!" + Environment.NewLine + strFilePath + Environment.NewLine + Environment.NewLine +
                "First Name: " + strFirstName + Environment.NewLine +
                "Last Name: " + strLastName + Environment.NewLine +
                "Credit Card Type: " + strCreditCardType + Environment.NewLine +
                "Credit Card Number: " + strCardNumber + Environment.NewLine +
                "Phone: " + strPhone + Environment.NewLine +
                "Email: " + strEmail + Environment.NewLine +
                "Gender: " + strGender + Environment.NewLine +
                "Age: " + strAge + Environment.NewLine +
                "Weight: " + strWeight + Environment.NewLine +
                "Training Type: " + strTrainingType + Environment.NewLine +
                "Overall Health: " + strOverallHealth + Environment.NewLine +
                "Strength Training Weight Loss: " + strWeightLoss + Environment.NewLine +
                "Weight Management: " + strWeightLoss + Environment.NewLine +
                "Membership Type: " + MembershipType + Environment.NewLine +
                "Start Date: " + StartDate + Environment.NewLine +
                "End Date: " + ExpirationDate + Environment.NewLine +
                "SubTotal (Membership Price): " + Subtotal + Environment.NewLine +
                    "Additional Feature(s): " + AdditionalFeature + Environment.NewLine +
                    "Total Price: " + Total

                );
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

        private void slbTrainingType_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double dblTrainingType = slbTrainingType.Value;

            if (dblTrainingType == (double)TrainingType.Casual)
                lblTrainingTypeResult.Content = "Casual Training";
            else if (dblTrainingType == (double)TrainingType.Regular)
                lblTrainingTypeResult.Content = "Regular Training";
            else if (dblTrainingType == (double)TrainingType.Intense)
                lblTrainingTypeResult.Content = "Intense Training";
            else if (dblTrainingType == (double)TrainingType.Professional)
                lblTrainingTypeResult.Content = "Professional Training";

        }

        private void slbOverallHealth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double dblOverallHealth = slbOverallHealth.Value;

            if (dblOverallHealth == (double)OverallHealth.Poor)
                lblOverallHealthResult.Content = "Poor";
            else if (dblOverallHealth == (double)OverallHealth.LessWell)
                lblOverallHealthResult.Content = "Less Well";
            else if (dblOverallHealth == (double)OverallHealth.Good)
                lblOverallHealthResult.Content = "Good";
            else if (dblOverallHealth == (double)OverallHealth.VeryGood)
                lblOverallHealthResult.Content = "Very Good";
            else if (dblOverallHealth == (double)OverallHealth.Excellent)
                lblOverallHealthResult.Content = "Excellent";
        }
    }
}
