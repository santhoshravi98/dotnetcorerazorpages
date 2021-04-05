using Microsoft.AspNetCore.Mvc;
using RestaurantDataService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetcore_razor.Pages.ViewComponents
{
    public class CountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public CountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCount();
            return View(count);
        }
    }
}
