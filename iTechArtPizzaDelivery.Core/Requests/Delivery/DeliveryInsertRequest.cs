﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Requests.Delivery
{
    public class DeliveryInsertRequest
    {
        [Required] [Range(3, 255)]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
