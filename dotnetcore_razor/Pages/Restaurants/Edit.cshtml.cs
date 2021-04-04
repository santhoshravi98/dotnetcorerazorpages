using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantData.Core;
using RestaurantDataService.Data;
using Type = RestaurantData.Core.Type;

namespace dotnetcore_razor
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restid)
        {
            if (restid.HasValue)
                restaurant = restaurantData.GetRestaurantById(restid.Value);
            else
                restaurant = new Restaurant();
            Cuisines = htmlHelper.GetEnumSelectList<Type>();
            if (restaurant == null)
                return RedirectToPage("./NotFound");
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (restaurant.Id > 0)
                {
                    restaurantData.UpdateRestaurant(restaurant);
                }
                else
                {
                    restaurantData.AddRestaurant(restaurant);
                }
                Cuisines = htmlHelper.GetEnumSelectList<Type>();
                TempData["SuccessMessage"] = "Restaurant Saved";
                return RedirectToPage("./Detail", new { restid = restaurant.Id });
            }
            Cuisines = htmlHelper.GetEnumSelectList<Type>();
            return Page();
        }

    }
}