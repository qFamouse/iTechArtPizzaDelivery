﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using iTechArtPizzaDelivery.Core.Entities;
using iTechArtPizzaDelivery.Core.Interfaces.Repositories;
using iTechArtPizzaDelivery.Core.Requests.Payment;
using Microsoft.EntityFrameworkCore;

namespace iTechArtPizzaDelivery.Infrastructure.Data.Repositories.Shopping
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public PaymentRepository(PizzaDeliveryContext context, IMapper mapper) : base(context, mapper) { }

        public async Task<Payment> AddAsync(PaymentAddRequest request)
        {
            var payment = Mapper.Map<Payment>(request);
            await DbContext.Payments.AddAsync(payment);
            await DbContext.SaveChangesAsync();
            return payment;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var payment = await DbContext.Payments
                .SingleAsync(p => p.Id == id);
            DbContext.Payments.Remove(payment);
            await DbContext.SaveChangesAsync();
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await DbContext.Payments.ToListAsync();
        }
    }
}