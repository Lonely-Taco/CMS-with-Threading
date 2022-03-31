using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdamamApiClient.edamam_client_api.filter.types
{
    public static class HealthTypes
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
            List<string> healthLabels = new List<string>();
            healthLabels.Add(ALCOHOL_FREE);
            healthLabels.Add(IMMUNO_SUPPORTIVE);
            healthLabels.Add(CELERY_FREE);
            healthLabels.Add(CRUSTACEAN_FREE);
            healthLabels.Add(DAIRY_FREE);
            healthLabels.Add(DASH);
            healthLabels.Add(EGG_FREE);
            healthLabels.Add(FISH_FREE);
            healthLabels.Add(FODMAP_FREE);
            healthLabels.Add(GLUTEN_FREE);
            healthLabels.Add(KETO_FRIENDLY);
            healthLabels.Add(KIDNEY_FRIENDLY);
            healthLabels.Add(KOSHER);
            healthLabels.Add(LOW_POTASSIUM);
            healthLabels.Add(LUPINE_FREE);
            healthLabels.Add(MEDITERRANEAN);
            healthLabels.Add(MUSTARD_FREE);
            healthLabels.Add(LOW_FAT_ABS);
            healthLabels.Add(NO_OIL_ADDED);
            healthLabels.Add(LOW_SUGAR);
            healthLabels.Add(PALEO);
            healthLabels.Add(PEANUT_FREE);
            healthLabels.Add(PECATARIAN);
            healthLabels.Add(PORK_FREE);
            healthLabels.Add(RED_MEAT_FREE);
            healthLabels.Add(SESAME_FREE);
            healthLabels.Add(SHELLFISH_FREE);
            healthLabels.Add(SOY_FREE);
            healthLabels.Add(SUGAR_CONSCIOUS);
            healthLabels.Add(TREE_NUT_FREE);
            healthLabels.Add(VEGAN);
            healthLabels.Add(VEGETARIAN);
            healthLabels.Add(WHEAT_FREE);
            return healthLabels;
        }
    }
}