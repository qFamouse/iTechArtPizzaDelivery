﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTechArtPizzaDelivery.Domain.Entities;
using iTechArtPizzaDelivery.Domain.Interfaces.Repositories;
using iTechArtPizzaDelivery.Domain.Interfaces.Services;

namespace iTechArtPizzaDelivery.Domain.Services
{
    public class IngredientsService : IIngredientsService
    {
        private readonly IIngredientRepository _ingredientRepository;

        public IngredientsService(IIngredientRepository ingredientRepository)
        {
            _ingredientRepository = ingredientRepository ??
                                    throw new ArgumentNullException(nameof(ingredientRepository), "Interface is null");
        }

        public async Task<Ingredient> AddAsync(Ingredient ingredient)
        {
            return await _ingredientRepository.AddAsync(ingredient);
        }

        public async Task<List<Ingredient>> GetAllAsync()
        {
            return await _ingredientRepository.GetAllAsync();
        }

        public async Task<Ingredient> GetByIdAsync(int id)
        {
            return await _ingredientRepository.GetByIdAsync(id);
        }
    }
}