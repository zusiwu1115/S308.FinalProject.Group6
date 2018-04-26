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
    /// Interaction logic for PricingManagement.xaml
    /// </summary>
    public partial class PricingManagement : Window
    {
        public PricingManagement()
        {
            InitializeComponent();
        }

        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        //Declear Variable
        string strPricingType;

        //convert selected item in the input to string
        ComboBoxItem cbiMembershipType = (ComboBoxItem)cobMembershipType.SelectedItem;
        string strMembershipType = cbiMembershipType.Content.ToString();

        //validate inputs of Membership type, startdate and Additional Features
            if (cobMembershipType.SelectedIndex=0)
            { MessageBox.Show("Please select a Membership Type from the dropdown List.");
            return; }



        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
