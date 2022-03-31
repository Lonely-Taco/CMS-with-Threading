using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdamamApiClient.edamam_client_api.filter.types
{
    public static class HealthLabel
    {
        public static readonly string ALCOHOL_FREE="alcohol-free";
        public static readonly string IMMUNO_SUPPORTIVE="immuno-supportive";
        public static readonly string CELERY_FREE="celery-free";
        public static readonly string CRUSTACEAN_FREE="crustacean-free";
        public static readonly string DAIRY_FREE="dairy-free";
        public static readonly string DASH="DASH";
        public static readonly string EGG_FREE="egg-free";
        public static readonly string FISH_FREE="fish-free";
        public static readonly string FODMAP_FREE="fodmap-free";
        public static readonly string GLUTEN_FREE="gluten-free";
        public static readonly string KETO_FRIENDLY="keto-friendly";
        public static readonly string KIDNEY_FRIENDLY="kidney-friendly";
        public static readonly string KOSHER="kosher";
        public static readonly string LOW_POTASSIUM="low-potassium";
        public static readonly string LUPINE_FREE="lupine-free";
        public static readonly string MEDITERRANEAN="Mediterranean";
        public static readonly string MUSTARD_FREE="mustard-free";
        public static readonly string LOW_FAT_ABS="low-fat-abs";
        public static readonly string NO_OIL_ADDED="No-oil-added";
        public static readonly string LOW_SUGAR="low-sugar";
        public static readonly string PALEO="paleo";
        public static readonly string PEANUT_FREE="peanut-free";
        public static readonly string PECATARIAN="pecatarian";
        public static readonly string PORK_FREE="pork-free";
        public static readonly string RED_MEAT_FREE="red-meat-free";
        public static readonly string SESAME_FREE="sesame-free";
        public static readonly string SHELLFISH_FREE="shellfish-free";
        public static readonly string SOY_FREE="soy-free";
        public static readonly string SUGAR_CONSCIOUS="sugar-conscious";
        public static readonly string TREE_NUT_FREE="tree-nut-free";
        public static readonly string VEGAN="vegan";
        public static readonly string VEGETARIAN="vegetarian";
        public static readonly string WHEAT_FREE="wheat-free";

        public static List<string> getHealthLabels()
        {
            return new List<string>
            {
                ALCOHOL_FREE,
                IMMUNO_SUPPORTIVE,
                CELERY_FREE,
                CRUSTACEAN_FREE,
                DAIRY_FREE,
                DASH,
                EGG_FREE,
                FISH_FREE,
                FODMAP_FREE,
                GLUTEN_FREE,
                KETO_FRIENDLY,
                KIDNEY_FRIENDLY,
                KOSHER,
                LOW_POTASSIUM,
                LUPINE_FREE,
                MEDITERRANEAN,
                MUSTARD_FREE,
                LOW_FAT_ABS,
                NO_OIL_ADDED,
                LOW_SUGAR,
                PALEO,
                PEANUT_FREE,
                PECATARIAN,
                PORK_FREE,
                RED_MEAT_FREE,
                SESAME_FREE,
                SHELLFISH_FREE,
                SOY_FREE,
                SUGAR_CONSCIOUS,
                TREE_NUT_FREE,
                VEGAN,
                VEGETARIAN,
                WHEAT_FREE
            };
        }
    }
}