﻿using CoffeeSpace.PaymentService.Application.Contracts.Requests;
using CoffeeSpace.PaymentService.Application.Helpers;
using CoffeeSpace.PaymentService.Application.Models;
using CoffeeSpace.PaymentService.Application.Services.Abstractions;
using FastEndpoints;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CoffeeSpace.PaymentService.Endpoints;

[HttpGet(ApiEndpoints.Payments.GetByApplicationOrderId)]
internal sealed class GetPaypalOrderByOrderIdEndpoint : Endpoint<GetPaypalOrderByOrderIdRequest, Results<Ok<PaypalOrderInformation>, NotFound>>
{
    private readonly IPaymentService _paymentService;

    public GetPaypalOrderByOrderIdEndpoint(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    public override async Task<Results<Ok<PaypalOrderInformation>, NotFound>> ExecuteAsync(GetPaypalOrderByOrderIdRequest req, CancellationToken ct)
    {
        var paypalOrderInformation = await _paymentService.GetOrderPaymentByOrderIdAsync(req.OrderId, ct);
        return paypalOrderInformation is not null
            ? TypedResults.Ok(paypalOrderInformation)
            : TypedResults.NotFound();
    }
}