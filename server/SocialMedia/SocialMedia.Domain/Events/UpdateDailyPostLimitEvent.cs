using MediatR;

namespace SocialMedia.Application.Events
{
    public record UpdateDailyPostLimitEvent(int userId, DateOnly date) : INotification;

}
