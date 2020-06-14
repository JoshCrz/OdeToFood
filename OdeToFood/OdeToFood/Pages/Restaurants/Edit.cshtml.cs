using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Restaurant Restaurant { get; set; }  

        private readonly IRestaurant RestaurantData;

        private readonly IHtmlHelper HtmlHelper;

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurant restaurantData, IHtmlHelper htmlHelper)
        {
            RestaurantData = restaurantData;

            this.HtmlHelper = htmlHelper;           
        }

        //responds to an onGet method
        //int? is nullable
        public IActionResult OnGet(int? id)
        {
            Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
            if (id.HasValue)
            {
                this.Restaurant = RestaurantData.GetById(id.Value);
            } else
            {
                Restaurant = new Restaurant();                
            }
            

            if(this.Restaurant != null)
            {
                return Page();
            } else
            {
                return RedirectToPage("./NotFound");
            }

        }

        public IActionResult OnPost()
        {
            //requirements have been set on the entity
            //check the model state for validation

            if (!ModelState.IsValid)
            {
                Cuisines = HtmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }            

            if(Restaurant.Id > 0)
            {
                RestaurantData.Update(Restaurant);
            }
            else
            {
                RestaurantData.Add(Restaurant);
            }

            RestaurantData.Commit();
            TempData["Message"] = "Restaurant saved!";
            return RedirectToPage("./Detail", new { id = this.Restaurant.Id });
            //using the new{}, creates an anonymously typed object

        }

    }
}