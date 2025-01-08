using BonAppMobileMaui.models;

namespace BonAppMobileMaui.Singletons
{
    public class FoodListSingleton
    {
        private static FoodListSingleton _instance;
        public List<FoodModel> FoodList { get; private set; }

        private FoodListSingleton() { }

        public static FoodListSingleton Instance => _instance ??= new FoodListSingleton();

        public void SetFoodList(List<FoodModel> foodList)
        {
            FoodList = foodList;
        }
    }
}