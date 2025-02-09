using MediatR;
using SocialMedia.Application.Events;
using SocialMedia.Domain.Interfaces.Repositories;

public class UpdateDailyPostLimitHandler : INotificationHandler<UpdateDailyPostLimitEvent>
{
    private readonly IUserDailyPostLimitRepository _userDailyPostLimitRepository;

    public UpdateDailyPostLimitHandler(IUserDailyPostLimitRepository userDailyPostLimitRepository)
    {
        _userDailyPostLimitRepository = userDailyPostLimitRepository;
    }

    public async Task Handle(UpdateDailyPostLimitEvent notification, CancellationToken cancellationToken)
    {
        await _userDailyPostLimitRepository.UpsertAsync(notification.userId, notification.date);
    }
}