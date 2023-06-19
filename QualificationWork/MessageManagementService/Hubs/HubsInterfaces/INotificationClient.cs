using MessageManagementService.Models.Dto;
using ModelLibrary;

namespace MessageManagementService.Hubs.HubsInterfaces
{
    public interface INotificationClient
    {
        Task Send(CommentResponseDto comment);
    }
}
