using CoffeeSpace.IdentityApi.Models;
using CoffeeSpace.Messages.Buyers.Commands;
using MassTransit;
using Microsoft.AspNetCore.Identity;

namespace CoffeeSpace.IdentityApi.Messages.Consumers;

internal sealed class DeleteBuyerConsumer : IConsumer<DeleteBuyer>
{
    private readonly UserManager<ApplicationUser> _userManager;

    public DeleteBuyerConsumer(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<DeleteBuyer> context)
    {
        var user = await _userManager.FindByEmailAsync(context.Message.Email) 
                   ?? await _userManager.FindByNameAsync(context.Message.Name);

        if (user is not null)
        {
            await _userManager.DeleteAsync(user);
        }
    }
}