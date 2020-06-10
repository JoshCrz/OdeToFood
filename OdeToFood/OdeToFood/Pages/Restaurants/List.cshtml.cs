using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {

        private readonly IConfiguration Config;

        public string Message { get; set; }


        public ListModel(IConfiguration config)
        {
            Config = config;
        }

        public void OnGet()
        {
            this.Message = this.Config["Message"];
        }
    }
}