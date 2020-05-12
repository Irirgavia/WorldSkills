namespace DAL.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Entities;
    using DAL.Repositories.Interfaces;

    public class TaskRepository : GenericRepository<TaskEntity, CompetitionContext>, ITaskRepository
    {
        public TaskRepository(CompetitionContext context)
            : base(context)
        {
        }

        public TaskEntity GetTaskById(int id)
        {
            return Context.Tasks.FirstOrDefault(x => x.Id == id);
        }

        public void CreateTask(
            StageEntity stage,
            DateTime dateTime,
            TimeSpan time,
            AddressEntity address,
            string description,
            string requirement,
            ICollection<AnswerEntity> answers)
        {
            Context.Tasks.Add(new TaskEntity(stage, dateTime, time, address, description, requirement, answers));
        }

        public void DeleteTask(int id)
        {
            var task = this.GetTaskById(id);
            if (task != null)
            {
                Context.Tasks.Remove(task);
            }
        }

        public void UpdateTask(
            int id,
            DateTime dateTime,
            TimeSpan time,
            AddressEntity address,
            string description,
            string requirement)
        {
            var task = this.GetTaskById(id);
            if (task != null)
            {
                task.DateTime = dateTime;
                task.Time = time;
                task.Address = address;
                task.Description = description;
                task.Requirement = requirement;
            }
        }
    }
}