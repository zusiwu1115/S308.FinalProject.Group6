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

        List<Members> MemberList;
        public MembershipSignup()
        {
            InitializeComponent();
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
            ComboBoxItem cbiMembershipType = (ComboBoxItem)cobMembershipType.SelectedItem;
            ComboBoxItem cbiAdditionalFeatures = (ComboBoxItem)cobAdditionalFeatures.SelectedItem;
            DateTime dtpDatePicked = (DateTime)datStartDate.SelectedDate;
            string strMembershipType = cbiMembershipType.Content.ToString();
            string strAdditionalFeatures = cbiAdditionalFeatures.Content.ToString();
            string strStartDate = dtpDatePicked.ToString("MM/dd/yyyy");

            //Change End Date
            string strEndDate;
            DateTime EndDate;

            if (strMembershipType == "Individual 1 Month" || strMembershipType == "Two Person 1 Month" || strMembershipType == "Family 1 Month")
                EndDate = dtpDatePicked.AddMonths(1);
            else
                EndDate = dtpDatePicked.AddYears(1);

            strEndDate = EndDate.ToString("MM/dd/yyyy");
            Members memNew;

            //Valid inputs
            if (strMembershipType == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (strAdditionalFeatures == "")
            { MessageBox.Show("Please select a Membership Type from the dropdown List."); return; }
            if (dtpDatePicked < DateTime.Today)
            { MessageBox.Show("Please select a Starting Date Greater than or Equal to Current Date."); return; }

            //Still need to valid the remaining fields

            //Same as MembershipSales need to get the result of New Pricing

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


            //Write input into Json Data
            string strFilePath = GetFilePath("json", true);

            try
            {
                StreamWriter writer = new StreamWriter(strFilePath, false);
                string JsonData = JsonConvert.SerializeObject(MemberList);
                writer.Write(JsonData);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in export process: " + ex.Message);
            }
            MessageBox.Show("Export completed!" + Environment.NewLine + "File Created: " + strFilePath);
        }

        private void btnReturnSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales MembershipSalesWindow = new MembershipSales();
            MembershipSalesWindow.Show();
            this.Close();
        }

        private string GetFilePath(string strExtension, bool bolWithTimeStamp)
        {
            string strFilePath = @"..\..\..\Data\Members";
            string strTimeStamp = DateTime.Now.Ticks.ToString();

            if (bolWithTimeStamp)
            {
                strFilePath += "_" + strTimeStamp;
            }

            strFilePath += "." + strExtension;
            return strFilePath;
        }
    }
}
