﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Requests.PizzaIngredient;
using iTechArtPizzaDelivery.Infrastructure.Repositories.Context;
using iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework.Base;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Repositories.EntityFramework
{
    public class PizzaIngredientEFRepository : BaseEFRepository, IPizzaIngredientRepository
    {
        public PizzaIngredientEFRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<PizzaIngredient> AddAsync(PizzaIngredientBindRequest pizzaIngredientAddRequest)
        {
            // Mapping
            var pizzaIngredient = _mapper.Map<PizzaIngredient>(pizzaIngredientAddRequest);
            //pizzaIngredient.Ingredient =
            //    await _dbContext.Ingredients.SingleAsync(i => i.Id == pizzaIngredientAddRequest.IngredientId);
            //pizzaIngredient.PizzaSize =
            //    await _dbContext.PizzasSizes.SingleAsync(i => i.Id == pizzaIngredientAddRequest.PizzaSizeId);

            pizzaIngredient.IngredientId = pizzaIngredientAddRequest.IngredientId;
            pizzaIngredient.PizzaSizeId = pizzaIngredientAddRequest.PizzaSizeId;
            // Adding
            await _dbContext.PizzaIngredients.AddAsync(pizzaIngredient);
            await _dbContext.SaveChangesAsync();
            return pizzaIngredient;
        }

        public async Task<List<PizzaIngredient>> GetAllAsync()
        {
            return await _dbContext.PizzaIngredients
                .Include(pi => pi.PizzaSize)
                .Include(pi => pi.Ingredient)
                .ToListAsync();
        }
    }
}
