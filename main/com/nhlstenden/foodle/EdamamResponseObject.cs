using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.main.com.nhlstenden.foodle
{
    public class EdamamResponseObject
    {
        public string text { get; set; }
        public object[] parsed { get; set; }
        public Hint[] hints { get; set; }
        public _Links _links { get; set; }


        public class _Links
        {
            public Next next { get; set; }
        }

        public class Next
        {
            public string title { get; set; }
            public string href { get; set; }
        }

        public class Hint
        {
            public Food food { get; set; }
            public Measure[] measures { get; set; }
        }

        public class Food
        {
            public string foodId { get; set; }
            public string label { get; set; }
            public Nutrients nutrients { get; set; }
            public string category { get; set; }
            public string categoryLabel { get; set; }
            public string image { get; set; }
            public string brand { get; set; }
        }

        public class Nutrients
        {
            public float ENERC_KCAL { get; set; }
            public float PROCNT { get; set; }
            public float FAT { get; set; }
            public float CHOCDF { get; set; }
            public float FIBTG { get; set; }
        }

        public class Measure
        {
            public string uri { get; set; }
            public string label { get; set; }
            public float weight { get; set; }
        }

        public List<Food> getFoods()
        {
            List<Food> foodList = new List<Food>();
            foreach (Hint hint in this.hints)
            {
                foodList.Add(hint.food);
            }
            return foodList;
        }

    }
}
