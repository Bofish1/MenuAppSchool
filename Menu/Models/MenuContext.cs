using Microsoft.EntityFrameworkCore;
namespace Menu.Models
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions<MenuContext> options): base(options)
        {

        }

        public DbSet<Food> Foods { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "A", Name = "Appetizers"},
                new Category { CategoryId = "B", Name = "Burgers"},
                new Category { CategoryId = "D", Name = "Desserts"},
                new Category { CategoryId = "S", Name = "Sandwiches and Salads"}
                );
            modelBuilder.Entity<Food>().HasData(
                new Food
                {
                    FoodId = 1,
                    Name = "Cheese Burger",
                    Description = "1/2lb Angus Patty Between a Sesame seed bun.",
                    ImagePath = "burger.jpeg",
                    Price = 9.99m,
                    CategoryId = "B"
                },
                new Food
                {
                    FoodId = 2,
                    Name = "Open-Face Ham Sandwich",
                    Description = "Hot Ham and cheese on open faced french bread.",
                    Price = 8.99m,
                    ImagePath = "burger.jpeg",
                    CategoryId = "S"

                    
                },
                new Food
                {
                    FoodId = 3,
                    Name = "House Salad",
                    Description = "Lettuce,Tomatoe,Red Onion, and Artichoke Hearts tossed in Italian Dressing.",
                    Price = 7.99m,
                    ImagePath = "burger.jpeg",
                    CategoryId = "S"

                }


                );
        }
    }
}
