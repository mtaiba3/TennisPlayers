using MediatR;

namespace TennisPlayers.Application.Abstractions.Messaging;

public interface INotificationRequestHandler<in TNotificationRequest> : INotificationHandler<TNotificationRequest> where TNotificationRequest : INotification;
