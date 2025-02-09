using MediatR;

namespace SocialMedia.Application.Events
{
    public record UpdateDailyPostCountEvent(int userId, DateOnly date) : INotification;

}
