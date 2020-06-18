using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent
        : ViewComponent
    {

        private readonly IRestaurant RestaurantData;

        public RestaurantCountViewComponent(IRestaurant RestaurantData)
        {
            this.RestaurantData = RestaurantData;
        }
        
        public IViewComponentResult Invoke()
        {
            var count = RestaurantData.GetCountOfRestaurants();
            return View(count);
        }
        
    }
}
