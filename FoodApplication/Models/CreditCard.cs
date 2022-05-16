
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace FoodApplication.Models
{
    public class CreditCard
    {
        [DisplayName("Card number")]
        public int CardNumber { get; set; }

        [DisplayName("Name on card")]
        public string CardName { get; set; }

        [DisplayName("Expiry Date")]
        public string CardDate { get; set; }

        [DisplayName("Security Code")]
        public string CardCode { get; set; }


    }
}