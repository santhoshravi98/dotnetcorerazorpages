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
    }
    public class RestaurantDataStore : IRestaurantData
    {
        public List<Restaurant> Restaurants { get; set; }
        public RestaurantDataStore()
        {
            Restaurants = new List<Restaurant>()
            {
                new Restaurant{Id = 1, Name = "Chennai Cafe", Location = "Chennai",Type=Type.SouthIndian},
                 new Restaurant{Id = 1, Name = "Kochi Cafe", Location = "Kochi",Type=Type.NorthIndian},
                  new Restaurant{Id = 1, Name = "Kolkata Cafe", Location = "Kolkata",Type=Type.SouthIndian},
                   new Restaurant{Id = 1, Name = "Mumbai Cafe", Location = "Mumbai",Type=Type.NorthIndian},
                    new Restaurant{Id = 1, Name = "Delhi Cafe", Location = "Delhi",Type=Type.SouthIndian}
            };
        }
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in Restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

    }
}
