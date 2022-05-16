using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodApplication.Models
{
    public interface PaymentCards
    {
        string CardNumber();
        string CardName();
        string CardDate();
        string CardCode();

    }
}