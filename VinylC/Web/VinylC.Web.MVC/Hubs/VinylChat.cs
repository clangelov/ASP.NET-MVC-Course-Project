namespace VinylC.Web.MVC.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Microsoft.AspNet.SignalR.Hubs;

    [HubName("chat")]
    public class VinylChat : Hub
    {
        public void NewMessage(string name, string message)
        {
            Clients.All.addMessage(name, message);
        }
    }
}