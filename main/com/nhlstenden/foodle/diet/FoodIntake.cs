using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    internal class FoodIntake : FoodAmount
    {
        DateTime dateOfIntake;

        public FoodIntake(Food food, AmountType amountType, float amount, DateTime dateOfIntake) : base(food, amountType, amount)
        {
            this.dateOfIntake = dateOfIntake;
        }

        public DateTime DateOfIntake { get => dateOfIntake; set => dateOfIntake = value; }
    }
}
