﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        public Restaurant Restaurant { get; set; }

        private readonly IRestaurant RestaurantData;

        public DetailModel(IRestaurant restaurantData)
        {
            //bind the interface to a field definition
            //the interface communicates with the DB... as we set in the appsettings
            this.RestaurantData = restaurantData;
        }


        public void OnGet(int id)
        {
            
            this.Restaurant = this.RestaurantData.GetById(id);

            //validation
        }
    }
}