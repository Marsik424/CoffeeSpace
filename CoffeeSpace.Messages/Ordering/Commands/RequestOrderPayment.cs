using CoffeeSpace.Domain.Ordering.Orders;

namespace CoffeeSpace.Messages.Ordering.Commands;

public interface RequestOrderPayment
{
    Order Order { get; }
}