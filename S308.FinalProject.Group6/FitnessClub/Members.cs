using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace FitnessClub
{
    public class Members
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Age { get; set; }
        public string Weight { get; set; }
        public string MembershipType { get; set; }
        public string StartDate { get; set; }
        public string ExpirationDate { get; set; }
        public string Subtotal { get; set; }
        public string AdditionalFeature { get; set; }
        public string Total { get; set; }
        public string CreditCardType { get; set; }
        public string CardNumber { get; set; }
        public string AthleticPerformance { get; set; }
        public string OverallHealth { get; set; }
        public string StrengthTrainingWeightLoss { get; set; }
        public string WeightManagement { get; set; }

        public Members()
        {
            FirstName = "";
            LastName = "";
            PhoneNumber = "";
            Email = "";
            Gender = "";
            Age = "";
            Weight = "";
            MembershipType = "";
            StartDate = "";
            ExpirationDate = "";
            Subtotal = "";
            AdditionalFeature = "";
            Total = "";
            CreditCardType = "";
            CardNumber = "";
            AthleticPerformance = "";
            OverallHealth = "";
            StrengthTrainingWeightLoss = "";
            WeightManagement = "";
        }
    }
}
