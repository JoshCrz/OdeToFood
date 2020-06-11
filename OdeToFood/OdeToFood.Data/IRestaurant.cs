using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurant
    {
        IEnumerable<Restaurant> GetAll();
    }

    //in memory data class
    public class InMemoryRestaurantData : IRestaurant
    {

        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Scott's Pizza", Location = "Maryland", Cuisine = CuisineType.Italian, Description = "A mighty pizzaria"},
                new Restaurant {Id = 2, Name = "Cinnamon Club", Location = "Sydney", Cuisine = CuisineType.Mexican, Description = "A spicy dessert?..."},
                new Restaurant {Id = 3, Name = "Raj's", Location = "London", Cuisine = CuisineType.Indian, Description = "Curry to make your head explode"}
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //linq query
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }

}
