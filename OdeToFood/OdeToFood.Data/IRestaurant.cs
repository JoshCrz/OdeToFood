using System.Collections.Generic;
using System.Text;
using OdeToFood.Core;
using Microsoft.VisualBasic.CompilerServices;

namespace OdeToFood.Data
{
    public interface IRestaurant
    {
        //IEnumerable<Restaurant> GetAll();

        //this function superseeds the one above
        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetById(int id);

        Restaurant Update(Restaurant restaurantToUpdate);

        Restaurant Add(Restaurant newRestaurant);

        Restaurant Delete(int id);

        int GetCountOfRestaurants();

        int Commit();

    }

}
