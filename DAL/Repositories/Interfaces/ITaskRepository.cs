namespace DAL.Repositories.Interfaces
{
    using System;
    using System.Collections.Generic;

    using DAL.Entities;

    public interface ITaskRepository : IGenericRepository<TaskEntity>
    {
        TaskEntity GetTaskById(int id);

        void CreateTask(
            StageEntity stage,
            DateTime dateTime,
            TimeSpan time,
            AddressEntity address,
            string description,
            string requirement,
            ICollection<AnswerEntity> answers);

        void DeleteTask(int id);

        void UpdateTask(
            int id,
            DateTime dateTime,
            TimeSpan time,
            AddressEntity address,
            string description,
            string requirement);
    }
}