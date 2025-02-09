using MediatR;
using SocialMedia.Application.Events;
using SocialMedia.Domain.Interfaces.Repositories;

public class UpdateDailyPostCountHandler : INotificationHandler<UpdateDailyPostCountEvent>
{
    private readonly IUserDailyPostCountRepository _userDailyPostLimitRepository;

    public UpdateDailyPostCountHandler(IUserDailyPostCountRepository userDailyPostLimitRepository)
    {
        _userDailyPostLimitRepository = userDailyPostLimitRepository;
    }

    public async Task Handle(UpdateDailyPostCountEvent notification, CancellationToken cancellationToken)
    {
        await _userDailyPostLimitRepository.UpsertAsync(notification.userId, notification.date);
    }
}