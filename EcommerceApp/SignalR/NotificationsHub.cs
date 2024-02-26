﻿namespace EcommerceApp.SignalR
{
    using Microsoft.AspNetCore.SignalR;
    public class NotificationsHub : Hub
    {
        public async Task NotifyClientOfPurchaseAsync()
        {
            await Clients.All.SendAsync("PurchaseMade");
        }
        public async Task ProductUpdated()
        {
            await Clients.All.SendAsync("ProductUpdated");
        }
        public async Task NotifyClientOnUserMessageUpload()
        {
            await Clients.All.SendAsync("UserMessageSent");
        }
    }
}
