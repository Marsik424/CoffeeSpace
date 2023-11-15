namespace CoffeeSpace.OrderingApi.Application.Contracts.Requests.Orders;

public sealed class GetOrderByIdRequest
{
    public required Guid Id { get; init; }

    public required Guid BuyerId { get; init; }
}