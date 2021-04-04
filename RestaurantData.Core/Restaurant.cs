using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RestaurantData.Core
{
    public class Restaurant
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(100)]
        public string Location { get; set; }
        public int Id { get; set; }
        public Type Type { get; set; }
    }
}

