using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class FoodAmount
    {
        Food food;
        AmountType amountType;
        float amount;

        public FoodAmount(Food food, AmountType amountType, float amount)
        {
            this.food = food;
            this.amountType = amountType;
            this.amount = amount;
        }

        public float Amount { get => amount; set => amount = value; }
        internal AmountType AmountType { get => amountType; set => amountType = value; }
        internal Food Food { get => food; set => food = value; }
    }
}
