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
    }
}