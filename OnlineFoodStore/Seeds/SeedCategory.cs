using OnlineFoodStore.Models;
using OnlineFoodStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineFoodStore.Seeds
{
//InMemory Database


    public class SeedCategory : ICategory
{
    private IEnumerable<Category> categoryList;

    public SeedCategory()
    {

        categoryList = new List<Category>
            {
               new Category
                {
                    Name = "Vegetable",
                    Description="All vegetables and legumes/beans foods"
                },
                new Category
                {
                    Name = "Fruit",
                    Description="All fruits"
                },
                new Category
                {
                    Name = "Grain",
                    Description="Grain (cereal) foods, mostly wholegrain and/or high cereal fibre varieties"
                },
                new Category
                {
                    Name="Meat",
                    Description="Lean meats and poultry, fish, eggs, tofu, nuts and seeds and legumes/beans"
                },
                new Category
                {
                    Name="Milk",
                    Description="Milk, yoghurt cheese and/or alternatives, mostly reduced fat"
                }
            };
    }

    public IEnumerable<Category> GetAll()
    {
        return categoryList;
    }

    public Category GetById(int id)
    {
        return categoryList.FirstOrDefault(c => c.Id == id);
    }
}
}
