namespace EcommerceApp.SignalR
{
    using Microsoft.AspNetCore.SignalR;
    public class NotificationsHub : Hub
    {
        public async Task NotifyClientOfPurchaseAsync()
        {
            await Clients.All.SendAsync("PurchaseMade");
        }
    }
}
