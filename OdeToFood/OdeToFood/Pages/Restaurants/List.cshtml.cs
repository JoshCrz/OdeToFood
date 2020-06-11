using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {

        private readonly IConfiguration Config;
        private readonly IRestaurant restaurantData;

        public string Message { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }

        //this turns the property into both an input and outut property
        //it tells the system that when http request is made, there should be something which populates this
        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set; }

        //constructor is now referencing my interface, my interface knows how to retrieve data
        public ListModel(IConfiguration config, IRestaurant restaurantData)
        {
            Config = config;            
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            this.Message = this.Config["Message"];

            //call the method from the interface to get all restaurants
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
            
        }
    }
}