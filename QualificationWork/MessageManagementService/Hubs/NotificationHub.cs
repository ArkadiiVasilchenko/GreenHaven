using MessageManagementService.Hubs.HubsInterfaces;
using MessageManagementService.Models.Dto;
using MessageManagementService.Services.ServiceInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Text.RegularExpressions;

namespace MessageManagementService.Hubs
{
    [Authorize]
    public class NotificationHub : Hub<INotificationClient>
    {
        ICommentManagerService commentManagerService;

        public NotificationHub(ICommentManagerService commentManagerService)
        {
            this.commentManagerService = commentManagerService;
        }

        public Task SendMessage(CommentRequestDto commentRequestDto, string token, string group) 
        {
            var comment = commentManagerService.CreateComment(commentRequestDto, token, group);
            //Subscribe(group);

            return Clients.Group(group).Send(comment);
        }

        public override Task OnConnectedAsync()
        {
            string group = Context.GetHttpContext().Request.Query["postId"].ToString();
            Subscribe(group);
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            string group = Context.GetHttpContext().Request.Query["postId"].ToString();
            Unsubscribe(group);
            return base.OnDisconnectedAsync(exception);
        }

        public Task Subscribe(string group)
        {
            return Groups.AddToGroupAsync(Context.ConnectionId, group);
        }

        public Task Unsubscribe(string group)
        {
            return Groups.RemoveFromGroupAsync(Context.ConnectionId, group);
        } 

    }
}
