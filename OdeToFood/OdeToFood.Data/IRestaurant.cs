using System;
using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;

namespace OdeToFood.Data
{
    public interface IRestaurant
    {
        //IEnumerable<Restaurant> GetAll();

        //this function superseeds the one above
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

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

        /*
        public IEnumerable<Restaurant> GetAll()
        {
            //linq query
            return from r in restaurants
                   orderby r.Name
                   select r;
        }*/


        //optional parameter by specifying name = null
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            //linq query
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

    }

}
