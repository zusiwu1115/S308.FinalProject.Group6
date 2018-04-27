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

            memberIndex = GetMemberDataSetFromFile();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }


        private List<Members> GetMemberDataSetFromFile()
        {
            List<Members> lstMember = new List<Members>();
            string strFilePath = @"../../../Data/Members.json";

            try
            {
                StreamReader reader = new StreamReader(strFilePath);
                string jsonData = reader.ReadToEnd();
                reader.Close();
                lstMember = JsonConvert.DeserializeObject<List<Members>>(jsonData);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading Members from file: " + ex.Message);
            }
            return lstMember;
        }
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            

            //Declare Variables
            string strLastName = txtLastName.Text.Trim();
            string strPhone = txtPhoneNumber.Text.Trim();
            string strEmail = txtEmail.Text.Trim();

            lstMemberList.Items.Clear();

            Members memberSearch;
            memberSearch = memberIndex.Where
                (m => m.LastName.StartsWith(strLastName)
                && m.Email == strEmail
                && m.PhoneNumber == strPhone);

         

            foreach (Members m in memberSearch)
            {
                lstMemberList.Items.Add(m.FirstName);
            }

            lblNumFound.Content = "(" + memberSearch.Count.ToString() + ")";

        }


        private void ClearScreen()
        {
            txtEmail.Text = "";
            txtLastName.Text = "";
            txtPhoneNumber.Text = "";
        }
    }
}
