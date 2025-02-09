using MediatR;

namespace SocialMedia.Application.Events
{
    public record UpdateRepostCountEvent(int postId) : INotification;
}

