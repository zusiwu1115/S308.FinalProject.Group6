//S308_Group 6: Jennie Chen, Guanzhou Wang, Joe Wu


//Image Source
//Logo: https://www.pinterest.com/pin/466826317610586354

//Background Picture: https://www.vcg.com/creative/1002945974


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
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void btnMembershipSales_Click(object sender, RoutedEventArgs e)
        {
            MembershipSales MembershipSalesWindow = new MembershipSales();
            MembershipSalesWindow.Show();
            this.Close();
        }
        private void btnPricingManagement_Click(object sender, RoutedEventArgs e)
        {
            PricingManagement PricingManagementWindow = new PricingManagement();
            PricingManagementWindow.Show();
            this.Close();
        }

        private void btnMemberInformation_Click(object sender, RoutedEventArgs e)
        {
            MemberInformation MemberInfomationWindow = new MemberInformation();
            MemberInfomationWindow.Show();
            this.Close();
        }


    }
}
