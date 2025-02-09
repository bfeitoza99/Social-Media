using MediatR;
using SocialMedia.Application.Events;
using SocialMedia.Domain.Interfaces.Repositories;


namespace SocialMedia.Application.Handlers
{
    public class UpdateRepostCountHandler : INotificationHandler<UpdateRepostCountEvent>
    {
        private readonly IPostRepository _postRepository;

        public UpdateRepostCountHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task Handle(UpdateRepostCountEvent notification, CancellationToken cancellationToken)
        {
            await _postRepository.IncrementRepostCountAsync(notification.postId);
        }
    }
}