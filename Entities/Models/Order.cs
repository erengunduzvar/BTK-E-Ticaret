﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

        [Required(ErrorMessage ="Name is required")]
        public String? Name { get; set; }

        [Required(ErrorMessage = "Line1 is required")]
        public String? Line1 { get; set; }

        [Required(ErrorMessage = "Line2 is required")]
        public String? Line2 { get; set; }
        [Required(ErrorMessage = "Line3 is required")]
        public String? Line3 { get; set; }
        [Required(ErrorMessage = "City is required")]
        public String? City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
    }
}
