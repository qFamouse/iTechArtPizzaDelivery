﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Services;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Requests.Delivery;

namespace iTechArtPizzaDelivery.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveriesController : ControllerBase
    {
        private readonly DeliveryService _deliveryService;
        private readonly IMapper _mapper;

        public DeliveriesController(DeliveryService deliveryService, IMapper mapper)
        {
            _deliveryService = deliveryService ??
                               throw new ArgumentNullException(nameof(deliveryService), "Service is null");

            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper), "Mapper is null");
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync()
        {
            return Ok(await _deliveryService.GetAllAsync());
        }

        [HttpPost("Add")]
        public async Task<ActionResult> AddAsync(DeliveryAddRequest request)
        {
            return Ok(await _deliveryService.AddAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            await _deliveryService.DeleteByIdAsync(id);
            return Ok();
        }
    }
}
