using MediatR;
using SocialMedia.Application.Events;
using SocialMedia.Domain.Entities;
using SocialMedia.Domain.Interfaces.Repositories;

namespace SocialMedia.Application.Handlers
{
    public class UpdateRepostHistoryHandler : INotificationHandler<UpdateRepostHistoryEvent>
    {
        private readonly IRepostHistoryRepository _repostHistoryRepository;

        public UpdateRepostHistoryHandler(IRepostHistoryRepository repostHistoryRepository)
        {
            _repostHistoryRepository = repostHistoryRepository;
        }

        public async Task Handle(UpdateRepostHistoryEvent notification, CancellationToken cancellationToken)
        {
            await _repostHistoryRepository.AddAsync(new RepostHistory
            {
                UserId = notification.userId,
                PostId = notification.postId
            });
        }
    }
}