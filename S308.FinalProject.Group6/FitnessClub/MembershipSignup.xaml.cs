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

namespace FitnessClub
{
    /// <summary>
    /// Interaction logic for MembershipSignup.xaml
    /// </summary>
    public partial class MembershipSignup : Window
    {
        public MembershipSignup()
        {
            InitializeComponent();
        }

        private void btnQuote_Click(object sender, RoutedEventArgs e)
        {
            //Declear varibales
            string strFirstName;
            string strLastName;
            string strCardType;
            string strCreditCardNum;
            string strPhoneNum;
            string strEmail;
            string strGender;
            double dblAge;
            double dblWeight;

            //Validation of input
            if (!txtEmail.Text.Contains("@"))
            { MessageBox.Show("Please enter a valid email address");
                return;}
            Double.TryParse(txtAge.Text, out dblAge);
            { MessageBox.Show("Please enter a positive number of age");
                return; }
            Double.TryParse(txtWeight.Text, out dblWeight);
              { MessageBox.Show("Please enter a positive number of weight");
                return; }
            if (dblAge <= 0)
            { MessageBox.Show("Please enter a positive number of age");
                return;
            }
            if (dblWeight <= 0)
            { MessageBox.Show("Please enter a positive number of weight");
                return; }




        }
    }
}
