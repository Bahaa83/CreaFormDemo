using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CreaFormDemo.Entitys.LifestyleModel.Habits
{
    public class ProgramPlan
    {
        [Key]
        public int ID { get; set; }
        public int ProgramNumber { get; set; }
        public string ProgramName { get; set; }
        public string Description { get; set; }
        public string Water { get; set; }
        public string Tea { get; set; }
        public string WholeGrains { get; set; }
        public string FatsOils1 { get; set; }
        public string CookFromScratch { get; set; }
        public string GentleCooking { get; set; }
        public string BirdLeanFishShellFish { get; set; }
        public string FatFish1 { get; set; }
        public string Egg { get; set; }
        public string DarkGreenLeafyVegetables { get; set; }
        public string Legumes { get; set; }
        public string VegetablesOver { get; set; }
        public string Fruit { get; set; }
        public string Berries { get; set; }
        public string NutsAlmondsSeedsNatural { get; set; }
        public string Herbs { get; set; }
        public string Variation { get; set; }
        public string SweetDrinks { get; set; }
        public string SweetsSugaryFoods { get; set; }
        public string RefinedGrain { get; set; }
        public string FatsOils2 { get; set; }
        public string FastFoodReadyMealsSemiFinishedProducts { get; set; }
        public string DestructiveCooking { get; set; }
        public string ProcessedMeat { get; set; }
        public string FatFish2 { get; set; }
        public string Coffee { get; set; }
        public string DairyProducts { get; set; }
        public string RootVegetablesSome { get; set; }
        public string RedMeat { get; set; }
        public string MealHabits { get; set; }
        public string RecoveryStress { get; set; }
        public string Stimulants { get; set; }
        public string PhysicalActivity { get; set; }
        public string FoodAsMedicine { get; set; }
        public string Variousips { get; set; }
        public IEnumerable<ProgramsChoise>  programsChoises { get; set; }

    }
}
