using OdeToFood.Core;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace OdeToFood.Data
{
    public class SqlRestaurantData : IRestaurant
    {
        private readonly OdeToFoodDbContext db;

        public SqlRestaurantData(OdeToFoodDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            //db.Restaurants.Add()
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public int Commit()
        {
            //this method returns the number of rows affected by the changes
            return db.SaveChanges();
            
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);

            if(restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }

            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            //linq
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant restaurantToUpdate)
        {
            var entity = db.Restaurants.Attach(restaurantToUpdate);
            entity.State = EntityState.Modified;
            return restaurantToUpdate;
        }
    }


}
