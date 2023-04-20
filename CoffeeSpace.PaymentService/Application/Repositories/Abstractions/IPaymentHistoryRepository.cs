﻿using CoffeeSpace.PaymentService.Domain;

namespace CoffeeSpace.PaymentService.Application.Repositories.Abstractions;

internal interface IPaymentHistoryRepository
{
    Task<IEnumerable<PaymentHistory>> GetAllAsync(CancellationToken cancellationToken = default);
    
    Task<PaymentHistory?> GetByIdAsync(string id, CancellationToken cancellationToken = default);
    
    Task<bool> CreateAsync(PaymentHistory paymentHistory, CancellationToken cancellationToken = default);
    
    Task<PaymentHistory?> UpdateAsync(PaymentHistory paymentHistory, CancellationToken cancellationToken = default);
    
    Task<bool> DeleteByIdAsync(string id, CancellationToken cancellationToken = default);
}