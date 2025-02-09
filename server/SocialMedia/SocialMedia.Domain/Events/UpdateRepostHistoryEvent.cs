using MediatR;
using SocialMedia.Domain.Interfaces.Repositories;


namespace SocialMedia.Application.Events
{
    public record UpdateRepostHistoryEvent(int userId, int postId) : INotification;
}

