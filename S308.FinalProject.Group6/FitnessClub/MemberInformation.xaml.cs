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
    /// Interaction logic for MemberInformation.xaml
    /// </summary>
    public partial class MemberInformation : Window
    {

        List<Members> memberIndex;


        public MemberInformation()
        {
            InitializeComponent();
            ClearScreen();

            memberIndex = GetDataSetFromFile();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private List<Members> GetDataSetFromFile()
        {
            List < Members > 1stMember = new List<Members>();

            string strFilePath = @"../../../Data/Members.json";

            try
            {
                string jsonData = File.ReadAllText(strFilePath);
                1stMember = JsonConvert.DeserializeObject<List<Members>>(jsonData);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error loading members information from file: " + ex.Message);
            }

            return 1stMember;
        }



        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            List<Members> memberSearch;

            //Declare Variables
            string strLastName = txtLastName.Text.Trim();
            string strPhone = txtPhoneNumber.Text.Trim();
            string strEmail = txtEmail.Text.Trim();

            lstMemberList.Items.Clear();

            memberSearch = memberIndex.Where
                (p => p.LastName.StartsWith(strLastName)
                && p.Email == strEmail
                && p.PhoneNumber == strPhone);

            foreach (Members p in memberSearch)
            {
                lstMemberList.Items.Add(p.FirstName);
            }

            lblNumFound.Content = "(" + memberSearch.Count.ToString() + ")";

        }



        private void btnDisplayReport_Click(object sender, RoutedEventArgs e)
        {
            DisplayReport DisplayReportWindow = new DisplayReport();
            DisplayReportWindow.Show();
            this.Close();
        }

        private void ClearScreen()
        {
            txtEmail.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
        }
    }
}
