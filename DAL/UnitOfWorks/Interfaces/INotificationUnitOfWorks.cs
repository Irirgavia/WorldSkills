﻿namespace DAL.UnitOfWorks.Interfaces
{
    using DAL.Entities.NotificationSystem;
    using DAL.Repositories.Interfaces;

    public interface INotificationUnitOfWorks : IUnitOfWork
    {
        IGenericRepository<MailEntity> MailRepository { get; }

        IGenericRepository<NotificationEntity> NotificationRepository { get; }
    }
}