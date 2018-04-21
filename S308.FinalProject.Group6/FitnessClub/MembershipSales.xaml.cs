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
        public MembershipSales()
        {
            InitializeComponent();
            cobMembershipType.SelectedItem = "";

            //set date picker null

            cobAdditionalFeatures.SelectedItem = "";
            txtQuoteDisplay.Text = "";
        }



        private void btnMainMenu_Click(object sender, RoutedEventArgs e)
        {
            MainMenu MainMenuWindow = new MainMenu();
            MainMenuWindow.Show();
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            MembershipSignup MembershipSignupWindow = new MembershipSignup();
            MembershipSignupWindow.Show();
            this.Close();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cobMembershipType.SelectedItem = "";

            //set date picker null

            cobAdditionalFeatures.SelectedItem = "";
            txtQuoteDisplay.Text = "";
        }


    }
}
