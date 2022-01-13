﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaDelivery.Core.Entities
{
    public class Pizza : IEntity
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
