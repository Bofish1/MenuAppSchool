using System.Collections.Generic;
namespace Menu.Models
{
    public class FoodListViewModel: FoodViewModel
    {
        public string UserName { get; set; }
        public List<Food> Foods { get; set; }


        private List<Category> categories;
        public List<Category> Categories
        {
            get => categories;
            set
            {
                categories = value;
                categories.Insert(0, new Category { CategoryId = "all", Name = "All" });
            }
        }

        //method to help view determine active link
        public string CheckActiveCat(string c) =>
            c.ToLower() == ActiveCat.ToLower() ? "active" : "";
    }
}
