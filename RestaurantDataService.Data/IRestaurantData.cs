using RestaurantData.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Type = RestaurantData.Core.Type;

namespace RestaurantDataService.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
        Restaurant UpdateRestaurant(Restaurant restaurant);
        public void AddRestaurant(Restaurant restaurant);
        public Restaurant DeleteRestaurant(int id);
        public int GetCount();
    }
    public class RestaurantDataStore : IRestaurantData
    {
        public List<Restaurant> Restaurants { get; set; }
        public RestaurantDataStore()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Chennai Cafe", Location = "Chennai",Type=Type.SouthIndian},
                 new Restaurant{Id = 2, Name = "Kochi Cafe", Location = "Kochi",Type=Type.NorthIndian},
                  new Restaurant{Id = 3, Name = "Kolkata Cafe", Location = "Kolkata",Type=Type.SouthIndian},
                   new Restaurant{Id = 4, Name = "Mumbai Cafe", Location = "Mumbai",Type=Type.NorthIndian},
                    new Restaurant{Id = 5, Name = "Delhi Cafe", Location = "Delhi",Type=Type.SouthIndian}
            };
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return Restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant UpdateRestaurant(Restaurant restaurant)
        {
            var res = Restaurants.SingleOrDefault(r => r.Id == restaurant.Id);
            if (res != null)
            {
                res.Name = restaurant.Name;
                res.Location = restaurant.Location;
                res.Type = restaurant.Type;
            }
            return res;
        }

        public void AddRestaurant(Restaurant restaurant)
        {
            restaurant.Id = Restaurants.Max(r => r.Id) + 1;
            Restaurants.Add(restaurant);
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = Restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
                Restaurants.Remove(restaurant);
            return restaurant;
        }

        public int GetCount()
        {
            return Restaurants.Count();
        }
    }

}
