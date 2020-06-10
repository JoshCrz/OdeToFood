using System;

namespace OdeToFood.Core
{

    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CuisineType Cuisine { get; set; }

    }
}
